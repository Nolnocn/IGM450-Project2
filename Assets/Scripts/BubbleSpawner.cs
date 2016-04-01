using UnityEngine;
using System.Collections.Generic;

public class BubbleSpawner : MonoBehaviour
{
	public GameObject bubblePrefab;
	public LayerMask spawnLayerMask;

	public int maxBubbles = 10;

	public float minBubbleSize = 0.5f;
	public float maxBubbleSize = 1.5f;

	private List<GameObject> bubbles;

	void Start()
	{
		bubbles = new List<GameObject>();
	}
	
	void Update()
	{
		for( int i = bubbles.Count - 1; i >= 0; i-- )
		{
			if( bubbles[ i ] == null )
			{
				bubbles.Remove( bubbles[ i ] );
			}
		}

		if( bubbles.Count < maxBubbles )
		{
			SpawnBubble();
		}
	}

	private void SpawnBubble()
	{
		Vector3 pos = Vector3.zero;
		float scale = Random.Range( minBubbleSize, maxBubbleSize );

		// Temp until world bounds are set up
		// TODO: Set up world bounds
		float aspect = Camera.main.aspect;
		float height = Camera.main.orthographicSize;
		float width = height * aspect;

		pos.x = Random.Range( -width + 2 + scale * 0.5f, width - 2 - scale * 0.5f );
		pos.y = Random.Range( -height + 2 + scale * 0.5f, height - 2 - scale * 0.5f );

		Collider2D hitCol = Physics2D.OverlapCircle( pos, scale, spawnLayerMask );

		if( hitCol == null )
		{
			GameObject newBubble = (GameObject)Instantiate( bubblePrefab, pos, Quaternion.identity );
			newBubble.transform.localScale = new Vector3( scale, scale, 1.0f );
			bubbles.Add( newBubble );
		}
	}
}
