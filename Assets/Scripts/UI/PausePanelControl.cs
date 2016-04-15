using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PausePanelControl : MonoBehaviour {

	[SerializeField]
	private Text pauseScoreText;
	[SerializeField]
	private Animator panelAnimator;
	public Animator PanelAnimator 
	{
		get { return panelAnimator; }
	}

	public void UpdateScore(int score)
	{
		pauseScoreText.text = score.ToString ();
	}

	public void DisableLossScreenObject() 
	{
		gameObject.transform.parent.gameObject.SetActive (false);
	}

	public void ClosePauseScreen()
	{
		Time.timeScale = 1.0f;
		panelAnimator.SetTrigger ("Close");
	}
}
