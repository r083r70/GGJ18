using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HudLife : MonoBehaviour {
    private Image image; 
    public Sprite[] images;

	private void Start () {
        image = GetComponent<Image>();
	}
	
	public void ChangeImage(int lifes) {
        image.sprite = images[lifes];
    }
}
