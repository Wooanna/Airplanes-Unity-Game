using UnityEngine;
using System.Collections;

public class ElementStats : MonoBehaviour {

    public int scorePoints;
    public int gold;
    public float flashTime = .01f;
    float currentFlashTime;

    public Color hurtColor = new Color(1, 0, 0, .35f);
    protected Color initialColor;

    private bool dead;
    public const int MaxArmor = 200;
	public const int MaxHealth = 100;
	public const int MinHealth = 0;
    public Renderer modelRenderer;

	protected int health = 100;

    public int maxArmor = 5;
    public int armor = 5;

    public void Awake()
    {
        modelRenderer = transform.FindChild("model").renderer;
        this.initialColor = modelRenderer.material.color;
    }

    void Update()
    {
        if (currentFlashTime > 0)
        {
            modelRenderer.material.color = Color.Lerp(hurtColor, initialColor, 1 - (currentFlashTime / flashTime));

            currentFlashTime -= Time.deltaTime;
        }
    }

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

    public virtual void AddGold(int gold)
    {
        this.gold += gold;
    }

    public virtual void AddScore(int score)
    {
        this.scorePoints += score;
    }

    public bool IsDead()
    {
        return this.dead;
    }

    public virtual void InflictDamage(int amount)
    {
        if (this.dead)
        {
            return;
        }

        AdjustHealth(-(AdjustedDamage(amount)));
        armor -= amount >> 1;
        if (armor < 0)
        {
            armor = 0;
        }

		if (this.health <= 0)
        {
            this.dead = true;
            this.health = 0;
			Die();
        }

        modelRenderer.material.color = this.hurtColor;
        currentFlashTime = flashTime;
    }

    private int AdjustedDamage(int amount)
    {
        return (int)(amount * (1 - (armor / MaxArmor)));
    }

	protected virtual void AdjustHealth(int ammount)
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
		gameObject.SetActive(false);
	}
}