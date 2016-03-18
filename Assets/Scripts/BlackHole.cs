using UnityEngine;
using System.Collections;

public class BlackHole : MonoBehaviour
{
	public float suckForce = 5.0f;
	public float rotationSpeed = 200.0f;
	public float radius = 10.0f;

	private ParticleSystem particleSys;

	void Start()
	{
		particleSys = GetComponent<ParticleSystem>();

		particleSys.startSpeed = -radius;
		transform.localScale *= radius / 10;

		particleSys.Play();
	}

	void Update()
	{
		//transform.Rotate( 0, 0, rotationSpeed * Time.deltaTime );
	}

	void FixedUpdate()
	{
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll( transform.position, radius );

		foreach( Collider2D col in hitColliders )
		{
			Rigidbody2D rb = col.GetComponent<Rigidbody2D>();
			
			if( rb != null )
			{
				Vector3 toCenter =  transform.position - col.transform.position;

				float percent = Mathf.Max( 0,  radius - toCenter.magnitude ) / radius;

				//Vector3 tangential = new Vector3( -toCenter.y, toCenter.x );
				Vector3 force = toCenter * ( 1 - percent ) * suckForce;// * rb.mass;
				rb.AddForce( force, ForceMode2D.Force );
			}
		}
	}
}
