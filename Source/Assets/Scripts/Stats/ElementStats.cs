using UnityEngine;
using System.Collections;

public class ElementStats : MonoBehaviour {

    public int scorePoints;
    public int gold;
    public int fuel = 100;
    float flashTime = .2f;
    float currentFlashTime;
    float fuelUsageTime = 1;
    bool isHurt;

    public Color hurtColor = new Color(1, 0, 0, .35f);
    Color initialColor;

    private bool dead;
    public const int MaxArmor = 200;
	public const int MaxHealth = 100;
	public const int MinHealth = 0;
    public const int MaxFuel = 100;
    Material modelMaterial;

	protected int health = 100;

    public int maxArmor = 5;
    public int armor = 5;

    void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        modelMaterial = transform.FindChild("model").renderer.material;
        this.initialColor = modelMaterial.color;
    }

    void Update()
    {
        if (isHurt)
        {
            if (currentFlashTime > 0)
            {
                modelMaterial.color = Color.Lerp(hurtColor, initialColor, 1 - (currentFlashTime / flashTime));
                
                currentFlashTime -= Time.deltaTime;
            }
            else
            {
                isHurt = false;
                modelMaterial.color = initialColor;
            }
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

        OnArmourChanged();
    }

    protected virtual void OnArmourChanged()
    {
    }

    protected virtual void OnFuelChanged()
    { 
    }

    public void RepairArmor(int amount)
    {
        this.armor += amount;
        if (armor > maxArmor)
        {
            maxArmor = armor;
            if (maxArmor > MaxArmor) {
                maxArmor = MaxArmor;
                armor = maxArmor;
            }
        }

        OnArmourChanged();
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

    int adjustedDamage;
    public virtual void InflictDamage(int amount)
    {
        if (this.dead)
        {
            return;
        }

        adjustedDamage = -(AdjustedDamage(amount));
        AdjustHealth(adjustedDamage);

        armor += adjustedDamage / 3;
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
        else
        {
            OnArmourChanged();
            modelMaterial.color = this.hurtColor;
            currentFlashTime = flashTime;
            isHurt = true;
        }
    }

    private int AdjustedDamage(int amount)
    {
        return (int)(amount * (1 - (armor / (float)MaxArmor)));
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

    internal void AdjustFuel(int ammount)
    {
        this.fuel += ammount;

        if (this.fuel < 0) {
            this.fuel = 0;
        }
        if (this.fuel > MaxFuel) {
            this.fuel = MaxFuel;
        }
        OnFuelChanged();
    }

    protected void UseFuel() 
    {
        if (Time.deltaTime % fuelUsageTime == 0) {
            AdjustFuel(-3);
        }
    }
}