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
	private PlayerBubbleScript playerBubble;

	void Awake()
	{
		instance = this;
		EventManager.AddEventListener ("PlayerGrow", UpdateScore);
		EventManager.AddEventListener ("GameOver", TriggerDeathUI);
	}

	public void UpdateScore()
	{
		scoreText.text = playerBubble.GetScore ().ToString();
	}

	public void TriggerDeathUI() 
	{
		Debug.Log ("Death");
		lossPanel.transform.parent.gameObject.SetActive (true);
		lossPanel.UpdateScore (playerBubble.GetScore ());
	}

	public void Pause() 
	{
		Time.timeScale = 0.0f;
		pausePanel.transform.parent.gameObject.SetActive (true);	
	}
}
