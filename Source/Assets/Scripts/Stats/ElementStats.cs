using UnityEngine;
using System.Collections;

public class ElementStats : MonoBehaviour {

    public int scorePoints;
    public int gold;

    private bool dead;
    public const int MaxArmor = 200;
	public const int MaxHealth = 100;
	public const int MinHealth = 0;

	protected int health = 100;

    public int maxArmor = 5;
    public int armor = 5;

    public virtual void Heal(int amount)
    {
        AdjustHealth(amount);
    }

    public void IncreaseArmor(int ammount)
    {
        this.maxArmor += ammount;
        if (maxArmor > MaxArmor)
        {
            maxArmor = MaxArmor;
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

    public bool IsDead()
    {
        return this.dead;
    }

    public virtual void InflictDamage(int amount)
    {
        AdjustHealth(-(AdjustedDamage(amount)));
        armor -= amount >> 3;
        if (armor < 0)
        {
            armor = 0;
        }

		if (this.health <= 0)
        {
            this.dead = true;
			Die();
        }
    }

    private int AdjustedDamage(int amount)
    {
        return (int)(amount * (1 - (armor / MaxArmor)));
    }

	private void AdjustHealth(int ammount)
	{
		this.health += ammount;
		if (this.health > MaxHealth)
		{
			this.health = MaxHealth;
		}
		if (this.health < MinHealth)
		{
			this.health = MinHealth;
		}
	}

	protected virtual void Die()
	{
		Destroy (gameObject, 1);
	}
}