using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrineController : MonoBehaviour {

	public SFXController sfxController; 
	public Animator mushroomAnim; 
	public GameObject bowl1Fish;
	public GameObject bowl2Fork;
	public GameObject bowl3Cheetos; 
	private PlayerStats playerStats; 

	public PlayerController playerController; 
	public bool readyToReleaseShrooms; 
	private bool shroomStop; 

	private float miniTimer, miniTimerThresh = 1.0f, miniFishTimer = 1.2f, miniForkTimer = 1.4f, miniCheetoTimer = 1.6f, miniVictoryTimer = 1.0f; 
	private bool miniTimerRunning; 



	void Start () 
	{
		
	}
	

	void Update () 
	{
		if(bowl1Fish.activeInHierarchy && bowl2Fork.activeInHierarchy && bowl3Cheetos.activeInHierarchy)
		{
			if(!shroomStop)
			{
				miniTimer += Time.deltaTime;
				if(miniTimer >= miniVictoryTimer)
				{
					sfxController.playVictory();
					//sfxController.rumbleLoop.Play(); now this is done on SFXController, using a delay timer 
					mushroomAnim.SetBool("jiggle", true); //jiggle the mushrooms 
					shroomStop = true; //lock this section so it only turns true once
				}


			}
			//conditions met, pop out the mushrooms 

			readyToReleaseShrooms = true;
		}
	}


	void OnTriggerStay(Collider other) //this is checking if player is in zone and if they're looking at the shrine, and if they've got offerings. then show offerings in shrine
	{
		if(other.gameObject.tag == "Player") //if player is standing in the zone
		{
			if(playerController.lookingAtShrine) //and player is looking at the shrine 
			{
				playerStats = other.gameObject.GetComponent<PlayerStats>();
				if(playerStats.amyZone) //&& visited amy zone 
				{
					if(!bowl2Fork.activeInHierarchy) //if fork in bowl is inactive, activate and play sound 
					{
						//miniTimerSequence(1);

						bowl2Fork.SetActive(true);
						sfxController.playFork();
					}

				}
				if(playerStats.aqumaZone)
				{
					if(!bowl3Cheetos.activeInHierarchy) //if cheetos in bowl is inactive, activate and play sound 
					{
					//	miniTimerSequence(2);
						sfxController.playChips(false);
						bowl3Cheetos.SetActive(true);
					}

				}
				if(playerStats.veenaZone)
				{
					if(!bowl1Fish.activeInHierarchy) //if fish in bowl is inactive, activate and play sound 
					{
					//	miniTimerSequence(0);
						sfxController.playSplash();
						bowl1Fish.SetActive(true);
					}

				}

				//pause a second 
				//on enter, check how many are full, go in order 

			}
		}
	}

	void miniTimerSequence(int itemToDrop)
	{
		if(miniTimerRunning)
		{
			miniTimer += Time.deltaTime; 
			if(miniTimer >= miniTimerThresh)
			{
				if(itemToDrop == 0)
				{
					sfxController.playSplash();
					bowl1Fish.SetActive(true);
				} else if(itemToDrop == 1)
				{
					bowl2Fork.SetActive(true);
					sfxController.playFork();
				} else if (itemToDrop == 2)
				{
					sfxController.playChips(false);
					bowl3Cheetos.SetActive(true);
				}

				miniTimerRunning = false; 
			}
		}
	}
}
