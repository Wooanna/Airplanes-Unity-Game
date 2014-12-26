using UnityEngine;
using System.Collections;

public abstract class BasePlayerMechanics : BaseAirplaneMechanics
{
    float inputX;
    float inputY;
    float inputAcceleration;

    void Update()
    {
        inputX = GetHorizontalAxis();
        inputY = GetVerticalAxis();
        inputAcceleration = GetAccelerationAxis();

        if (inputX > 0)
        {
            GoRight();
        } else if (inputX < 0)
        {
            GoLeft();
        } else
        {
            KeepCenterHorizontal();
        }
        
        if (inputY > 0)
        {
            GoUp();
        } else if (inputY < 0)
        {
            GoDown();
        } else
        {
            KeepCenterVertical();
        }
        
        if (inputAcceleration > 0)
        {
            SpeedUp();
        } else if (inputAcceleration < 0)
        {
            SlowDown();
        } else
        {
            KeepConstantSpeed();
        }
    }

    protected abstract float GetHorizontalAxis();
    protected abstract float GetVerticalAxis();
    protected abstract float GetAccelerationAxis();

    protected override void ApplyRotation()
    {
        airplane.Rotate(-airplane.forward, steerAngle * velocityX);
        airplane.Rotate(-airplane.right, (steerAngle * velocityY) + (-accelerationAngle * accelerationVelocity));
    }
}
