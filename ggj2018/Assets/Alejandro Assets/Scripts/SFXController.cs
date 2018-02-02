using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour {

	public AudioSource soundPlayer; 
	public AudioClip pop; 
	public AudioClip chipsUp; 
	public AudioClip chipsDown; 
	public AudioClip fork;
	public AudioClip splash; 

	public AudioClip victory; 
	public AudioClip pickUpChimes; 
	public AudioClip pickUpSynth1;
	public AudioClip pickUpSynth2;
	public AudioClip pickUpSynth3;

	public AudioSource rumbleLoop; 

	private float victoryRumbleTimer;
	private float victoryTimerThresh = 2.0f;
	private bool victoryTimerRunning;



	void Update () 
	{
		if(victoryTimerRunning)
		{
			print(victoryRumbleTimer);
			victoryRumbleTimer += Time.deltaTime;
			if(victoryRumbleTimer >= victoryTimerThresh)
			{
				rumbleLoop.Play();
				victoryTimerRunning = false; 
			}
		}
	}

	public void playPickupSynth(int synthNo)
	{
		soundPlayer.volume = 0.85f;
		if(synthNo == 0)
		{
			soundPlayer.PlayOneShot(pickUpSynth1);
		} else if(synthNo == 1)
		{
			soundPlayer.PlayOneShot(pickUpSynth2);
		} else if(synthNo == 2)
		{
			soundPlayer.PlayOneShot(pickUpSynth3);
		}
		soundPlayer.volume = 1.0f;
	}




	public void playRumble()
	{
		//rumbleLoop.Play();
	}

	public void playVictory()
	{
		soundPlayer.volume = 0.35f;
		soundPlayer.PlayOneShot(victory);
		victoryTimerRunning = true;
		soundPlayer.volume = 1.0f;
	}

	public void playSplash()
	{
		soundPlayer.PlayOneShot(splash);
	}

	public void playFork()
	{
		soundPlayer.PlayOneShot(fork);
	}

	public void playChips (bool upDown)
	{
		if(upDown)
		{
			soundPlayer.PlayOneShot(chipsUp);
		} else 
		{
			soundPlayer.PlayOneShot(chipsDown);
		}
	}


	public void playPop()
	{
		soundPlayer.pitch = Random.Range(0.9f, 1.2f);
		soundPlayer.PlayOneShot(pop);
		soundPlayer.pitch = 1.0f;
	}
}
