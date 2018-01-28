using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePlayerRole : Photon.PunBehaviour {
    public string pegeout = "piccione";
    public Vector3 pegeoutInitPosition;


    // Update is called once per frame
    public override void OnJoinedRoom() {
        base.OnJoinedRoom();

        Debug.Log("OnJoinedLobby");

        if (PhotonNetwork.countOfPlayers == 1)
        {
            PhotonNetwork.Instantiate(pegeout, pegeoutInitPosition, Quaternion.identity, 0);

        }
        else
        {
            Camera.main.fieldOfView = 115f;
            Debug.Log("Rompicoglioni");
        }

        
    }

    private void Update()
    {
        GameObject piccione = GameObject.FindGameObjectWithTag("Player");
        if (piccione == null)
        {
            return;
        }
        CameraManager cameraManager = Camera.main.GetComponent<CameraManager>();
        cameraManager.setTarget(piccione.transform);
        PowerUpSpawner powerUpSpawner = Camera.main.GetComponent<PowerUpSpawner>();
        powerUpSpawner.setTarget(piccione.transform);

        Destroy(gameObject);
    }
}
