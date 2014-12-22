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
        if (Input.GetAxisRaw("Acceleration") > 0)
        {
            SpeedUp();
        }
        else if (Input.GetAxisRaw("Acceleration") < 0)
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
        else if (Input.GetAxisRaw("Vertical") == 0)
        {
            this.decreaseVerticalSpeed = true;
        }
        else
        {
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                GoUp();
            }
            else if (Input.GetAxisRaw("Vertical") < 0)
            {
                GoDown();
            }
            
        }

        //horizontal movement
        if (this.decreaseHorizontalSpeed)
        {
            DecreaseHorizontalSpeed();
        }
        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            this.decreaseHorizontalSpeed = true;
        }
        else
        {
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                GoLeft();
            }
            else if (Input.GetAxisRaw("Horizontal") > 0)
            {
                GoRight();
            }
        }
    }
}
