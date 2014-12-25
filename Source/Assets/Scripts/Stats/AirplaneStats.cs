using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AirplaneStats : BaseAirplaneStats {

    public Slider healthSlider;
    public Slider armourSlider;
    public Text scoreText;
    public Text armourText;
    public Text fuelText;

    protected override void Init()
    {
        base.Init();

        this.armourText.text = armor.ToString();
        this.fuelText.text = fuel.ToString();
    }

    public override void AddGold(int gold)
    {
        base.AddGold(gold);

        // Update UI
    }

    protected override void OnArmourChanged()
    {
        Debug.Log("On armor changed");
        this.armourSlider.value = armor / (float)maxArmor;
        this.armourText.text = maxArmor.ToString();
    }

    protected override void OnFuelChanged() {
        Debug.Log("On fuel changed");
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
