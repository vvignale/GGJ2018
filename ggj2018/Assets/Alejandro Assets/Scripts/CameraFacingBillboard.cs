using UnityEngine;

using System.Collections;

public class CameraFacingBillboard : MonoBehaviour
{
	private Camera m_Camera;
    //private Camera m_CameraMobile;
    private Camera m_CameraMobile;

    void Start() 
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            m_CameraMobile = Camera.main;
        }
        else 
        {
            m_Camera = Camera.main;
        }
    }

    void Update()
    {
    	//m_Camera = GameObject.Find ("Main Camera PC").GetComponent<Camera>();
    	if(Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.OSXPlayer)
        {
            transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.back,
            m_Camera.transform.rotation * Vector3.up);
        }

        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            //m_CameraMobile = GameObject.Find ("Main Camera Mobile").GetComponent<Camera>();
            transform.LookAt(transform.position + m_CameraMobile.transform.rotation * new Vector3 (0,0,-90),//Vector3.back,
            m_CameraMobile.transform.rotation * Vector3.up);
        }
    /* 
    #if UNITY_ANDROID || UNITY_IPHONE || UNITY_IOS
        m_CameraMobile = GameObject.Find ("Main Camera Mobile").GetComponent<Camera>();
        transform.LookAt(transform.position + m_CameraMobile.transform.rotation * Vector3.back,
        m_CameraMobile.transform.rotation * Vector3.up);

    #endif
    */
    }



}
