using UnityEngine;
using System.Collections;

public class PlayerBubbleScript : BubbleScript
{
	public int GetScore()
	{
		return Mathf.FloorToInt( ( GetDiameter() - 1.0f ) * 10.0f );
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
