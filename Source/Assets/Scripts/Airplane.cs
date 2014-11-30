using UnityEngine;
using System.Collections;

public class Airplane : MonoBehaviour
{

    public int speed;
    public int speedModifier;
    public Transform airplane;
    public int upperBound;
    public int downBound;
    public AirplaneStats stats;

    void Awake()
    {
        speed = 5;
        upperBound = 3;
        downBound = -2;
        speedModifier = 0;
        airplane = gameObject.transform;
        stats = (AirplaneStats)GetComponent("AirplaneStats");
    }

    void Update()
    {
        airplane.Translate(Vector3.forward * (Time.deltaTime * (speed + speedModifier)));

        if (Input.GetKey(KeyCode.UpArrow) && airplane.position.y < upperBound)
        {
            airplane.Translate(Vector3.up * (Time.deltaTime * speed));
        }
        else if (Input.GetKey(KeyCode.DownArrow) && airplane.position.y > downBound)
        {
            airplane.Translate(Vector3.down * (Time.deltaTime * speed));
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            airplane.Translate(Vector3.left * (Time.deltaTime * speed));
        }
        else if (Input.GetKey(KeyCode.X))
        {
            airplane.Translate(Vector3.right * (Time.deltaTime * speed));
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            speedModifier = -2;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            speedModifier = 2;
        }
        else
        {
            speedModifier = 0;
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

    public int GetAirplaneSpeed()
    {
        return speed + speedModifier;
    }
}
