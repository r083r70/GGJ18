using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HudLife : MonoBehaviour {
    private Image image; 
    public Sprite[] images;
    static private HudLife instance;

	private void Start () {
        if (instance == null)
        {
            instance = this;
        }

        image = GetComponent<Image>();
	}

    static public HudLife getInstance()
    {
        return instance;
    }
	
	public void ChangeImage(int lifes) {
        image.sprite = images[lifes];
    }
}
