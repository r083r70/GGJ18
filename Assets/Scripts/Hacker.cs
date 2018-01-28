using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : Photon.MonoBehaviour
{
    public GameObject obstaclePrefab;

	// Use this for initialization
	void Update () {
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            Debug.Log("Hacker obstacle");
            PhotonNetwork.Instantiate(obstaclePrefab.name, InputToEvent.inputHitPos + new Vector3(0, 5f, 0), Quaternion.identity, 0);
        }
    }
	
	// Update is called once per frame
	public void OnObstacleTouch () {
        
    }
}
