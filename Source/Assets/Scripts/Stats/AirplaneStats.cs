using UnityEngine;
using System.Collections;

public class AirplaneStats : ElementStats {

    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, Screen.width / 3, 25), Stats.Health + "/" + BaseStats.MaxHealth);
        GUI.Box(new Rect(10, 45, Screen.width / 3, 25), armor + "/" + maxArmor);
    }
}
