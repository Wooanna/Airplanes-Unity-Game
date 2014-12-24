using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private const int Speed = 150;
    private Transform bullet;
    public int damage = 15;
    public bool affectsScore;

    void Awake()
    {
        this.bullet = gameObject.transform;
        Destroy(gameObject, 2);
    }

    void FixedUpdate()
    {
        this.bullet.Translate(this.bullet.forward * Time.deltaTime * Speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        HandleCollision(collision.gameObject);
    }

    void OnTriggerEnter(Collider collider)
    {
        HandleCollision(collider.gameObject);
    }

    private void HandleCollision(GameObject hitTarget)
    {
        ElementStats elementStats = hitTarget.GetComponent<ElementStats>();
        
        if (elementStats != null && !elementStats.IsDead())
        {
            elementStats.InflictDamage(this.damage);
            // TODO: add a small explosion for the bullet dissapearance.
            
            if (elementStats.IsDead())
            {
                //AirplaneStats.AddGold(elementStats.gold);
                //AirplaneStats.AddScorePoints(elementStats.scorePoints);
            }
        }
        
        Destroy(gameObject);
    }
}
