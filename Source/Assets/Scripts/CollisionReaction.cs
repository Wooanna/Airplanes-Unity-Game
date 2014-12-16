﻿using UnityEngine;
using System.Collections;

public class CollisionReaction : MonoBehaviour
{

    public int damage;
    public int heal;
    public int armor;

	public bool random;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            return;
        }

        ElementStats stats = other.gameObject.GetComponent<ElementStats>();
        if (stats != null)
        {
            CollisionReaction otherCollision = other.gameObject.GetComponent<CollisionReaction>();
            int damage = 0;
            if (otherCollision != null)
            {
                damage = otherCollision.damage;
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

            if (damage > 0)
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
