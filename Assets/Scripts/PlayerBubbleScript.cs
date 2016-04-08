using UnityEngine;
using System.Collections;

public class PlayerBubbleScript : BubbleScript
{
	private float startingArea;

	void Start()
	{
		CalculateArea();
		startingArea = area;
	}

	public int GetAreaAsScore()
	{
		float score = area - startingArea;
		return Mathf.FloorToInt( score * 100.0f );
	}

	public override void KillBubble()
	{
		EventManager.TriggerEvent( "GameOver" );
		gameObject.SetActive( false );
	}

	public float GetDiameter()
	{
		return transform.localScale.x;
	}

	protected override void EatBubble( BubbleScript bubble )
	{
		base.EatBubble( bubble );
		EventManager.TriggerEvent( "PlayerGrow" );
	}
}
