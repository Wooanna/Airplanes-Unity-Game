using UnityEngine;
using System.Collections;

public class Airplane : BaseAirplaneMechanics
{

    public void Awake()
    {
        base.Awake();
        initialRotation = airplane.rotation;
        space = Space.World;
    }
        
    public void Update()
    {
        HandleInput();
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
            if (Input.GetKey(KeyCode.DownArrow))
            {
                GoUp();
            }
            else if (Input.GetKey(KeyCode.UpArrow))
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
