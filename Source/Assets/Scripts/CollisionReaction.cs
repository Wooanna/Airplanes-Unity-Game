using UnityEngine;
using System.Collections;

public class CollisionReaction : MonoBehaviour
{

    public int damage = 20;
    public int heal = 0;
    public int armor = 0;   
 
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            return;
        }

        ElementStats stats = other.gameObject.GetComponent<ElementStats>();
        if (stats != null)
        {
            if (damage > 0)
            {
                stats.InflictDamage(this.damage);
            }
            if (heal > 0)
            {
                stats.Heal(this.heal);
            }
            if (armor > 0)
            {
                stats.RepairArmor(this.armor);
            }
           
            Destroy(gameObject);
        }
    }
}
