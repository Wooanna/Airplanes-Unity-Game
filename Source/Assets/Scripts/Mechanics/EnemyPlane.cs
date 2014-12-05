using UnityEngine;
using System.Collections;
using System;

public class EnemyPlane : BaseAirplaneMechanics
{

    private System.Random random = new System.Random();
    private int[] directions = new int[] { DirectionLeft, DirectionUp, DirectionRight, DirectionDown };
    private float redirectTime; 

    public void Awake()
    {
        base.Awake();

        direction = ChooseDirection();
    }

    public void Update()
    {
        base.Update();
        airplane.Translate(forewardMovement, Space.Self);
        HandleMovement();
        HandleDirectionalMovement();
        UpdateHorizontalAngle();
    }

    private void HandleMovement()
    {

        if (Time.time >= redirectTime)
        {
            redirectTime = RedirectTime();
            direction = ChooseDirection();
            Debug.Log("Redirect time " + redirectTime + "------ Time:" + Time.time);

            if (direction == DirectionDown)
            {

                GoDown();
            }
            else if (direction == DirectionUp)
            {
                GoUp();
            }
            else if (direction == DirectionLeft)
            {
                //GoLeft();
            }
            else if (direction == DirectionRight)
            {
                //GoRight();
            }
        }
    }

    private int ChooseDirection()
    {
        return directions[random.Next(directions.Length)];
    }

    private float RedirectTime()
    {
        return Time.time + random.Next(3);
    }
}
