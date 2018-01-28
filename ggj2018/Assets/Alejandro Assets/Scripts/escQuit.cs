using UnityEngine;
using System.Collections;

public class escQuit : MonoBehaviour 

{
    void Update () 
    {
        if (Input.GetKey("escape"))
            Application.Quit();
        
    }
}
