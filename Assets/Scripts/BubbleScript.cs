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
			if( transform.localScale.x > go.transform.localScale.x )
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
		float newDiameter = Mathf.Sqrt( newArea / Mathf.PI ) * 2.0f;

		transform.localScale = new Vector3( newDiameter, newDiameter, 1.0f );
		area = newArea;
		bubble.KillBubble();
	}
}
