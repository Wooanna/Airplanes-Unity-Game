using UnityEngine;
using System.Collections;

public class AirplaneStats : BaseAirplaneStats {

    static int score;
    static int gold;

    public static void AddScorePoints(int points)
    {
        score += points;
    }

    public static void AddGold(int amount)
    {
        gold += amount;
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, Screen.width / 3, 25), health + "/" + MaxHealth);
        GUI.Box(new Rect(10, 45, Screen.width / 3, 25), armor + "/" + maxArmor);
        GUI.Box(new Rect(Screen.width >> 1, 10, 50, 25), score.ToString());
        GUI.Box(new Rect(Screen.width - 50, 10, 50, 25), gold.ToString());
    }
}
