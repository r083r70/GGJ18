using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name)
    {
        Application.LoadLevel(name);
    }

    void NextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    void QuitGame()
    {
        Application.Quit();
    }

}
