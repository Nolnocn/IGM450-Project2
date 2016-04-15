using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameUIController : MonoBehaviour {

	private static GameUIController instance;
	public static GameUIController Instance {
		get { return instance; }
	}

	[SerializeField]
	private LossPanelController lossPanel;
	[SerializeField]
	private PausePanelControl pausePanel;
	[SerializeField]
	private Text scoreText;
	[SerializeField]
	private GameObject rippleUI;


	[SerializeField]
	private PlayerBubbleScript playerBubble;
	public PlayerBubbleScript PlayerBubble 
	{
		get { return playerBubble; }
	}

	void Awake()
	{
		instance = this;
		EventManager.AddEventListener ("PlayerGrow", UpdateScore);
		EventManager.AddEventListener ("GameOver", TriggerDeathUI);
		EventManager.AddEventListener ("RippleStart", ActivateRippleUI);
		EventManager.AddEventListener ("RippleRelease", DeactivateRippleUI);
	}

	public void UpdateScore()
	{
		scoreText.text = playerBubble.GetScore ().ToString();
	}

	public void TriggerDeathUI() 
	{
		DeactivateRippleUI ();
		lossPanel.transform.parent.gameObject.SetActive (true);
		lossPanel.UpdateScore (playerBubble.GetScore ());
		EventManager.TriggerEvent ("UpdateHighScore");
	}

	public void Pause() 
	{
		Time.timeScale = 0.0f;
		pausePanel.transform.parent.gameObject.SetActive (true);
		EventManager.TriggerEvent ("UpdateHighScore");
	}

	private void ActivateRippleUI() 
	{
		rippleUI.gameObject.SetActive (true);
	}

	private void DeactivateRippleUI() 
	{
		rippleUI.gameObject.SetActive (false);
	}
}
