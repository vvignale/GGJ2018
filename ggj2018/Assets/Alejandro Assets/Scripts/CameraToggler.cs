using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraToggler : MonoBehaviour {

	public string levelToLoad; 
	public GameObject[] cameras; 
	public Vector3[] camStartPos;
	private int currentCam, previousCam; 
	public float camThresh = 3.0f, camTimer, anyKeyTimer, anyKeyThresh = 7.0f, controlsThresh = 5.0f; 
	public GameObject fishObj, controlsUI;

	public Animator anyKeyAnim;

	private bool blinkCheck; 

	void Start () 
	{
		for(int i = 0; i < camStartPos.Length; i++)
		{
			camStartPos[i] = cameras[i].transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		camTimer += Time.deltaTime; 
		if(camTimer >= camThresh)
		{
			previousCam = currentCam; 

			cameras[previousCam].SetActive(false);
			if(currentCam < cameras.Length - 1) //change camera
			{
				currentCam ++;
			} else if (currentCam >= cameras.Length - 1)
			{
				currentCam = 0;
			}
			if(currentCam == 3)
			{
				fishObj.SetActive(true);
			} else 
			{
				fishObj.SetActive(false);
			}

			cameras[currentCam].transform.position = camStartPos[currentCam];
			cameras[currentCam].SetActive(true);
			camTimer = 0.0f;


		}

		anyKeyTimer += Time.deltaTime;
		if(anyKeyTimer >= controlsThresh)
		{
			controlsUI.SetActive(true);
		}

		if(anyKeyTimer >= anyKeyThresh)
		{
			if(Input.anyKey)
			{
				//flash press any key 
				SceneManager.LoadScene(levelToLoad, LoadSceneMode.Single);
				//fade to black would be nice
			}

			if(!blinkCheck)
			{
				anyKeyAnim.SetTrigger("blink");
			}
		}



	}
}
