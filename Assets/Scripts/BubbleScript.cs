using UnityEngine;
using System.Collections;

public class BubbleScript : MonoBehaviour
{
	protected float area;

	public float Area
	{
		get { return area; }
	}

	void Start()
	{
		CalculateArea();
	}

	void OnCollisionEnter2D( Collision2D collision )
	{
		GameObject go = collision.gameObject;
			if( go.tag == "Bubble" )
		{
			if( transform.localScale.x > go.transform.localScale.x * 1.1f )
			{
				EatBubble( go.GetComponent<BubbleScript>() );
			}
		}
	}

	public virtual void KillBubble()
	{
		Destroy( gameObject );
	}

	protected void CalculateArea()
	{
		float radius = transform.localScale.x * 0.5f;
		area = Mathf.PI * radius * radius;
	}

	protected virtual void EatBubble( BubbleScript bubble )
	{
		float newArea = area + bubble.Area;
		float newRadius = Mathf.Sqrt( newArea / Mathf.PI );

		transform.localScale = new Vector3( newRadius * 2.0f, newRadius * 2.0f, 1.0f );
		area = newArea;
		bubble.KillBubble();
	}
}
