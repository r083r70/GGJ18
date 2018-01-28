using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTime : MonoBehaviour {

    public string loadToLoad;
    private float timer = 3f;
    private Text textForSecond;



    private void Start()
    {
        textForSecond = GetComponent<Text>();
    }



    private void Update()
    {
        timer -= Time.deltaTime;
        textForSecond.text = timer.ToString("f0");
        {
            if (timer <= 0f)
            {
                Application.LoadLevel(loadToLoad); 
            }
        }




    }
}
