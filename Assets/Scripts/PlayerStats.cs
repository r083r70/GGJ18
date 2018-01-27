using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    
    public float Health = 100f;
    public int currentHealth;
    public Slider sliderHealth;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public Image imageDamage;
    bool isDead;
    bool damaged;

    void Update()
    {
        
        if (damaged)
        {
           
            imageDamage.color = flashColour;
        }
        
        else
        {

           
        }

      
        damaged = false;
    }

    public void TakeDamage(int amount)
    {
        
        damaged = true;

        
        currentHealth -= amount;


        sliderHealth.value = Health;

        
        

        
        if (Health <= 0 && !isDead)
        {
            
            
        }
    }

    void Dead()
    {

    }




}
