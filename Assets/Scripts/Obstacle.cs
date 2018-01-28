using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public GameObject explosion;

	public void Explode() {
        gameObject.SetActive(false);
        PhotonNetwork.Instantiate(explosion.name, GetComponent<Transform>().position, Quaternion.identity, 0);
    }
}
