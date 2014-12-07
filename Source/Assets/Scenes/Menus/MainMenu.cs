using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 70, 70, 30), "Play"))
        {
            Application.LoadLevel("Levels");
        }
        else if (GUI.Button(new Rect(10, 110, 70, 30), "Options"))
        {
            Application.LoadLevel("Options");
        }
        else if (GUI.Button(new Rect(10, 150, 70, 30), "Quit"))
        {
            Application.Quit();
        }
    }
}
