using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour {

    public GameObject explosion;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player"))
            AddToHUD();
        gameObject.SetActive(false);
        PhotonNetwork.Instantiate(explosion.name, GetComponent<Transform>().position, Quaternion.identity, 0);
    }

    protected abstract void AddToHUD();
    public abstract void PowerUpEffect(Piccione p);
}
