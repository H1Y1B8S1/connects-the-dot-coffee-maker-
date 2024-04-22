using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LineManager : MonoBehaviour
{
    public LineRenderer lineRenderer; 
    public Transform dotsParent; 
    private Dot[] dots;

    public GameObject gameOver;


    private void Start()
    {
        dots = dotsParent.GetComponentsInChildren<Dot>();
        lineRenderer.positionCount = 0;
    }

    private void Update()
    {
        DrawLines();
    }

    private void DrawLines()
    {
        lineRenderer.positionCount = 0;
        int count = 0;

        foreach (Dot dot in dots)
        {
            if (dot.isSelected)
            {
                lineRenderer.positionCount++; 
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, dot.transform.position); 
                count++;
            }
        }

        if (lineRenderer.positionCount >= 2)
        {
            lineRenderer.enabled = true;
        }
        else
        {
            lineRenderer.enabled = false;
        }

        if (count == dots.Length)
        {
            gameOver.SetActive(true);
            StartCoroutine(Delay(1.0f)); 
        }
    }

    IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //gameObject.SetActive(false);
    }
}
