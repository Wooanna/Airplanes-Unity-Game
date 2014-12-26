using UnityEngine;
using System.Collections;

public class Bonus : MonoBehaviour
{
    public int damage;
    public int heal;
    public int armor;
    public int fuel;
    public int bullets;
    public bool playerOnly;
    public bool random;

    void OnTriggerEnter(Collider collision)
    {
        HandleCollision(collision.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        HandleCollision(collision.gameObject);
    }

    void HandleCollision(GameObject other)
    {
        if (playerOnly && other.tag != "Player")
        {
            return;
        }

        ElementStats stats = other.GetComponent<ElementStats>();
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
            if (this.fuel > 0) 
            {
                stats.LoadFuel(this.fuel);
            }
            if (this.bullets > 0)
            {
                stats.ReloadBullets(this.bullets);
            }
        }







        gameObject.SetActive(false);
    }
}
