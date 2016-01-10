using UnityEngine;
using System.Collections;

/// <summary>
/// Example 1.7 from chapter 1 of The Nature of Code.
/// 
/// </summary>
public class Motion101 : MonoBehaviour
{

    //Since this is public, it can be set in the Unity GUI in the inspector
    //once the script has been added to the sprite object.
    public Vector3 velocity;

    /// <summary>
    /// This should run once, and is used to set up any variables you may need.
    /// Similar to Processing's setup method. In this case we've set up the 
    /// background already and the "size" is based off the camera location.
    /// </summary>
    void Start()
    {
        Vector3 startPosition = (Vector3) Random.insideUnitCircle;
        startPosition.z = 10;
        transform.position = Camera.main.ViewportToWorldPoint(startPosition);

        velocity = (Vector3) Random.insideUnitCircle * 0.2f;
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
        CheckEdges();
    }

    private void CheckEdges()
    {
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
        
        if (viewportPosition.x > 1)
        {
            viewportPosition.x = 0;
            
        }
        else if (viewportPosition.x < 0)
        {
            viewportPosition.x = 1;
        }

        if (viewportPosition.y > 1)
        {
            viewportPosition.y = 0;
        }
        else if (viewportPosition.y < 0)
        {
            viewportPosition.y = 1;
        }

        transform.position = Camera.main.ViewportToWorldPoint(viewportPosition);
    }
}