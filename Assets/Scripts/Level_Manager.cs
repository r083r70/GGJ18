using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour {

	
   public  void LoadLevel(string name)
    {
        Application.LoadLevel(name);
    }
    
   public void NextLevel()
    {

        Application.LoadLevel(Application.loadedLevel + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
