using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour {

	private bool isTriggered;
	private Vector3 target;
	private Vector3 startingPos; 
	private Vector3 prevPos; 
	private float speed; 
	private float radius; 
	private float angle; 

	// Use this for initialization
	void Start () {
		//target = null; 
		isTriggered = false; 
		startingPos = gameObject.transform.position; 
		speed = 1f;
		radius = 2f; 
		angle = 0; 

	}
	
	// Update is called once per frame
	void Update () {

		if (!isTriggered){
			// move in circles
			angle += speed * Time.deltaTime; 

			gameObject.transform.position = new Vector3 (Mathf.Cos (angle)*radius+startingPos.x, startingPos.y, Mathf.Sin (angle)*radius+startingPos.z);

			gameObject.transform.Rotate (0, angle%180, 0);

		}

		
	}
}
