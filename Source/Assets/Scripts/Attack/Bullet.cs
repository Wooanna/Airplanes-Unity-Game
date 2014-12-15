using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    private const int Speed = 50;
    private const int MaxDistance = 50;

    public int damage = 15;

    private float totalDistance;
    private float currentDistance;

    void Update()
    {
        currentDistance = Time.deltaTime * Speed;
        totalDistance += currentDistance;
        if (totalDistance < MaxDistance)
        {
            transform.Translate(Vector3.forward * currentDistance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        ElementStats elementStats = collision.gameObject.GetComponent<ElementStats>();

        if (elementStats != null)
        {
            //if (collision.gameObject.name == "Player")
            //{
            //    foreach (var item in GameObject.FindGameObjectsWithTag("Bullet"))
            //    {
            //        item.name = "NeTozi";
            //    }

            //    name = "MAMICATA TI";
            //    Time.timeScale = 0;
            //}
            HandleCollision(elementStats);
        }
    }

    private void HandleCollision(ElementStats stats)
    {
        stats.InflictDamage(this.damage);
        Destroy(gameObject);
        // TODO: add a small explosion for the bullet dissapearance.
    }
}
