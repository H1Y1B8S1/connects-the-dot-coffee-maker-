using UnityEngine;

public class Dot : MonoBehaviour
{
    public bool isSelected = false; 
    private LineRenderer lineRenderer; 
    private Vector2 lastPosition; 

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    StartDragging(touch.position);
                    break;
                case TouchPhase.Moved:
                    ContinueDragging(touch.position);
                    break;
                case TouchPhase.Ended:
                    EndDragging();
                    break;
            }
        }
    }

    private void StartDragging(Vector2 touchPosition)
    {
        lastPosition = Camera.main.ScreenToWorldPoint(touchPosition);
    }

    private void ContinueDragging(Vector2 touchPosition)
    {
        Vector2 currentPosition = Camera.main.ScreenToWorldPoint(touchPosition);
        RaycastHit2D hit = Physics2D.Raycast(lastPosition, currentPosition - lastPosition);

        if (hit && hit.collider.gameObject == gameObject)
        {
            SelectDot();
        }

        lastPosition = currentPosition;
    }

    private void EndDragging()
    {
       //Animation
    }

    private void SelectDot()
    {
        if (!isSelected)
        {
            isSelected = true;
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, transform.position);
        }
    }
}
