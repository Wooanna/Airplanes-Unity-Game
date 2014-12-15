using UnityEngine;
using System.Collections;

public class BaseAirplaneMechanics : MonoBehaviour {

    protected const int DirectionLeft = 1;
    protected const int DirectionUp = 1 << 1;
    protected const int DirectionRight = 1 << 2;
    protected const int DirectionDown = 1 << 3;

    public int constantSpeed = 5;
    protected const int SpeedModifierChangeStep = 25;
    protected const int MinSpeedModifier = -2;
    protected const int MaxSpeedModifier = 5;
    protected const int MaxModifiedHorizontalAngle = 2;
    protected const int MaxAngle = 10;
    protected const int MaxTiltAngle = 15;

    public int maxSpeed = 5;
    protected const int SpeedChangeStep = 15;
    protected float currentVerticalSpeed;
    protected float currentHorizontalSpeed;
    protected bool decreaseVerticalSpeed;
    protected bool decreaseHorizontalSpeed;

    protected int upperBorder = 39;
    protected int lowerBorder = 1;
    protected int leftBorder = -54;
    protected int rightBorder = 54;
    
    protected int currentAngle;
    protected int tiltAngle;

    protected int direction;

    protected AirplaneStats stats;

    protected float speedModifier;

    protected Transform airplane;

    protected Quaternion initialRotation;

    protected Space space;

    public void Awake()
    {
        airplane = gameObject.transform;
    }

    protected Vector3 forewardMovement;

    public void FixedUpdate()
    {
        this.currentAngle = 0;
        this.tiltAngle = 0;
        airplane.rotation = initialRotation;
        forewardMovement = Vector3.forward * (Time.deltaTime * (constantSpeed + this.speedModifier));

        airplane.Translate(forewardMovement, space);
        
        HandleDirectionalMovement();
        UpdateAngle();
        airplane.Rotate(Vector3.right, currentAngle);
        airplane.Rotate(Vector3.back, tiltAngle);
    }

    protected void SpeedUp() 
    {
        speedModifier += SpeedModifierChangeStep * Time.deltaTime;
        if (speedModifier > MaxSpeedModifier)
        {
            speedModifier = MaxSpeedModifier;
        }
    
    }

    protected void SlowDown() 
    {
        speedModifier -= SpeedModifierChangeStep * Time.deltaTime;
        if (speedModifier < MinSpeedModifier)
        {
            speedModifier = MinSpeedModifier;
        }
    }

    protected void NormalizeSpeed()
    {
        if (speedModifier < 0)
        {
            speedModifier += SpeedModifierChangeStep * Time.deltaTime;
            if (speedModifier > 0)
            {
                speedModifier = 0;
            }
        }
        else if (speedModifier > 0)
        {
            speedModifier -= SpeedModifierChangeStep * Time.deltaTime;
            if (speedModifier < 0)
            {
                speedModifier = 0;
            }
        }
    }

    protected void UpdateAngle()
    {
        if (currentVerticalSpeed > 0)
        {
            if ((direction & DirectionUp) > 0)
            {
                currentAngle -= (int)((currentVerticalSpeed / maxSpeed) * MaxAngle);
            }
            else if ((direction & DirectionDown) > 0)
            {
                currentAngle += (int)((currentVerticalSpeed / maxSpeed) * MaxAngle);
            }

        }

        if (currentHorizontalSpeed > 0)
        {
            if ((direction & DirectionLeft) > 0)
            {
                tiltAngle -= (int)((currentHorizontalSpeed / maxSpeed) * MaxTiltAngle);
            }
            else if ((direction & DirectionRight) > 0)
            {
                tiltAngle += (int)((currentHorizontalSpeed / maxSpeed) * MaxTiltAngle);
            }
        }

        if (this.speedModifier > 0)
        {
            currentAngle += (int)((speedModifier / MaxSpeedModifier) * MaxModifiedHorizontalAngle);
        }
        else if (this.speedModifier < 0)
        {
            currentAngle += (int)((speedModifier / -MinSpeedModifier) * MaxModifiedHorizontalAngle);
        }
    }


    protected void HandleDirectionalMovement()
    {
        if (this.direction > 0)
        {
            if ((this.direction & DirectionUp) > 0)
            {
                this.airplane.Translate(Vector3.up * (currentVerticalSpeed * Time.deltaTime), Space.World);
            }
            else if ((this.direction & DirectionDown) > 0)
            {
                this.airplane.Translate(Vector3.down * (currentVerticalSpeed * Time.deltaTime), Space.World);
            }

            if ((this.direction & DirectionLeft) > 0)
            {
                this.airplane.Translate(Vector3.left * (currentHorizontalSpeed * Time.deltaTime), Space.World);
            }
            else if ((this.direction & DirectionRight) > 0)
            {
                this.airplane.Translate(Vector3.right * (currentHorizontalSpeed * Time.deltaTime), Space.World);
            }
        }
    }

    protected void GoDown() 
    {
        if (airplane.position.y < lowerBorder)
        {
            decreaseVerticalSpeed = true;
        }
        else
        {
            currentVerticalSpeed += SpeedChangeStep * Time.deltaTime;
            if (currentVerticalSpeed > maxSpeed)
            {
                currentVerticalSpeed = maxSpeed;
            }

            this.direction &= ~DirectionUp;
            this.direction |= DirectionDown;
        }
    }

    protected void GoUp()
    {
        if (airplane.position.y > upperBorder)
        {
            decreaseVerticalSpeed = true;
        }
        else
        {
            currentVerticalSpeed += SpeedChangeStep * Time.deltaTime;
            if (currentVerticalSpeed > maxSpeed)
            {
                currentVerticalSpeed = maxSpeed;
            }

            this.direction &= ~DirectionDown;
            this.direction |= DirectionUp;
        }
    }

    protected void GoLeft()
    {
        if (airplane.position.x < leftBorder)
        {
            decreaseHorizontalSpeed = true;
        }
        else 
        {
            currentHorizontalSpeed += SpeedChangeStep * Time.deltaTime;
            if (currentHorizontalSpeed > maxSpeed)
            {
                currentHorizontalSpeed = maxSpeed;
            }

            this.direction |= DirectionLeft;
            this.direction &= ~DirectionRight;
        }
    }

    protected void GoRight() 
    {
        if (airplane.position.x > rightBorder)
        {
            decreaseHorizontalSpeed = true;
        }
        else
        {
            currentHorizontalSpeed += SpeedChangeStep * Time.deltaTime;
            if (currentHorizontalSpeed > maxSpeed)
            {
                currentHorizontalSpeed = maxSpeed;
            }

            this.direction |= DirectionRight;
            this.direction &= ~DirectionLeft;
        }
    }

    protected void DecreaseVerticalSpeed()
    {
        currentVerticalSpeed -= SpeedChangeStep * Time.deltaTime;
        if (currentVerticalSpeed <= 0)
        {
            currentVerticalSpeed = 0;
            this.decreaseVerticalSpeed = false;
        }
    }

    protected void DecreaseHorizontalSpeed()
    {
        currentHorizontalSpeed -= SpeedChangeStep * Time.deltaTime;
        if (currentHorizontalSpeed <= 0)
        {
            currentHorizontalSpeed = 0;
            this.decreaseHorizontalSpeed = false;
        }
    }
}
