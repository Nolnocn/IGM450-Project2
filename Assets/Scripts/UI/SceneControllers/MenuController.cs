using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public void PlayGame() 
	{
		SceneManager.LoadScene ("Game");		
	}
}
