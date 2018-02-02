using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public ShrineController shrineController; 
	public MushroomMaster mushroomMaster; 
	public PlayerStats playerStats; 
	int mushroomMask = 1 << 8;
	int shrineMask = 1 << 9;

	public bool lookingAtShrine;
	private float lookingAtResetTimer; 
	private float lookingAtResetTimerThresh = 5.0f; 



	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		Vector3 fwd = transform.TransformDirection (Vector3.forward);
		RaycastHit hit;

		if (Physics.Raycast (transform.position, fwd, out hit, Mathf.Infinity, mushroomMask))
		{
			//looking at mushrooms 
			if(shrineController.readyToReleaseShrooms)
			{
				mushroomMaster.releaseShrooms();
			}

		}

		if (Physics.Raycast (transform.position, fwd, out hit, Mathf.Infinity, shrineMask))
		{
			//looking at shrine 
			lookingAtShrine = true;
		}

		if(lookingAtShrine)
		{
			lookingAtResetTimer += Time.deltaTime; 
			if(lookingAtResetTimer >= lookingAtResetTimerThresh)
			{
				lookingAtResetTimer = 0.0f;
				lookingAtShrine = false; 

			}
		}
	}
}
