using UnityEngine;
using System.Collections;

public class MoveXYZ : MonoBehaviour {

//	public float xSpeed; 
//	public float ySpeed;
	
	public Vector3 xyzSpeed; 

	public bool moving; 

	void Start () 
	{
	
	}
	

	void Update () 
	{
		if(moving)
		{
			//transform.Translate(new Vector3(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, 0));
			transform.Translate(new Vector3(xyzSpeed.x, xyzSpeed.y, xyzSpeed.z) * Time.deltaTime);
		}

	}
}
