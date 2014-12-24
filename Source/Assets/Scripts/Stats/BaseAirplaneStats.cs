using UnityEngine;
using System.Collections;

public class BaseAirplaneStats : ElementStats {

    public int SmokeHealthBorder = 80;
    public int FireHealthBorder = 40;
    
    GameObject fireSystem;
    GameObject smokeSystem;

	void Awake () {
        this.fireSystem = transform.FindChild ("FireSystem").FindChild("Fire").gameObject;
        this.smokeSystem = transform.FindChild ("FireSystem").FindChild("Smoke").gameObject;
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
    
    protected override void Die()
    {
        rigidbody.useGravity = true;
    }
}
