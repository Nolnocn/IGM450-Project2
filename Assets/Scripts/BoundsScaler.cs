using UnityEngine;
using System.Collections;

public class BoundsScaler : MonoBehaviour
{
	public float boundsWidth = 2.0f;

	private float halfBoundsWidth;
	private BoxCollider2D[] boundsColliders;

	void Start()
	{
		halfBoundsWidth = boundsWidth * 0.5f;
		boundsColliders = GetComponents<BoxCollider2D>();
		EventManager.AddEventListener( "CameraResize", Resize );

		Resize();
	}
	
	private void Resize()
	{
		// TODO: Switch to world size w/ panning camera
		float aspect = Camera.main.aspect;
		float height = Camera.main.orthographicSize * 2.0f;
		float width = height * aspect;

		Vector2 offset = new Vector2( 0.0f, height * 0.5f - halfBoundsWidth );
		Vector2 size = new Vector2( width, boundsWidth );

		// Top
		boundsColliders[ 0 ].offset = offset;
		boundsColliders[ 0 ].size = size;

		// Bottom
		offset.y *= -1.0f;
		boundsColliders[ 1 ].offset = offset;
		boundsColliders[ 1 ].size = size;

		// Swap constant values of offset and size
		// To set left & right bounds
		offset.y = offset.x;
		offset.x = width * 0.5f - halfBoundsWidth;
		size.x = size.y;
		size.y = height;

		// Left
		boundsColliders[ 2 ].offset = offset;
		boundsColliders[ 2 ].size = size;

		// Right
		offset.x *= -1.0f;
		boundsColliders[ 3 ].offset = offset;
		boundsColliders[ 3 ].size = size;
	}
}
