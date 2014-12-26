using UnityEngine;
using System.Collections;

public class EnemyPlane : BaseAirplaneMechanics
{
    private const int DirectionUp = 1;
    private const int DirectionDown = 1 << 1;
    private const int DirectionLeft = 1 << 2;
    private const int DirectionRight = 1 << 3;
    private const int SpeedUpMovement = 1 << 4;
    private const int SlowDownMovement = 1 << 5;
    private int movement;

    protected override void Init()
    {
        StartCoroutine(Navigate());
    }

    void Update()
    {
        if (movement > 0)
        {
            if ((movement & DirectionUp) > 0)
            {
                GoUp();
            } else if ((movement & DirectionDown) > 0)
            {
                GoDown();
            } else
            {
                KeepCenterVertical();
            }

            if ((movement & DirectionLeft) > 0)
            {
                GoLeft();
            } else if ((movement & DirectionRight) > 0)
            {
                GoRight();
            } else
            {
                KeepCenterHorizontal();
            }

            if ((movement & SpeedUpMovement) > 0)
            {
                SpeedUp();
            } else if ((movement & SlowDownMovement) > 0)
            {
                SlowDown();
            } else
            {
                KeepConstantSpeed();
            }

        } else
        {
            KeepCenterHorizontal();
            KeepCenterVertical();
            KeepConstantSpeed();
        }
    }

    WaitForSeconds navigationCoolDown = new WaitForSeconds(4);
    float chance;

    IEnumerator Navigate()
    {
        while (true)
        {
            yield return navigationCoolDown;

            Roll();

            if (chance > 80)
            {
                movement |= DirectionLeft;
            } else if (chance > 60)
            {
                movement |= DirectionRight;
            } else
            {
                movement &= ~DirectionLeft;
                movement &= ~DirectionRight;
            }

            if (chance > 40)
            {
                movement |= DirectionUp;
            } else if (chance > 20)
            {
                movement |= DirectionDown;
            } else
            {
                movement &= ~DirectionUp;
                movement &= ~DirectionDown;
            }

            Roll();
            if (chance > 60)
            {
                movement |= SpeedUpMovement;
            } else if (chance > 30)
            {
                movement |= SlowDownMovement;
            } else
            {
                movement &= ~SlowDownMovement;
                movement &= ~SpeedUpMovement;
            }
        }
    }

    void Roll()
    {
        chance = Random.Range(0, 101);
    }

    protected override void ApplyRotation()
    {
        airplane.Rotate(airplane.forward, steerAngle * velocityX);
        airplane.Rotate(airplane.right, (steerAngle * velocityY) + (-accelerationAngle * accelerationVelocity));
    }
}
