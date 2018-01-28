using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HudLife : MonoBehaviour {
    private Image image;
    public Sprite[] images;
    static private HudLife instance;
    static public HudLife Instance {
        get { return instance; }
    }

    private void Start() {
        if (instance)
            Destroy(gameObject);
        else
            instance = this;

        image = GetComponent<Image>();
    }

    static public HudLife getInstance() {
        return instance;
    }

    public void ChangeImage(int lifes) {
        image.sprite = images[lifes];
    }
}
