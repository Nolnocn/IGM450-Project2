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
	private Text scoreText;
	private int score;

	void Awake()
	{
		instance = this;
		score = 0;
	}

	public void UpdateScore (int amount)
	{
		score += amount;
		scoreText.text = score.ToString ();
	}
}
