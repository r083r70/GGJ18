using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudPowerUp : MonoBehaviour {
    public PowUp[] powUps;
    public Piccione piccione;
    static private HudPowerUp instance;
    static public HudPowerUp Instance {
        get { return instance; }
    }

    private void Awake() {
        if (instance)
            Destroy(gameObject);
        else
            instance = this;
    }

    private void Start() {
        for (int i = 0; i < powUps.Length; i++) {
            powUps[i].present = false;
            powUps[i].img.SetActive(false);
        }
    }

    void Update () {
        if (Input.GetButtonDown("Fire2") && powUps[1].present) {
            powUps[1].pu.PowerUpEffect(piccione);
            powUps[1].present = false;
            powUps[1].img.SetActive(false);
        }

        if (Input.GetButtonDown("Fire3") && powUps[2].present) {
            powUps[2].pu.PowerUpEffect(piccione);
            powUps[2].present = false;
            powUps[2].img.SetActive(false);
        }

        if (Input.GetButtonDown("Fire4") && powUps[3].present) {
            powUps[3].pu.PowerUpEffect(piccione);
            powUps[3].present = false;
            powUps[3].img.SetActive(false);
        }

        if (Input.GetButtonDown("Fire1") && powUps[0].present) {
            powUps[0].pu.PowerUpEffect(piccione);
            powUps[0].present = false;
            powUps[0].img.SetActive(false);
        }
    }

    public void AddPowUp(int index, PowerUp powUp) {
        powUps[index].pu = powUp;
        powUps[index].present = true;
        powUps[index].img.SetActive(true);
    } 

    [System.Serializable]
    public struct PowUp {
        public GameObject img;
        public bool present;
        public PowerUp pu;
    }
}
