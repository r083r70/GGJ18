using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePlayerRole : Photon.PunBehaviour {
    public string pegeout = "piccione";
    public GameObject hackerPrefab;
    public GameObject pegeoutPrefabHUD;
    public Vector3 pegeoutInitPosition;

    private GameObject pegeoutHUD;

    // Update is called once per frame
    public override void OnJoinedRoom() {
        base.OnJoinedRoom();

        GameObject canvas = GameObject.Find("Canvas");

        if (PhotonNetwork.countOfPlayers == 1)
        {
            pegeoutHUD = Instantiate(pegeoutPrefabHUD, pegeoutPrefabHUD.transform, true);
            pegeoutHUD.transform.SetParent(canvas.transform, false);


            PhotonNetwork.Instantiate(pegeout, pegeoutInitPosition, Quaternion.identity, 0);
        }
        else
        {
            GameObject hacker = Instantiate(hackerPrefab, hackerPrefab.transform, true);
            hacker.transform.SetParent(canvas.transform, false);
            Camera.main.fieldOfView = 115f;
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
