using UnityEngine;
using System.Collections;

public class ElementStats : MonoBehaviour {
    private const float MaxArmor = 200;
    public BaseStats Stats { get; set; }

    public int maxArmor = 5;
    public int armor = 5;

    public ElementStats()
    {
        Stats = new BaseStats();
    }

    public void Heal(int amount)
    {
        Stats.AdjustHealth(amount);
    }

    public void IncreaseArmor(int ammount)
    {
        this.maxArmor += ammount;
        if (maxArmor > MaxArmor)
        {
            maxArmor = (int)MaxArmor;
        }
    }

    public void RepairArmor(int amount)
    {
        this.armor += amount;
        if (armor > maxArmor)
        {
            armor = maxArmor;
        }
    }

    public void InflictDamage(int amount)
    {
        if (gameObject.tag == "Player")
        {
            Debug.Log(amount);
        }
        Stats.AdjustHealth(-(AdjustedDamage(amount)));
        armor -= amount >> 3;
        if (armor < 0)
        {
            armor = 0;
        }
        if (Stats.Health <= 0)
        {
            Destroy(gameObject); // TODO: add explosion or something
        }
    }

    private int AdjustedDamage(int amount)
    {
        return (int)(amount * (1 - (armor / MaxArmor)));
    }
}