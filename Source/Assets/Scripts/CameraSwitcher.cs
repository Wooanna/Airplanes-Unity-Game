using UnityEngine;
using System.Collections;

public class CameraSwitcher : MonoBehaviour {

    public Camera airplaneCamera;
    public Camera rearCamera;
	void Update () {
        if (Input.GetKeyUp(KeyCode.Q)) {
            if (airplaneCamera.enabled == true)
            {
                airplaneCamera.enabled = false;
                rearCamera.enabled = true;
            }
            else 
            {
                rearCamera.enabled = false;
                airplaneCamera.enabled = true;
            }
        }
	}
}
