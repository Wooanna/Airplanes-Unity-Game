using UnityEngine;
using System.Collections;

public class CollisionDamage : MonoBehaviour
{

    public int Damage { get; set; }
    ElementStats stats;

    void Start()
    {
        stats = (ElementStats)GetComponent("ElementStats");
        Damage = 20;
    }

    void OnTriggerEnter(Collider other)
    {
        ElementStats stats = other.gameObject.GetComponent<ElementStats>();
        if (stats != null)
        {
            stats.InflictDamage(this.Damage);
            Destroy(gameObject);
        }
    }
}
