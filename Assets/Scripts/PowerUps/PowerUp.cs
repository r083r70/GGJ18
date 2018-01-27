using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player"))
            PowerUpEffect(other.GetComponent<Piccione>());
        gameObject.SetActive(false);
    }

    protected abstract void PowerUpEffect(Piccione p);
}
