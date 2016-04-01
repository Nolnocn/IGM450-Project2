using UnityEngine;
using System.Collections;

public class RippleScript : MonoBehaviour
{
	public float duration = 1.0f;
	public float maxSize = 5.0f;

	private float currTime;
	private SpriteRenderer spriteRenderer;

	void Start()
	{
		currTime = 0.0f;
		transform.localScale = new Vector3( 0.0f, 0.0f, 1.0f );

		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		float perc = currTime / duration;
		float scale = maxSize * perc;
		transform.localScale = new Vector3( scale, scale, 1.0f );

		Color color = spriteRenderer.color;
		color.a = 1.0f - perc * perc;
		spriteRenderer.color = color;

		currTime += Time.deltaTime;

		if( currTime >= duration )
		{
			Destroy( gameObject );
		}
	}

	void OnTriggerEnter2D( Collider2D col )
	{
		if( col.tag == "Bubble" )
		{
			Rigidbody2D rb = col.GetComponent<Rigidbody2D>();
			Vector3 dir = col.transform.position - transform.position;
			rb.velocity = Vector2.zero;
			rb.AddForce( dir.normalized * maxSize / duration * 0.5f, ForceMode2D.Impulse );
		}
	}
}
