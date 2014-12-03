using UnityEngine;
using System.Collections;

public class Airplane : MonoBehaviour
{

    public float topSpeed;
    public float currentSpeed;
    public int speedStep;
    public Transform airplane;
    public int upperBound;
    public int downBound;
    public AirplaneStats stats;
    public int currentAngle;
    public int maxAngle = 25;
    private int rotationAngle = 90;
    GameObject bullet;
    bool decreaseSpeed = false;
    Vector3 currentDirection;
    private float airplaneAngle;

    void Awake()
    {
        topSpeed = 10f;
        currentSpeed = 0f;
        speedStep = 15;
        upperBound = 6;
        downBound = -4;
        airplane = gameObject.transform;
        stats = (AirplaneStats)GetComponent("AirplaneStats");
    }

   
    void Update()
    {
        airplane.Translate(Vector3.forward * (Time.deltaTime * (GetAirplaneSpeed())), Space.World);

        if (Input.GetKeyUp(KeyCode.UpArrow) ||
            Input.GetKeyUp(KeyCode.LeftArrow) ||
            Input.GetKeyUp(KeyCode.DownArrow) ||
            Input.GetKeyUp(KeyCode.RightArrow) ||
            Input.GetKeyUp(KeyCode.Z) ||
            Input.GetKeyUp(KeyCode.X))
        {
            decreaseSpeed = true;
        }
        else if (!decreaseSpeed && Input.GetKey(KeyCode.UpArrow) && airplane.position.y < upperBound)
        {
            currentSpeed += Time.deltaTime * speedStep;
            if (currentSpeed > topSpeed)
            {
                currentSpeed = topSpeed;
            }

            currentDirection = Vector3.up;
        }

        else if (!decreaseSpeed && Input.GetKey(KeyCode.DownArrow) && airplane.position.y > downBound)
        {
            currentSpeed += Time.deltaTime * speedStep;
            if (currentSpeed > topSpeed)
            {
                currentSpeed = topSpeed;
            }
            currentDirection = Vector3.down;
        }

        if (!decreaseSpeed && Input.GetKey(KeyCode.Z))
        {
            currentSpeed += Time.deltaTime * speedStep;
            if (currentSpeed > topSpeed)
            {
                currentSpeed = topSpeed;
            }
            currentDirection = Vector3.left;
        }
        else if (!decreaseSpeed && Input.GetKey(KeyCode.X))
        {
            currentSpeed += Time.deltaTime * speedStep;
            if (currentSpeed > topSpeed)
            {
                currentSpeed = topSpeed;
            }
            currentDirection = Vector3.right;
        }
        else if (!decreaseSpeed && Input.GetKey(KeyCode.LeftArrow))
        {
            currentSpeed += Time.deltaTime * speedStep;
            if (currentSpeed > topSpeed)
            {
                currentSpeed = topSpeed;
            }
            currentDirection = Vector3.forward;
            airplane.Translate(Vector3.left * (Time.deltaTime * currentSpeed), Space.World);
        }
        else if (!decreaseSpeed && Input.GetKey(KeyCode.RightArrow))
        {
            currentSpeed += Time.deltaTime * speedStep;
            if (currentSpeed > topSpeed)
            {
                currentSpeed = topSpeed;
            }
            currentDirection = Vector3.back;
            airplane.Translate(Vector3.right * (Time.deltaTime * currentSpeed), Space.World);
        }
              
        if (decreaseSpeed)
        {
            currentSpeed -= Time.deltaTime * (speedStep );

            if (currentSpeed <= 0)
            {
                currentSpeed = 0;
                decreaseSpeed = false;
                currentDirection = Vector3.zero;
            }
        }

        if (currentDirection != Vector3.zero)
        {
            if (currentDirection == Vector3.up)
            {
                airplaneAngle =(currentSpeed / 2 / (float)topSpeed) * maxAngle;
                airplane.rotation = Quaternion.AngleAxis(airplaneAngle, Vector3.left);
                airplane.Translate(currentDirection * (Time.deltaTime * currentSpeed), Space.World);

            }
            else if (currentDirection == Vector3.down)
            {
                airplaneAngle = (currentSpeed / 2 / (float)topSpeed) * maxAngle;
                airplane.rotation = Quaternion.AngleAxis(airplaneAngle, Vector3.right);
                airplane.Translate(currentDirection * (Time.deltaTime * currentSpeed), Space.World);

            }
            else if (currentDirection == Vector3.left || currentDirection == Vector3.right)
            {
                airplaneAngle = (currentSpeed / 4 / (float)topSpeed) * maxAngle;
                airplane.rotation = Quaternion.AngleAxis(airplaneAngle, currentDirection);
                
            }
            else if (currentDirection == Vector3.forward)
            {
                airplane.rotation = Quaternion.AngleAxis((currentSpeed / 2 / (float)topSpeed) * maxAngle, currentDirection);
                airplane.rotation = Quaternion.AngleAxis((currentSpeed / 4 / (float)topSpeed) * rotationAngle, Vector3.down);
                airplane.Translate(currentDirection * (Time.deltaTime * currentSpeed), Space.World);

            }
            else if (currentDirection == Vector3.back)
            {
             airplane.rotation = Quaternion.AngleAxis((currentSpeed / 2 / (float)topSpeed) * maxAngle, currentDirection);
                airplane.rotation = Quaternion.AngleAxis((currentSpeed / 4 / (float)topSpeed) * rotationAngle, Vector3.up);
                airplane.Translate(currentDirection * (Time.deltaTime * currentSpeed), Space.World);
            }

        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            //game over
        }
        else if (other.tag == "Enemy")
        {
            stats.AdjustHealth(((CollisionDamage)other.GetComponent("CollisionDamage")).GetDamage() * -1);
            Destroy(other.gameObject);
        }
    }

    public float GetAirplaneSpeed()
    {
        return topSpeed + currentSpeed;
    }

    public float GetAirplaneAngle()
    {
        return airplaneAngle;

    }

    internal Vector3 GetCurrentDirection()
    {
        return currentDirection;
    }
}
