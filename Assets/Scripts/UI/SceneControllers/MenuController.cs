using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public void OnEnable()
	{
		Time.timeScale = 1.0f;
	}

	public void PlayGame() 
	{
		SceneManager.LoadScene ("Game");		
	}
}
