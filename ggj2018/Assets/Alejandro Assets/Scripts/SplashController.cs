using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashController : MonoBehaviour {

	public AudioClip stepWet; 
	private AudioSource soundPlayer; 

	private float stepTimer, stepTimerThresh = 0.3f;
	private int totalSteps; 


	void Start () 
	{
		soundPlayer = transform.GetComponentInParent<AudioSource>(); 
	}
	

	void Update () 
	{
		if(totalSteps > 0)
		{
			stepTimer += Time.deltaTime;
			if(stepTimer >= stepTimerThresh)
			{
				soundPlayer.pitch = Random.Range(0.8f, 1.2f);
				soundPlayer.PlayOneShot(stepWet);
				stepTimer = 0.0f;
				totalSteps --; 
			}
		}

	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			soundPlayer.pitch = Random.Range(0.8f, 1.2f);
			soundPlayer.PlayOneShot(stepWet);
			totalSteps = 2; 
		}
	}
}
