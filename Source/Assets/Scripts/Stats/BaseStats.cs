using UnityEngine;
using System.Collections;

public class BaseStats {

    public int Health { get; private set; }
    
    public const int MaxHealth = 100;
    public const int MinHealth = 0;

    public BaseStats()
    {
        Health = MaxHealth;
    }

    public void AdjustHealth(int ammount)
    {
        Health += ammount;
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
        if (Health < MinHealth)
        {
            Health = MinHealth;
        }

    }
}
