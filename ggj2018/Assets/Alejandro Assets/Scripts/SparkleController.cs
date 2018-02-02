using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkleController : MonoBehaviour {


	private float randomLife; 
	public float lifeMin,lifeMax, timer;
	private bool starRunning; 

	private float starSize; 
	private float starGrowSpeedMin = 0.5f, starGrowSpeedMax = 1.2f; 
	private float randomGrowSpeed; 
	private bool growing; 

	void Start () 
	{
		
	}
	

	void Update () 
	{
		transform.localScale = new Vector3(starSize, starSize, starSize);
		if(starRunning)
		{
			if(growing)
			{
				//grow
				starSize += Time.deltaTime * randomGrowSpeed;
			} else 
			{
				starSize -= Time.deltaTime * randomGrowSpeed;
				if(starSize < 0.0f)
				{
					
					timer = 0.0f; 
					starSize = 0.0f;
					starRunning = false;
				}
			}



			timer += Time.deltaTime; 
			if(timer >= randomLife)
			{
				//shrink
				if(growing)
				{
					growing = false; 
					timer = 0.0f; 
				} else  //this is when growing is false, star is done shrinking, this star is done for now. 
				{
					timer = 0.0f;
					starSize = 0.0f;
					starRunning = false; 
				}
			}
		} else 
		{
			starSize = 0.0f;
		}
	}

	void OnEnable()
	{
		transform.localScale = new Vector3(0,0,0); 	
		randomGrowSpeed = Random.Range(starGrowSpeedMin, starGrowSpeedMax);

		randomLife = Random.Range(lifeMin, lifeMax);
		starRunning = true;
		growing = true; 

	}
}
