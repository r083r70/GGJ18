using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {
    public PowerUp[] powerUp;

    public float minDeltaSpawnTime;
    private float deltaSpawnTime;

    public Transform piccione;
    public float xDistanceSpawn;
    public float minY, maxY;

    private void Start() {
        deltaSpawnTime = 0f;
    }

    private void Update() {
        if (!piccione)
            return;

        deltaSpawnTime += Time.deltaTime;
        if (deltaSpawnTime >= minDeltaSpawnTime)
            CreatePowerUp();
    }

    private void CreatePowerUp() {
        Vector3 initialPosition = piccione.position + Vector3.right * xDistanceSpawn;
        initialPosition.y = Random.Range(minY, maxY);
        PhotonNetwork.Instantiate(powerUp[Random.Range(0, powerUp.Length)].name, initialPosition, Quaternion.identity, 0);
        deltaSpawnTime = 0f;
    }

    public void setTarget(Transform transform) {
        piccione = transform;
    }
}
