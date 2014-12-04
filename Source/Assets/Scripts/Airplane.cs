using UnityEngine;
using System.Collections;

public class Airplane : MonoBehaviour
{
    private const int DirectionLeft = 1;
    private const int DirectionUp = 1 << 1;
    private const int DirectionRight = 1 << 2;
    private const int DirectionDown = 1 << 3;

    private const int ConstantSpeed = 5;
    private const int SpeedModifierChangeStep = 25;
    private const int MinSpeedModifier = -2;
    private const int MaxSpeedModifier = 5;
    private const int MaxModifiedHorizontalAngle = 5;
    private const int MaxHorizontalAngle = 15;

    private const int MaxSpeed = 5;
    private const int SpeedChangeStep = 25;
    private float currentSpeed;
    private bool decreaseSpeed;

    private int upperBorder = 6;
    private int lowerBorder = -6;

    private int currentHorizontalAngle;

    private int direction;
    public AirplaneStats stats;

    private float speedModifier;

    private Transform airplane;
    private Transform mainCamera;

    void Awake()
    {
        airplane = gameObject.transform;
        mainCamera = Camera.main.transform;
    }

    private Vector3 forewardMovement;
    void Update()
    {
        // Reset rotation
        this.currentHorizontalAngle = 0;
        airplane.rotation = Quaternion.AngleAxis(0, Vector3.right);

        forewardMovement = Vector3.forward * (Time.deltaTime * (ConstantSpeed + this.speedModifier));

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

    private void UpdateHorizontalAngle()
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

    private void HandleDirectionalMovement()
    {
        if (this.direction > 0)
        {
            if ((this.direction & DirectionUp) > 0)
            {
                this.airplane.Translate(Vector3.up * (currentSpeed * Time.deltaTime), Space.World);
            }
            else if ((this.direction & DirectionDown) > 0)
            {
                this.airplane.Translate(Vector3.down * (currentSpeed * Time.deltaTime), Space.World);
            }
        }
    }

    private void HandleInput()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            speedModifier += SpeedModifierChangeStep * Time.deltaTime;
            if (speedModifier > MaxSpeedModifier)
            {
                speedModifier = MaxSpeedModifier;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            speedModifier -= SpeedModifierChangeStep * Time.deltaTime;
            if (speedModifier < MinSpeedModifier)
            {
                speedModifier = MinSpeedModifier;
            }
        }
        else
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

        if (this.decreaseSpeed)
        {
            currentSpeed -= SpeedChangeStep * Time.deltaTime;
            if (currentSpeed <= 0)
            {
                currentSpeed = 0;
                this.decreaseSpeed = false;
            }
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            this.decreaseSpeed = true;
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (airplane.position.y > upperBorder)
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
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                if (airplane.position.y < lowerBorder)
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
        }
    }
}
