using UnityEngine;
using System.Collections;

public class BulletEngine : MonoBehaviour
{

    public Transform startingPosition;
    public float shootForce;
    public GameObject bullet;
    GameObject instanceBullet;
    public float angle;

    void Start()
    {
        startingPosition = gameObject.transform;
        bullet = (GameObject)Resources.Load("Bullet");
        shootForce = 2000;

    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Fire();
        }
    }

    private void Fire()
    {
        GameObject airplane = GameObject.Find("Airplane");

        Airplane script = (Airplane)airplane.GetComponent(typeof(Airplane));
        Vector3 currentDirection = script.GetCurrentDirection();
        angle = script.GetAirplaneAngle();
        //Debug.Log(angle);
        //Debug.Log(currentDirection);
        //this should be the right direction for the force applied to the bullet. Unfortunatelly the directions are messed!! :)
       // Vector3 dir = Quaternion.AngleAxis(angle, Vector3.forward) * currentDirection;
           
        instanceBullet = (GameObject)Instantiate(bullet, startingPosition.position, startingPosition.rotation);
        //instanceBullet.rigidbody.AddForce(dir * shootForce);
        instanceBullet.rigidbody.AddForce(Vector3.forward * shootForce);

        Destroy(instanceBullet, 3);
    }

}
