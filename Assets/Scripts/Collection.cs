using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collection : MonoBehaviour {


    
    
    
    public float multiplier = 1.4f;
    public Text countText;
    
    
   
    int count;

    private void Start()
    {
        count = 0;
        

        
        SetCountText();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
    }

   void SetCountText()
    {
        countText.text = "" + count.ToString();
        if (count >= 4)
        {
            
           //aggiunge 4 powerUp, e bisogna finire la funzione con l input che usa i powerups

        }
    }

   
   


}
