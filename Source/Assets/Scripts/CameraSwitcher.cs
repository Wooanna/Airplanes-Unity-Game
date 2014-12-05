using UnityEngine;
using System.Collections;

public class CameraSwitcher : MonoBehaviour {

    Quaternion initialRotation;
    public Camera airplaneCamera;
    public Camera rearCamera;
    public Transform rearCameraTransform;

    void Start()
    {
        rearCameraTransform = rearCamera.transform;
        this.initialRotation = rearCameraTransform.rotation;

    }

	void Update () {

        rearCameraTransform.rotation = initialRotation;

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
