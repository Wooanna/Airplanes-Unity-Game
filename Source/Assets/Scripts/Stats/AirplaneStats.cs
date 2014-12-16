using UnityEngine;
using System.Collections;

public class AirplaneStats : ElementStats {

	public int SmokeHealthBorder = 80;
	public int FireHealthBorder = 40;

	public GameObject fireSystem;
	public GameObject smokeSystem;

	void Start()
	{
		this.fireSystem = transform.FindChild ("FireSystem").FindChild("Fire").gameObject;
		this.smokeSystem = transform.FindChild ("FireSystem").FindChild("Smoke").gameObject;
	}

    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, Screen.width / 3, 25), health + "/" + MaxHealth);
        GUI.Box(new Rect(10, 45, Screen.width / 3, 25), armor + "/" + maxArmor);
    }

	public override void Heal (int amount)
	{
		base.Heal (amount);

		if (health >= SmokeHealthBorder)
		{
			this.smokeSystem.SetActive(false);
		}
		
		if (health >= FireHealthBorder)
		{
			this.fireSystem.SetActive(false);
		}
	}

	public override void InflictDamage (int amount)
	{
		base.InflictDamage (amount);

		if (this.health < SmokeHealthBorder) {
			this.smokeSystem.SetActive(true);
		}

		if (this.health < FireHealthBorder) {
			this.fireSystem.SetActive(true);
		}
	}
}
