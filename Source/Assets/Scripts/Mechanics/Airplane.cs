using UnityEngine;
using System.Collections;

public class Airplane : BaseAirplaneMechanics
{
    
    private Transform mainCamera;

    public void Awake()
    {
        base.Awake();
        mainCamera = Camera.main.transform;
    }
        
    public void Update()
    {
        // Reset rotation
        this.currentHorizontalAngle = 0;
        airplane.rotation = Quaternion.AngleAxis(0, Vector3.right);

        base.Update();
        
        airplane.Translate(forewardMovement, Space.World);
        mainCamera.Translate(forewardMovement, Space.World);

        // TODO: Add the side movement at a later stage.
        HandleInput();

        HandleDirectionalMovement();
        UpdateHorizontalAngle();

        // Apply updated rotation
        airplane.Rotate(Vector3.right, currentHorizontalAngle);

        // TODO: Apply side rotation.
    }

    
    

    private void HandleInput()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            SpeedUp();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            SlowDown();
        }
        else
        {
            NormalizeSpeed();
        }

        if (this.decreaseSpeed)
        {
            DecreaseSpeed();
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            this.decreaseSpeed = true;
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
    }
}
