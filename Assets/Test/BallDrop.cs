using UnityEngine;
using System.Collections;

public class BallDrop : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().AddForce( new Vector2( 0, -1 ), ForceMode2D.Impulse );
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
