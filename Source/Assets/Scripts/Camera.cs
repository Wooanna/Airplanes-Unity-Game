using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour
{
    public Airplane airplane;

    void Start()
    {
        airplane = ((Airplane)GameObject.FindGameObjectWithTag("Player").GetComponent("Airplane"));
    }

    void Update()
    {
        gameObject.transform.Translate(Vector3.right * Time.deltaTime * airplane.GetAirplaneSpeed());
    }
}
