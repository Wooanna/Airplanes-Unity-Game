using UnityEngine;
using System.Collections;

public class AirplaneStats : BaseAirplaneStats {

    static int playerScore;
    static int playerGold;

    public static void AddScorePoints(int points)
    {
        playerScore += points;
    }

    public static void AddGold(int amount)
    {
        playerGold += amount;
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, Screen.width / 3, 25), health + "/" + MaxHealth);
        GUI.Box(new Rect(10, 45, Screen.width / 3, 25), armor + "/" + maxArmor);
        GUI.Box(new Rect(Screen.width >> 1, 10, 50, 25), playerScore.ToString());
        GUI.Box(new Rect(Screen.width - 50, 10, 50, 25), playerGold.ToString());
    }

    protected override void Die()
    {
        base.Die();

        transform.FindChild("CamPos").gameObject.transform.parent = null;
    }
}
