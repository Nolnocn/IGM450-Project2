using UnityEngine;
using UnityEngine.EventSystems;

public class Rippler : MonoBehaviour, IDragHandler, IPointerDownHandler
{
	public GameObject ripplePrefab;

	public float minRippleDistance = 1.0f;
	public float maxRippleInterval = 0.5f;

	private BoxCollider2D boxCollider;
	private Vector2 lastMousePos;

	private float currRippleInterval = 0.0f;

	void Start()
	{
		boxCollider = GetComponent<BoxCollider2D>();

		Resize();
	}

	void Update()
	{
		if( currRippleInterval > 0.0f )
		{
			currRippleInterval -= Time.deltaTime;
		}
	}

	public void OnPointerDown( PointerEventData e )
	{
		if( currRippleInterval <= 0.0f )
		{
			Vector2 pos = e.pointerPressRaycast.worldPosition;
			SpawnRipple( pos );
			lastMousePos = pos;
			currRippleInterval = maxRippleInterval;
		}
	}

	public void OnDrag( PointerEventData e )
	{
		Vector2 worldPos = Camera.main.ScreenToWorldPoint( e.position );

		if( Vector2.Distance( worldPos, lastMousePos ) >= minRippleDistance )
		{
			SpawnRipple( worldPos );
			lastMousePos = worldPos;
		}
	}

	private void Resize()
	{
		float aspect = Camera.main.aspect;
		float height = Camera.main.orthographicSize * 2.0f;
		float width = height * aspect;

		boxCollider.size = new Vector2( width, height );
	}

	private void SpawnRipple( Vector2 pos )
	{
		Instantiate( ripplePrefab, pos, Quaternion.identity );
	}
}
