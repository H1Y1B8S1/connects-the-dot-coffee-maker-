using UnityEngine;

public class Dot : MonoBehaviour
{
    public bool isSelected = false; // Flag to track dot selection
    private LineRenderer lineRenderer; // Reference to the LineRenderer component
    private Vector2 lastPosition; // Last position of the touch input

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0; // Initialize the LineRenderer with no points
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Get the first touch

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
        // Reset any dragging-related states or actions if needed
    }

    private void SelectDot()
    {
        if (!isSelected)
        {
            isSelected = true;
            lineRenderer.positionCount++; // Increase LineRenderer points by 1
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, transform.position); // Set line point to dot position
        }
    }
}
