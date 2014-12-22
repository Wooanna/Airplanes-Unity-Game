using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private const int Speed = 50;

    public int damage = 15;

    void Start()
    {
        rigidbody.AddForce(transform.forward * Speed, ForceMode.VelocityChange);
        Destroy(gameObject, 2);
    }

    void OnCollisionEnter(Collision collision)
    {
        ElementStats elementStats = collision.gameObject.GetComponent<ElementStats>();

        if (elementStats != null)
        {
            HandleCollision(elementStats);
        }

        Destroy(gameObject);
    }

    private void HandleCollision(ElementStats stats)
    {
        stats.InflictDamage(this.damage);
        // TODO: add a small explosion for the bullet dissapearance.
    }
}
