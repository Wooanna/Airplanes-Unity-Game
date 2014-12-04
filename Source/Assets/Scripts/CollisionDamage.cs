using UnityEngine;
using System.Collections;

public class CollisionDamage : MonoBehaviour
{

    public int damage = 20;
    private ElementStats stats;

    void Start()
    {
        stats = (ElementStats)GetComponent("ElementStats");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            return;
        }

        ElementStats stats = other.gameObject.GetComponent<ElementStats>();
        if (stats != null)
        {
            stats.InflictDamage(this.damage);
            Destroy(gameObject);
        }
    }
}
