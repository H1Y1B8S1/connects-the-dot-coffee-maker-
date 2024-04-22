using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    public LineRenderer lineRenderer; // Reference to the LineRenderer component
    public Transform dotsParent; // Parent object containing all dot objects
    private Dot[] dots; // Array to store references to all dot objects


    private void Start()
    {
        dots = dotsParent.GetComponentsInChildren<Dot>(); // Get all Dot components under dotsParent
        lineRenderer.positionCount = 0; // Initialize LineRenderer with no points
    }

    private void Update()
    {
        DrawLines(); // Call DrawLines method in Update for real-time updates
    }

    private void DrawLines()
    {
        lineRenderer.positionCount = 0; // Reset LineRenderer points before drawing

        foreach (Dot dot in dots)
        {
            if (dot.isSelected)
            {
                lineRenderer.positionCount++; // Increase LineRenderer points by 1
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, dot.transform.position); // Set line point to dot position
            }
        }

        // Draw lines between selected dots
        if (lineRenderer.positionCount >= 2)
        {
            lineRenderer.enabled = true; // Show the LineRenderer if there are at least 2 points
        }
        else
        {
            lineRenderer.enabled = false; // Hide the LineRenderer if less than 2 points
        }
    }
}
