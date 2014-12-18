using UnityEngine;
using System.Collections;

public class CollisionReaction : MonoBehaviour
{

    public int damage;
    public int heal;
    public int armor;
    public bool playerOnly;
    public bool random;
    
    void OnCollisionEnter(Collision collision)
    {
        if (playerOnly && collision.gameObject.tag != "Player")
        {
            return;
        }

        ElementStats stats = collision.gameObject.GetComponent<ElementStats>();
        if (stats != null)
        {
            if (this.random)
            {
                if (Random.Range(0, 101) > 10)
                {
                    damage = 0;
                }
                if (damage > 0 || Random.Range(0, 101) < 15)
                {
                    armor = 0;
                }

                if (damage > 0 || Random.Range(0, 101) < 10)
                {
                    this.heal = 0;
                }
            }

            CollisionReaction otherCollision = collision.gameObject.GetComponent<CollisionReaction>();
            int collisionDamage = 0;
            if (otherCollision != null)
            {
                collisionDamage = otherCollision.damage;
            }
            
            if (this.armor > 0)
            {
                stats.RepairArmor(this.armor);
            }
            if (this.heal > 0)
            {
                stats.Heal(this.heal);
            }
            if (this.damage > 0)
            {
                stats.InflictDamage(this.damage);
            }

            if (collisionDamage > 0)
            {
                ElementStats selfStats = GetComponent<ElementStats>();
                if (selfStats != null)
                {
                    selfStats.InflictDamage(damage);
                }
            }
        }
    }
}
