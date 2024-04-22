using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    public bool isSelected = false;
    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0; // Initialize the LineRenderer with no points
    }

    private void OnMouseDown()
    {
        if (!isSelected)
        {
            isSelected = true;
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, transform.position); // Set line point to dot position
        }
        else
        {
            isSelected = false;
            lineRenderer.positionCount--; // Decrease LineRenderer points by 1
        }
    }
}
