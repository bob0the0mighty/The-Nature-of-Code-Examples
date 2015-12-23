using UnityEngine;
using System.Collections;

/// <summary>
/// Example 1.4 from chapter 1 of The Nature of Code.
/// Here we multiply the derived worldPoint by multiplying by 0.5f. We can do 
/// this because C# allows classes to overide operators. worldPoint * 0.5f is
/// equivalent to mouse.mult(0.5) in the original;
/// </summary>
public class MultiplicationVectorLine : MonoBehaviour
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
        worldPoint = worldPoint * 0.5f;

        lr.SetPosition(1, worldPoint);
    }
}
