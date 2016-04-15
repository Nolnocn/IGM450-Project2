using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreUI : MonoBehaviour {

	[SerializeField]
	private Text highScoreText;

	void Awake() 
	{
		EventManager.AddEventListener ("UpdateHighScore", SaveScore);
	}

	public void OnEnable()
	{
		highScoreText.text = RetrieveHighScore().ToString();
	}

	public int RetrieveHighScore()
	{
		return PlayerPrefs.HasKey ("Highscore") ? PlayerPrefs.GetInt ("Highscore") : 0;
	}

	public void SaveScore()
	{
		Debug.Log ("Saving Score");
		int score = GameUIController.Instance.PlayerBubble.GetScore ();
		int highScore = RetrieveHighScore ();

		if (score > highScore) {
			PlayerPrefs.SetInt ("Highscore", score);
			highScoreText.text = score.ToString ();
		}
	}

	void Update()
	{
		OnEnable ();
	}
}
