using UnityEngine;
using UnityEngine.EventSystems;

public class Rippler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
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

	private Vector2 touchPos;

	private float minToMaxRatio;
	private float minRippleForce;
	private float maxRippleForce;
	private float pressTime;

	private bool pressed;

	public Vector2 TouchPosition
	{
		get{ return touchPos; }
	}

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
		touchPos = e.pointerPressRaycast.worldPosition;
		EventManager.TriggerEvent( "RippleStart" );
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
		SpawnRipple( touchPos );

		pressed = false;
		pressTime = 0.0f;

		EventManager.TriggerEvent( "RippleRelease" );
	}

	public void OnDrag( PointerEventData e )
	{
		touchPos = Camera.main.ScreenToWorldPoint( e.position );
	}

	public float GetRippleForcePercent()
	{
		float perc = Mathf.Min( pressTime, maxPressTime ) / maxPressTime;
		return perc;
	}

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
		float force = Mathf.Lerp( minRippleForce, maxRippleForce, GetRippleForcePercent() );
		rs.SetForce( force );
	}
}
