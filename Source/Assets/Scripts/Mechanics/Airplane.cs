using UnityEngine;
using System.Collections;

public class Airplane : BaseAirplaneMechanics
{
    //private Transform mainCamera;

    public void Awake()
    {
        base.Awake();
        //mainCamera = Camera.main.transform;
        initialRotation = airplane.rotation;
        space = Space.World;
    }
        
    public void Update()
    {
        // Reset rotation
       
        base.Update();
        //mainCamera.Translate(forewardMovement, Space.World);

        // TODO: Add the side movement at a later stage.
        HandleInput();

        // TODO: Apply side rotation.
    }

    private void HandleInput()
    {
        if (Input.GetKey(KeyCode.X))
        {
            SpeedUp();
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            SlowDown();
        }
        else
        {
            NormalizeSpeed();
        }

        //vertical movement
        if (this.decreaseVerticalSpeed)
        {
            DecreaseVerticalSpeed();
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            this.decreaseVerticalSpeed = true;
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                GoUp();
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                GoDown();
            }
            
        }

        //horizontal movement
        if (this.decreaseHorizontalSpeed)
        {
            DecreaseHorizontalSpeed();
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            this.decreaseHorizontalSpeed = true;
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                GoLeft();
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                GoRight();
            }
        }
    }
}
