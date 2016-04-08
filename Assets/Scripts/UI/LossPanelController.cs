using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LossPanelController : MonoBehaviour {

	[SerializeField]
	private Text lossScoreText;
	[SerializeField]
	private Animator panelAnimator;
	public Animator PanelAnimator 
	{
		get { return panelAnimator; }
	}

	public void UpdateScore(int score)
	{
		lossScoreText.text = score.ToString ();
	}

	public void DisableLossScreenObject() 
	{
		gameObject.SetActive (false);
	}

	public void Replay()
	{
		StartCoroutine ("ReplayCoroutine");
	}

	private IEnumerator ReplayCoroutine()
	{
		CloseLossScreen ();

		yield return new WaitForSeconds (0.45f);

		SceneManager.LoadScene ("Game");
	}

	private void CloseLossScreen()
	{
		panelAnimator.SetTrigger ("Close");
	}
}
