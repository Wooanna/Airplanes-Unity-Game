using UnityEngine;
using System.Collections;

public class Airplane : BaseAirplaneMechanics
{
    float horizontalAxis;
    float verticalAxis;
    float accelerationAxis;

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
        this.horizontalAxis = Input.GetAxisRaw("Horizontal");
        this.verticalAxis = Input.GetAxisRaw("Vertical");
        this.accelerationAxis = Input.GetAxisRaw("Acceleration");

        if (this.accelerationAxis > 0)
        {
            SpeedUp();
        }
        else if (this.accelerationAxis < 0)
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
        else if (this.verticalAxis == 0)
        {
            this.decreaseVerticalSpeed = true;
        }
        else
        {
            if (this.verticalAxis > 0)
            {
                GoUp();
            }
            else if (this.verticalAxis < 0)
            {
                GoDown();
            }
            
        }

        //horizontal movement
        if (this.decreaseHorizontalSpeed)
        {
            DecreaseHorizontalSpeed();
        }
        else if (this.horizontalAxis == 0)
        {
            this.decreaseHorizontalSpeed = true;
        }
        else
        {
            if (this.horizontalAxis < 0)
            {
                GoLeft();
            }
            else if (this.horizontalAxis > 0)
            {
                GoRight();
            }
        }
    }
}
