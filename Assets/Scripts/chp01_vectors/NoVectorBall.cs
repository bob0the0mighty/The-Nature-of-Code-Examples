﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Example 1.1 from chapter 1 of The Nature of Code.
/// Since Unity uses vectors everywhere, it's not optimal to implement 
/// this example, but you can do it without vector math.
/// 
/// The overall script is slightly less verbose than the original, but it
/// relies on the Unity engine to do more of the heavy lifting on the
/// backend.
/// </summary>
public class NoVectorBall : MonoBehaviour {
    
    private float x;
    private float y;
    
    //Since these are public, they can be set in the Unity GUI in the inspector
    //once the script has been added to the sprite object.
    public float xspeed = .025f;
    public float yspeed = .025f;

    /// <summary>
    /// This should run once, and is used to set up any variables you may need.
    /// Similar to Processing's setup method. In this case we've set up the 
    /// background already and the "size" is based off the camera location.
    /// </summary>
    void Start () {
	    
	}
	
	// Update is called once per frame
    /// <summary>
    /// Called once per frame. Some thing like background are not needed in
    /// Unity since the scene is not being drawn at as low a level as in 
    /// Processing.
    /// 
    /// This runs a bit faster in Unity, so the speeds should probably be low.
    /// </summary>
	void Update () {
        //Move the ball according to its speed.
        x = transform.position.x + xspeed;
        y = transform.position.y + yspeed;

        //Since all items in Unity use transform to store location information,
        //you have to create a new Vector3, set the x and y components to the
        //local x and y values, and then set the sprite transform equal to the
        //newly created vector in order to move the sprite.
        Vector3 newPosition = new Vector3(x, y);
        transform.position = newPosition;

        //Check for bouncing.
        //This is different than processing. We set transfrom the new position
        //(x, y) into a new vector3. This new vector normalizes points that
        //are in the camera's view to 0 through 1, inclusive for both the x and
        //y coordinates. 
        //ex. In my scene, 0,0 is the center of the world, roughly -11.33 and
        //11.33 are the x-boundaries, -5 and 5 are the y-boundaries. A vector
        //with coordinates 0,0 becomes 0.5,0.5 after being passed to 
        //Camera.main.WorldToViewportPoint.
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(newPosition);

        //Inverts xspeed if newPosition is outside of the viewport. Note this is
        //from the center of the sprite so the entire sprite does not exit the 
        //camera area and it looks similar to bouncing.
        if ( viewportPosition.x > 1 || viewportPosition.x < 0 ) {
            xspeed = xspeed * -1;
        }

        //Same but for yspeed.
        if(viewportPosition.y > 1 || viewportPosition.y < 0 )
        {
            yspeed = yspeed * -1;
        }
    }
}
