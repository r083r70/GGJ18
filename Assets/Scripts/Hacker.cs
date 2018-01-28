using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {
    public GameObject obstaclePrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnObstacleTouch () {
        PhotonNetwork.Instantiate(obstaclePrefab.name, InputToEvent.inputHitPos + new Vector3(0, 5f, 0), Quaternion.identity, 0);
    }
}
