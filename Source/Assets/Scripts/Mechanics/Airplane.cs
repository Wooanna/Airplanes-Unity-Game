using UnityEngine;
using System.Collections;

public class Airplane : BaseAirplaneMechanics
{

    public new void Awake()
    {
        base.Awake();

        initialRotation = airplane.rotation;
    }
        
    public void Update()
    {
        HandleInput();
    }

	protected override void ApplyAngle ()
	{
		airplane.Rotate(transform.right, currentAngle);
		airplane.Rotate(-transform.forward, tiltAngle);
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
