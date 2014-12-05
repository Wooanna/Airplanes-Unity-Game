using UnityEngine;
using System.Collections;

public class BaseAirplaneMechanics : MonoBehaviour {

    protected const int DirectionLeft = 1;
    protected const int DirectionUp = 1 << 1;
    protected const int DirectionRight = 1 << 2;
    protected const int DirectionDown = 1 << 3;

    protected const int ConstantSpeed = 5;
    protected const int SpeedModifierChangeStep = 25;
    protected const int MinSpeedModifier = -2;
    protected const int MaxSpeedModifier = 5;
    protected const int MaxModifiedHorizontalAngle = 2;
    protected const int MaxHorizontalAngle = 10;

    protected const int MaxSpeed = 5;
    protected const int SpeedChangeStep = 15;
    protected float currentSpeed;
    protected bool decreaseSpeed;

    protected int upperBorder = 6;
    protected int lowerBorder = -6;

    protected int currentHorizontalAngle;

    protected int direction;

    protected AirplaneStats stats;

    protected float speedModifier;

    protected Transform airplane;

    public void Awake()
    {
        airplane = gameObject.transform;
    }

    protected Vector3 forewardMovement;

    public void Update()
    {
        forewardMovement = Vector3.forward * (Time.deltaTime * (ConstantSpeed + this.speedModifier));
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

    protected void UpdateHorizontalAngle()
    {
        if (currentSpeed > 0)
        {
            if ((direction & DirectionUp) > 0)
            {
                currentHorizontalAngle -= (int)((currentSpeed / MaxSpeed) * MaxHorizontalAngle);
            }
            else if ((direction & DirectionDown) > 0)
            {
                currentHorizontalAngle += (int)((currentSpeed / MaxSpeed) * MaxHorizontalAngle);
            }

        }

        if (this.speedModifier > 0)
        {
            currentHorizontalAngle += (int)((speedModifier / MaxSpeedModifier) * MaxModifiedHorizontalAngle);
        }
        else if (this.speedModifier < 0)
        {
            currentHorizontalAngle += (int)((speedModifier / -MinSpeedModifier) * MaxModifiedHorizontalAngle);
        }
    }


    protected void HandleDirectionalMovement()
    {
        if (this.direction > 0)
        {
            if ((this.direction & DirectionUp) > 0)
            {
                this.gameObject.transform.Translate(Vector3.up * (currentSpeed * Time.deltaTime), Space.World);
            }
            else if ((this.direction & DirectionDown) > 0)
            {
                this.gameObject.transform.Translate(Vector3.down * (currentSpeed * Time.deltaTime), Space.World);
            }
        }
    }

    protected void GoDown() 
    {
        if (gameObject.transform.position.y < lowerBorder)
        {
            decreaseSpeed = true;
        }
        else
        {
            currentSpeed += SpeedChangeStep * Time.deltaTime;
            if (currentSpeed > MaxSpeed)
            {
                currentSpeed = MaxSpeed;
            }

            this.direction &= ~DirectionUp;
            this.direction |= DirectionDown;
        }
    }

    protected void GoUp()
    {
        if (gameObject.transform.position.y > upperBorder)
        {
            decreaseSpeed = true;
        }
        else
        {
            currentSpeed += SpeedChangeStep * Time.deltaTime;
            if (currentSpeed > MaxSpeed)
            {
                currentSpeed = MaxSpeed;
            }

            this.direction &= ~DirectionDown;
            this.direction |= DirectionUp;
        }
    }

    protected void DecreaseSpeed()
    {
        currentSpeed -= SpeedChangeStep * Time.deltaTime;
        if (currentSpeed <= 0)
        {
            currentSpeed = 0;
            this.decreaseSpeed = false;
        }
    }
}
