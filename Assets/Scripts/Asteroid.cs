using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour
{
	public const float GRAVITATION_MAGNITUDE = 100.0f;

	public Vector3 centerOfOrbit;

	private Rigidbody2D myRigidbody;

	void Start()
	{
		myRigidbody = GetComponent<Rigidbody2D>();

		centerOfOrbit = new Vector3( 0.0f, 0.0f, 0.0f );

		Vector3 toCenter = centerOfOrbit - transform.position;
		Vector2 tangential = new Vector2( -toCenter.y, toCenter.x );
		tangential.Normalize();

		Vector3 initForce = new Vector3( tangential.x, tangential.y, 0.0f );
		initForce *= Mathf.Sqrt( GRAVITATION_MAGNITUDE * ( 100.0f / toCenter.magnitude - 1.0f / toCenter.magnitude ) );

		myRigidbody.AddForce( initForce, ForceMode2D.Impulse );
	}

	void FixedUpdate()
	{
		CalculateOrbitalForce ();
	}

	private void CalculateOrbitalForce()
	{
		Vector3 toCenter = centerOfOrbit - transform.position;
		float radius = toCenter.magnitude;
		toCenter.Normalize();
		Vector3 gravity = GRAVITATION_MAGNITUDE * toCenter / (radius * radius);
		myRigidbody.AddForce( gravity );
	}
}
