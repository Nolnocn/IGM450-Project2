using UnityEngine;
using System.Collections.Generic;

public class BubbleSpawner : MonoBehaviour
{
	public BoundsScaler bounds;

	public GameObject bubblePrefab;
	public LayerMask spawnLayerMask;

	public int maxBubbles = 10;

	public float minBubbleSize = 0.5f;
	public float maxBubbleSize = 1.5f;

	void Start()
	{
		EventManager.AddEventListener( "CameraResize", OnCameraResize );
	}

	void Update()
	{
		if( transform.childCount < maxBubbles )
		{
			SpawnBubble();
		}
	}

	private void SpawnBubble()
	{
		Vector3 pos = Vector3.zero;
		float scale = Random.Range( minBubbleSize, maxBubbleSize );
		float radius = scale * 0.5f;

		Rect worldBounds = bounds.GetBounds();
		pos.x = Random.Range( worldBounds.xMin + radius, worldBounds.xMax - radius );
		pos.y = Random.Range( worldBounds.yMin + radius, worldBounds.yMax - radius );

		Collider2D hitCol = Physics2D.OverlapCircle( pos, radius, spawnLayerMask );

		if( hitCol == null )
		{
			GameObject newBubble = (GameObject)Instantiate( bubblePrefab, pos, Quaternion.identity );
			newBubble.transform.localScale = new Vector3( scale, scale, 1.0f );
			newBubble.transform.parent = transform;
		}
	}

	private void OnCameraResize()
	{
		float size = Camera.main.orthographicSize / CameraScaler.SCALE_AMT;
		minBubbleSize = size * 0.125f;
		maxBubbleSize = size * 0.75f;
		maxBubbles *= 2;
	}
}
