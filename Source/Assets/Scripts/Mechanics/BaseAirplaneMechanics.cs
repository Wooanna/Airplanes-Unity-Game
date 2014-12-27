using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public abstract class BaseAirplaneMechanics : MonoBehaviour {

    protected Transform airplane;
    Rigidbody airplaneRigidbody;
    float velocityX;
    float velocityY;
    float accelerationVelocity;
    float steerAngle = 10;
    float accelerationAngle = 3;
    Quaternion initialRotation;

    /// <summary>
    /// The responsive factor when a movement was invoked either by the player or the AI and it is currently not invoking
    /// the same movement or the opposite one (Plane was going left, now it is not going left or right).
    /// </summary>
    public float responsivenessUnmanaged = 2;

    /// <summary>
    /// The responsive factor when a movement was invoked either by the player or the AI and it is currently invoking
    /// the opposite one (Plane was going left, now it is going right).
    /// </summary>
    public float responsivenessManaged = 2;

    float speedModifier;

    public int speed = 10;

    int maxAccelerationSpeed = 10; // TODO: To be updated along with any speed changes.
    int minAccelerationSpeed = 5; // TODO: To be updated along with any speed changes.

    Vector3 direction;

    void Awake()
    {
        airplane = gameObject.transform;
        airplaneRigidbody = gameObject.rigidbody;
        initialRotation = airplane.rotation;

        Init();
    }

    protected virtual void Init(){}

    void FixedUpdate()
    {
        if (!airplaneRigidbody.useGravity)
        {
            if (accelerationVelocity > 0)
            {
                speedModifier = (accelerationVelocity * maxAccelerationSpeed) * Time.deltaTime;
            }
            else if (accelerationVelocity < 0)
            {
                speedModifier = (accelerationVelocity * minAccelerationSpeed) * Time.deltaTime;
            }
            else
            {
                speedModifier = 0;
            }

            direction = new Vector3(airplane.right.x * velocityX, airplane.up.y * velocityY, airplane.forward.z + speedModifier);

            airplaneRigidbody.velocity = (direction * speed);

            airplane.rotation = initialRotation;
            airplane.Rotate(-airplane.forward, steerAngle * velocityX, Space.World);
            airplane.Rotate(-airplane.right, (steerAngle * velocityY) + (-accelerationAngle * accelerationVelocity), Space.World);
        }
    }

    protected void SpeedUp()
    {
        accelerationVelocity = Mathf.Min(accelerationVelocity + (responsivenessManaged * Time.deltaTime), 1F);
    }

    protected void SlowDown()
    {
        accelerationVelocity = Mathf.Max(accelerationVelocity - (responsivenessManaged * Time.deltaTime), -1F);
    }

    protected void KeepConstantSpeed()
    {
        if (accelerationVelocity > 0)
        {
            accelerationVelocity = Mathf.Max(accelerationVelocity - (responsivenessUnmanaged * Time.deltaTime), 0);
        }
        else if (accelerationVelocity < 0)
        {
            accelerationVelocity = Mathf.Min(accelerationVelocity + (responsivenessUnmanaged * Time.deltaTime), 0);
        }
    }

    protected void GoUp()
    {
        velocityY = Mathf.Min(velocityY + (responsivenessManaged * Time.deltaTime), 1F);
    }

    protected void GoDown()
    {
        velocityY = Mathf.Max(velocityY - (responsivenessManaged * Time.deltaTime), -1F);
    }

    protected void KeepCenterVertical()
    {
        if (velocityY > 0)
        {
            velocityY = Mathf.Max(velocityY - (responsivenessUnmanaged * Time.deltaTime), 0F);
        }
        else if (velocityY < 0)
        {
            velocityY = Mathf.Min(velocityY + (responsivenessUnmanaged * Time.deltaTime), 0F);
        }
    }

    protected void GoRight()
    {
        velocityX = Mathf.Min(velocityX + (responsivenessManaged * Time.deltaTime), 1F);
    }

    protected void GoLeft()
    {
        velocityX = Mathf.Max(velocityX - (responsivenessManaged * Time.deltaTime), -1F);
    }

    protected void KeepCenterHorizontal()
    {
        if (velocityX > 0)
        {
            velocityX = Mathf.Max(velocityX - (responsivenessUnmanaged * Time.deltaTime), 0F);
        }
        else if (velocityX < 0)
        {
            velocityX = Mathf.Min(velocityX + (responsivenessUnmanaged * Time.deltaTime), 0F);
        }
    }
}
