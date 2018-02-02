using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameTimer : MonoBehaviour {

	private float endTimer, endTimerThresh = 3.0f;
	public string nameOfLevelToLoad; 


	void Start () 
	{
		
	}
	

	void Update () 
	{
		endTimer += Time.deltaTime;
		if(endTimer >= endTimerThresh)
		{
			if(Input.anyKey)
			{
				//fade out and THEN reset the game 
				SceneManager.LoadScene(nameOfLevelToLoad, LoadSceneMode.Single);
			}
		}
	}
}
