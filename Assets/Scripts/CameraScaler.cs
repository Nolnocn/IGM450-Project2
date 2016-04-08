using UnityEngine;
using System.Collections;

public class CameraScaler : MonoBehaviour
{
	public PlayerBubbleScript playerBubble;

	private Camera mainCamera;

	void Start()
	{
		mainCamera = Camera.main;
		EventManager.AddEventListener( "PlayerGrow", OnPlayerGrow );
	}
	
	private void OnPlayerGrow()
	{
		if( playerBubble.GetDiameter() > mainCamera.orthographicSize * 0.5f )
		{
			mainCamera.orthographicSize *= 2.0f;
			EventManager.TriggerEvent( "CameraResize" );
		}
	}
}
