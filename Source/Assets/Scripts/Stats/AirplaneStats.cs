using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AirplaneStats : BaseAirplaneStats {

    public Slider healthSlider;
    public Slider armourSlider;
    public Text scoreText;
    public Text armourText;
    public Text fuelText;
    public int fuel = 100;
    public const int MaxFuel = 100;
    private AirplaneAttack attack;

    protected override void Init()
    {
        base.Init();
        this.attack = GetComponent<AirplaneAttack>();
        this.armourText.text = armor.ToString();
        this.fuelText.text = fuel.ToString();
        StartCoroutine(UseFuel());
    }

    public override void AddGold(int gold)
    {
        base.AddGold(gold);

        // Update UI
    }

    protected override void OnArmourChanged()
    {
        this.armourSlider.value = armor / (float)maxArmor;
        this.armourText.text = maxArmor.ToString();
    }

    protected override void OnFuelChanged() {
        this.fuelText.text = fuel.ToString();
    }

    public override void AddScore(int score)
    {
        base.AddScore(score);

        // Update UI
        this.scoreText.text = this.scorePoints.ToString();
    }

    public override void InflictDamage(int amount)
    {
        base.InflictDamage(amount);
    }

    public override void LoadFuel(int ammount)
    {
        this.fuel += ammount;

        if (this.fuel < 0)
        {
            this.fuel = 0;
        }
        if (this.fuel > MaxFuel)
        {
            this.fuel = MaxFuel;

        }
        OnFuelChanged();
    }

    private IEnumerator UseFuel()
    {
        while (this.fuel > 0)
        {
            yield return new WaitForSeconds(3);
            this.fuel -= 3;
            OnFuelChanged();
        }
        if (this.fuel <= 0)
        {
            this.fuel = 0;
            transform.gameObject.rigidbody.useGravity = true;
        }

    }
    public override void ReloadBullets(int count)
    {
        this.attack.bulletsLoaded += count;
    }

    protected override void AdjustHealth(int ammount)
    {
        base.AdjustHealth(ammount);

        if (ammount < 0)
        {
            // flash red
        }

        this.healthSlider.value = health / (float)MaxHealth;
    }

    protected override void Die()
    {
        base.Die();

        transform.FindChild("CamPos").gameObject.transform.parent = null;
    }
}
