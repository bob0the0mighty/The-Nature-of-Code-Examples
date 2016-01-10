﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Example 1.3 from chapter 1 of The Nature of Code.
/// This exmple is close to the Processing verion. Both use a line drawing 
/// function to display the line. The original code shifts the viewing box so
/// that the line will be drawn from the center of the viewport. Usually in 
/// Unity 0,0,0 is the center of the camera. This is arbitrary and can be
/// changed if wanted.
/// </summary>
public class VectorNormalize : MonoBehaviour
{
    private Vector3 center = Vector3.zero;
    private LineRenderer lr;

    //The LineRenderer component must be set after the GameObject is 
    //initialized.
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    //Here we translate the mousepointer location to a camera point. 
    //Mouseposition returns a Vector3 with x, y coordinates and a 0 for the 
    //z-index. Depending on the location camera, you have to add a z component
    //if you want your line to display the correct length.
    void Update()
    {
        Vector3 threeDMousePoint = Input.mousePosition;

        threeDMousePoint.z = 10.0f;

        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(threeDMousePoint);
        worldPoint.Normalize();
        worldPoint *= 2;

        lr.SetPosition(1, worldPoint);
    }
}