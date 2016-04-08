using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameUIController : MonoBehaviour {

	private static GameUIController instance;
	public static GameUIController Instance {
		get { return instance; }
	}

	[SerializeField]
	private GameObject lossPanel;
	[SerializeField]
	private Text scoreText;
	[SerializeField]
	private Text lossScoreText;

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
		lossPanel.SetActive (true);
		lossScoreText.text = playerBubble.GetScore ().ToString();
	}
}
