using UnityEngine;

public class EnemyPlane : BaseAirplaneMechanics
{
    private int[] directions = new int[] { DirectionLeft, DirectionUp, DirectionRight, DirectionDown };
    private float redirectTime;

    public new void Awake()
    {
        base.Awake();
        direction = ChooseDirection();
        initialRotation = airplane.rotation;
    }

	protected override void ApplyAngle ()
	{
		airplane.Rotate(transform.right, currentAngle);
		airplane.Rotate(transform.forward, tiltAngle);
	}
    
    public void Update()
    {
        HandleMovement();    
    }

    private void HandleMovement()
    {

        if (Time.time >= redirectTime)
        {
            redirectTime = RedirectTime();
            direction = ChooseDirection();

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
                GoLeft();
            }
            else if (direction == DirectionRight)
            {
                GoRight();
            }
        }
    }

    private int ChooseDirection()
    {
        return directions[Random.Range(0, directions.Length)];
    }

    private float RedirectTime()
    {
        return Time.time + Random.Range(0, 3);
    }
}
