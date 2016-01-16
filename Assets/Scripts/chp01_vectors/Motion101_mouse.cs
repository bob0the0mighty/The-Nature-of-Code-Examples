using UnityEngine;
using System.Collections;

/// <summary>
/// Example 1.8 from chapter 1 of The Nature of Code.
/// 
/// </summary>
public class Motion101_mouse : MonoBehaviour
{

    //Since this is public, it can be set in the Unity GUI in the inspector
    //once the script has been added to the sprite object.
    public Vector3 velocity = new Vector3(0f, 0f, 0f);
    public Vector3 acceleration;
    public float maxVelocity = 0.2f;
    public float accelMult = 0.005f;

    /// <summary>
    /// This should run once, and is used to set up any variables you may need.
    /// Similar to Processing's setup method. In this case we've set up the 
    /// background already and the "size" is based off the camera location.
    /// </summary>
    void Start()
    {

    }

    /// <summary>
    /// Called once per frame. Some thing like background are not needed in
    /// Unity since the scene is not being drawn at as low a level as in 
    /// Processing.
    /// 
    /// This runs a bit faster in Unity, so speed should probably be much
    /// lower.
    /// </summary>
    void Update()
    {
        Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        acceleration = difference.normalized * accelMult;

        //add acceleration to velocity
        velocity += acceleration;
        velocity = ClampVelocity(velocity, maxVelocity);

        //Move the ball according to velocity.
        transform.position += velocity;
        
    }

    private Vector3 ClampVelocity(Vector3 velocity, float maxVelocity)
    {
        if (velocity.magnitude > maxVelocity)
        {
            return velocity.normalized * maxVelocity;
        }
        else
        {
            return velocity;
        }
    }
}