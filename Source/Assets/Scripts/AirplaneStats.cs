using UnityEngine;
using System.Collections;

public class AirplaneStats : MonoBehaviour {

    private int health = 100;
    private const int maxHealth = 100;
    private const int minHealth = 0;

    public void AdjustHealth(int ammount)
    {
        health += ammount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (health < minHealth)
        {
            health = minHealth;
        }
       
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, Screen.width / 3, 25), health + "/" + maxHealth);
    }
    
	
}
