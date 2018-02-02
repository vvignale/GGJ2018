using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndZone : MonoBehaviour {


	public Animator fader; 
	private float timer, timerThresh = 2.5f;
	private bool timerRunning; 
	//

	void Start () 
	{
		
	}
	

	void Update () {
		if(timerRunning)
		{
			timer += Time.deltaTime; 
			if(timer >= timerThresh)
			{
				SceneManager.LoadScene("ending", LoadSceneMode.Single);
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			//end game
			//fade out 
			fader.SetTrigger("fade in");
			timerRunning = true; 
		}
	}
}
