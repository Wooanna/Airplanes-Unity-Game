using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AirplaneStats : BaseAirplaneStats {

    public Slider healthSlider;
    public Slider armorSlider;
    public Text scoreText;

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
