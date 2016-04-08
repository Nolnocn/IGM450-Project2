using UnityEngine;
using System.Collections;

public class BoundsScaler : MonoBehaviour
{
	public float boundsWidth = 2.0f;

	private float halfBoundsWidth;
	private BoxCollider2D[] boundsColliders;

	private Rect currentBounds;

	void Start()
	{
		halfBoundsWidth = boundsWidth * 0.5f;
		boundsColliders = GetComponents<BoxCollider2D>();
		EventManager.AddEventListener( "CameraResize", Resize );

		Resize();
	}

	public Rect GetBounds()
	{
		return currentBounds;
	}
	
	private void Resize()
	{
		float aspect = Camera.main.aspect;
		float height = Camera.main.orthographicSize * 2.0f;
		float width = height * aspect;

		Vector2 boundsPos = new Vector2( -width * 0.5f + halfBoundsWidth, -height * 0.5f - halfBoundsWidth );
		Vector2 boundsSize = new Vector2( width, height );
		Rect bounds = new Rect( boundsPos, boundsSize );

		Vector2 offset = new Vector2( 0.0f, bounds.yMax );
		Vector2 size = new Vector2( width, boundsWidth );

		// Top
		boundsColliders[ 0 ].offset = offset;
		boundsColliders[ 0 ].size = size;

		// Bottom
		offset.y *= -1.0f;
		boundsColliders[ 1 ].offset = offset;
		boundsColliders[ 1 ].size = size;

		// Swap values of offset and size to set left & right bounds
		offset.y = offset.x;
		offset.x = bounds.xMin;
		size.x = size.y;
		size.y = height;

		// Left
		boundsColliders[ 2 ].offset = offset;
		boundsColliders[ 2 ].size = size;

		// Right
		offset.x *= -1.0f;
		boundsColliders[ 3 ].offset = offset;
		boundsColliders[ 3 ].size = size;

		currentBounds = bounds;
	}
}
