using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkleMaster : MonoBehaviour {

	private int randomSparkle; 
	public GameObject[] sparkles; 

	public float timeTilSparkle; 
	private float sparkleTimer; 

	void Start () 
	{
		
	}
	

	void Update () 
	{
		randomSparkle = Random.Range(0, sparkles.Length); 
		sparkleTimer += Time.deltaTime; 
		if(sparkleTimer >= timeTilSparkle)
		{
			sparkles[randomSparkle].SetActive(false);
			sparkles[randomSparkle].SetActive(true);
			sparkleTimer = 0.0f;
		}
	}
}
