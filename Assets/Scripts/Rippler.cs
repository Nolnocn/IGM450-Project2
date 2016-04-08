using UnityEngine;
using UnityEngine.EventSystems;

public class Rippler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public RippleScript ripplePrefab;

	public float maxPressTime = 2.0f;

	public float startingMinRippleForce = 0.5f;
	public float startingMaxRippleForce = 10.0f;
	//public float minRippleDistance = 1.0f;
	//public float maxRippleInterval = 0.5f;

	private BoxCollider2D boxCollider;
	//private Vector2 lastMousePos;

	//private float currRippleInterval = 0.0f;

	private float minToMaxRatio;
	private float minRippleForce;
	private float maxRippleForce;
	private float pressTime;

	private bool pressed;

	void Start()
	{
		pressed = false;
		pressTime = 0.0f;

		minToMaxRatio = startingMinRippleForce / startingMaxRippleForce;
		maxRippleForce = startingMaxRippleForce;
		minRippleForce = startingMinRippleForce;

		boxCollider = GetComponent<BoxCollider2D>();
		EventManager.AddEventListener( "CameraResize", Resize );
		Resize();
	}

	void Update()
	{
		if( !pressed )
		{
			// early return
			return;
		}

		pressTime += Time.deltaTime;

		/*if( currRippleInterval > 0.0f )
		{
			currRippleInterval -= Time.deltaTime;
		}*/
	}

	public void OnPointerDown( PointerEventData e )
	{
		pressed = true;
		/*if( currRippleInterval <= 0.0f )
		{
			Vector2 pos = e.pointerPressRaycast.worldPosition;
			SpawnRipple( pos );
			lastMousePos = pos;
			currRippleInterval = maxRippleInterval;
		}*/
	}

	public void OnPointerUp( PointerEventData e )
	{
		Vector2 pos = e.pointerPressRaycast.worldPosition;
		SpawnRipple( pos );

		pressed = false;
		pressTime = 0.0f;
	}

	/*public void OnDrag( PointerEventData e )
	{
		Vector2 worldPos = Camera.main.ScreenToWorldPoint( e.position );

		if( Vector2.Distance( worldPos, lastMousePos ) >= minRippleDistance )
		{
			SpawnRipple( worldPos );
			lastMousePos = worldPos;
		}
	}*/

	private void Resize()
	{
		float aspect = Camera.main.aspect;
		float height = Camera.main.orthographicSize * 2.0f;
		float width = height * aspect;

		boxCollider.size = new Vector2( width, height );

		maxRippleForce = height * 0.5f;
		minRippleForce = maxRippleForce * minToMaxRatio;
	}

	private void SpawnRipple( Vector2 pos )
	{
		RippleScript rs = Instantiate( ripplePrefab, pos, Quaternion.identity ) as RippleScript;
		float perc = Mathf.Min( pressTime, maxPressTime ) / maxPressTime;
		float force = Mathf.Lerp( minRippleForce, maxRippleForce, perc );
		rs.SetForce( force );
	}
}
