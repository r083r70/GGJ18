using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {
    public Piccione piccio;
    public GameObject pickupEffect;
    public float multiplier = 1.4f;
    public float duration = 4f;
    PowerUpsaType PowerUpsaTypeTake;

    enum PowerUpsaType {
        slowDown,
        fireWall,
        highQuality,
        compression,
    }

    private void Start() {
        piccio = GetComponent<Piccione>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {

            switch (PowerUpsaTypeTake) {
                case PowerUpsaType.slowDown:
                    //piccio.speed /= multiplier;
                    break;
                case PowerUpsaType.fireWall:
                    break;
                case PowerUpsaType.compression:
                    break;
                default:
                    piccio.transform.localScale *= multiplier;
                    break;
            }
            other.gameObject.SetActive(false);
        }
    }
}

