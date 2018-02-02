using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDetect : MonoBehaviour {


	public int zoneNumber; 
	public GameObject cheetoPickup;
	public GameObject forkPickup; 
	public GameObject fishPickup; 
	public Animator fishRipple; 

	public SFXController sfxController; 

	public GameObject[] sparkles; 

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			if(zoneNumber == 0 && cheetoPickup.gameObject.activeInHierarchy)
			{
				other.GetComponent<PlayerStats>().aqumaZone = true;
				sfxController.playChips(true);
				cheetoPickup.SetActive(false);
				sparklesShine();
			} else if (zoneNumber == 1 && forkPickup.gameObject.activeInHierarchy)
			{
				other.GetComponent<PlayerStats>().amyZone = true;
				sfxController.playFork();
				forkPickup.SetActive(false);
				sparklesShine();
			} else if (zoneNumber == 2 && fishPickup.gameObject.activeInHierarchy)
			{
				other.GetComponent<PlayerStats>().veenaZone = true;
				sfxController.playSplash();
				fishPickup.SetActive(false);
				sparklesShine();
				fishRipple.SetTrigger("ripple");
			}

		}
	}

	void sparklesShine()
	{
		sfxController.playPickupSynth(zoneNumber);
		for(int i = 0; i < sparkles.Length; i++)
		{
			sparkles[i].SetActive(false);
			sparkles[i].SetActive(true);
		}

	}

}
