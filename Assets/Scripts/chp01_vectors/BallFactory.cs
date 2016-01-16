using UnityEngine;
using System.Collections;
using System.Linq;

public class BallFactory : MonoBehaviour {
    
    public int ballCount = 10;

	// Use this for initialization
	void Start () {
        Debug.Log("start");
        Enumerable.Range(0, ballCount).All(i => Instantiate(Resources.Load("MouseFollowerBall"), Random.insideUnitCircle * 2f, Quaternion.identity));
    }
}
