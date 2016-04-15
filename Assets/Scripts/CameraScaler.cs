using UnityEngine;
using System.Collections;

public class CameraScaler : MonoBehaviour
{
	public const float SCALE_AMT = 4.0f;
	public PlayerBubbleScript playerBubble;

	private Camera mainCamera;

	void Start()
	{
		mainCamera = Camera.main;
		EventManager.AddEventListener( "PlayerGrow", OnPlayerGrow );
	}
	
	private void OnPlayerGrow()
	{
		if( playerBubble.GetDiameter() > mainCamera.orthographicSize * 2.0f / SCALE_AMT )
		{
			mainCamera.orthographicSize *= SCALE_AMT;
			EventManager.TriggerEvent( "CameraResize" );
		}
	}
}
