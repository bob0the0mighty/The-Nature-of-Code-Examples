﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Example 1.2 from chapter 1 of The Nature of Code.
/// This example is more idiomatic in Unity. We're adding a vector to a vector
/// this time. I get the feeling that an even more "Unity" like way to 
/// implement this example would be to add a RigidBody2d to VectorBall and then
/// apply forces to the VectorBall. This seems like overkill in non-physics 
/// based games and in simple cases like this.
/// 
/// Again, this script is shorter than the Processing version because it relies
/// on Unity.
/// </summary>
public class VectorBall : MonoBehaviour {

    //Since this is public, it can be set in the Unity GUI in the inspector
    //once the script has been added to the sprite object.
    public Vector3 velocity = new Vector3(0.025f, 0.025f, 0f);

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
    /// This runs a bit faster in Unity, so spead should probably be much
    /// lower.
    /// </summary>
    void Update()
    {
        //Move the ball according to velocity.
        transform.position += velocity;

        //Check for bouncing.
        //This is different than processing. We set transfrom the new position
        //(x, y) into a new vector3. This new vector normalizes points that
        //are in the camera's view to 0 through 1, inclusive for both the x and
        //y coordinates. 
        //ex. In my scene, 0,0 is the center of the world, roughly -11.33 and
        //11.33 are the x-boundaries, -5 and 5 are the y-boundaries. A vector
        //with coordinates 0,0 becomes 0.5,0.5 after being passed to 
        //Camera.main.WorldToViewportPoint.
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

        //Inverts x  if newPosition is outside of the viewport. Note this is
        //from the center of the sprite so the entire sprite does not exit the 
        //camera area and it looks similar to bouncing.
        if (viewportPosition.x > 1 || viewportPosition.x < 0)
        {
            velocity.x = velocity.x * -1;
        }

        //Same but for the y portion.
        if (viewportPosition.y > 1 || viewportPosition.y < 0)
        {
            velocity.y = velocity.y * -1;
        }
    }
}
