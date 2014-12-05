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
}
