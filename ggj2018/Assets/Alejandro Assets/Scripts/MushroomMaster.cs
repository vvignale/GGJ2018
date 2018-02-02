using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomMaster : MonoBehaviour {

	public SFXController sfxController; 
	public Rigidbody[] shroomRigids; 

	public ParticleSystem[] dustParticles; 
	private Vector3 randomTorque;
	private int torqueX, torqueY, torqueZ, currentShroom; 

	private float releaseTimer, timerThresh = 0.2f, popTimer; 
	private bool released, donePopping; 



	void Start () {
		
	}
	

	void Update () 
	{
		torqueX = Random.Range(-180, 180);
		torqueY = Random.Range(-180, 180);
		torqueZ = Random.Range(-180, 180);

		if (Input.GetKeyDown("space"))
		{
			//releaseShrooms();
		}

		if(released)
		{
			releaseTimer += Time.deltaTime;
			if(releaseTimer >= timerThresh && currentShroom < shroomRigids.Length)
			{
				shroomRigids[currentShroom].isKinematic = false; 
				shroomRigids[currentShroom].AddForce(0, 10, 0, ForceMode.Impulse);
				shroomRigids[currentShroom].AddTorque(torqueX, torqueY, torqueZ);
				sfxController.playPop();
				dustParticles[currentShroom].transform.parent = null; 
				dustParticles[currentShroom].Play();
				currentShroom ++;
				releaseTimer = 0.0f;
			} else if (currentShroom >= shroomRigids.Length)
			{
				//all have been popped; 
				Animator shroomAnim = GetComponent<Animator>(); 
				shroomAnim.SetBool("jiggle", false);
				donePopping = true; 
			}
		}

		if(donePopping)
		{
			sfxController.rumbleLoop.Stop();
			popTimer += Time.deltaTime; 
			if(popTimer >= 3.0f && popTimer < 3.25f) //how long off
			{
				toggleShrooms(false);
			} else if (popTimer >= 3.25f && popTimer < 3.5f) //how long on 
			{
				toggleShrooms(true);
			} else if (popTimer >= 3.5f && popTimer < 3.75f)
			{
				toggleShrooms(false);
			} else if (popTimer >= 3.75f && popTimer < 4.0f)
			{
				toggleShrooms(true);
			} else if (popTimer >= 4.0f)
			{
				toggleShrooms(false);
			}
			donePopping = false;
		}

	}


	void toggleShrooms(bool onOff)
	{
		for(int i = 0; i < shroomRigids.Length; i++)
		{
			shroomRigids[i].gameObject.SetActive(onOff);
		}
	}


	public void releaseShrooms()
	{
		
		released = true; 	
//		for(int i = 0; i < shroomRigids.Length; i++)
//		{
//			shroomRigids[i].isKinematic = false;
//			shroomRigids[i].AddForce(0, 10, 0, ForceMode.Impulse);
//			shroomRigids[i].AddTorque(torqueX, torqueY, torqueZ);
//		}
	}

}
