using UnityEngine;
using System.Collections;

public class ElementStats : MonoBehaviour {

    public BaseStats Stats { get; set; }

    public ElementStats()
    {
        Stats = new BaseStats();
    }

    public void Heal(int amount)
    {
        Stats.AdjustHealth(amount);
    }

    public void InflictDamage(int amount)
    {
        Stats.AdjustHealth(-amount); // TODO: add armor.
        if (Stats.Health <= 0)
        {
            Destroy(gameObject); // TODO: add explosion or something
        }
    }
}