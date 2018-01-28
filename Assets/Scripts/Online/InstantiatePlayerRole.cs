using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePlayerRole : Photon.PunBehaviour {
    public string pegeout = "Piccione";
    public GameObject hackerPrefab;
    public GameObject pegeoutPrefabHUD;
    public Vector3 pegeoutInitPosition;

    private GameObject pegeoutHUD;

    // Update is called once per frame
    public override void OnJoinedRoom() {
        base.OnJoinedRoom();

        GameObject canvas = GameObject.Find("Canvas");

        if (PhotonNetwork.countOfPlayers == 1) {
            var k = PhotonNetwork.Instantiate(pegeout, pegeoutInitPosition, Quaternion.Euler(0, 90, 0), 0);

            //pegeoutHUD = Instantiate(pegeoutPrefabHUD, pegeoutPrefabHUD.transform, true);
            //pegeoutHUD.transform.SetParent(canvas.transform, false);
            //pegeoutHUD.GetComponentInChildren<HudPowerUp>().piccione = k.GetComponent<Piccione>();
        } else {
            GameObject hacker = Instantiate(hackerPrefab, hackerPrefab.transform, true);
            hacker.transform.SetParent(canvas.transform, false);
            //Camera.main.fieldOfView = 115f;
        }


    }

    private void Update() {
        GameObject piccione = GameObject.FindGameObjectWithTag("Player");
        if (piccione == null) {
            return;
        }
        CameraManager cameraManager = Camera.main.GetComponent<CameraManager>();
        cameraManager.setTarget(piccione.transform);
        PowerUpSpawner powerUpSpawner = GetComponentInParent<PowerUpSpawner>();
        powerUpSpawner.setTarget(piccione.transform);
        ObstacleSpawner obstacleSpawner = GetComponentInParent<ObstacleSpawner>();
        obstacleSpawner.setTarget(piccione.transform);

        Destroy(gameObject);
    }
}
