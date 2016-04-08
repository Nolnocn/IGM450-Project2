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

	[SerializeField]
	private PlayerBubbleScript playerBubble;

	void Awake()
	{
		instance = this;
		EventManager.AddEventListener ("PlayerGrow", UpdateScore);
	}

	public void UpdateScore ()
	{
		scoreText.text = playerBubble.GetAreaAsScore ().ToString();
	}
}
