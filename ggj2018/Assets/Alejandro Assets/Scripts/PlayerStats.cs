using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public bool amyZone; 
	public bool aqumaZone; 
	public bool veenaZone, done; 

	public bool placedAmy;
	public bool placedAquma;
	public bool placedVeena; 

	void Start () 
	{
		
	}
	

	void Update () 
	{
//		if(placedAmy && placedAquma && placedVeena)
//		{
//			done = true; 
//		}
	}

	public void placeAmy()
	{
		if(amyZone)
		{
			//&& player looks at zone
			placedAmy = true; 
			//make the fork active 
		}
	}


}
