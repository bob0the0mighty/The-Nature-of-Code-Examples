using UnityEngine;
using System.Collections;

/// <summary>
/// Example 1.5 from chapter 1 of The Nature of Code.
/// This is the magnitude drawer. Since the other lineDrawer is an object, 
/// I can set a variable 
/// </summary>
public class VectorMagnitude : MonoBehaviour
{

    public VectorLine centerLine;

    private Vector3 center = Vector3.zero;
    private LineRenderer lr;

    //The LineRenderer component must be set after the GameObject is 
    //initialized.
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.SetPosition(0,new Vector3(-15, 5, 0));
    }

    //Here we translate the mousepointer location to a camera point. 
    //Mouseposition returns a Vector3 with x, y coordinates and a 0 for the 
    //z-index. Depending on the location camera, you have to add a z component
    //if you want your line to display the correct length.
    void Update()
    {
        Debug.Log(Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 10f)));
        lr.SetPosition(1, new Vector3(-14.4f + centerLine.magnitude, 5, 0)); 
    }
}
