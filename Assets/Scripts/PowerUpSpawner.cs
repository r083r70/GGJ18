﻿using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {
    public PowerUp[] powerUp;

    public float minDeltaSpawnTime;
    private float deltaSpawnTime;

    public Transform piccione;
    public float xDistanceSpawn;
    public float minY, maxY;

    public float spawnProbability;

    private void Start() {
        deltaSpawnTime = 0f;
    }

    private void Update() {
        deltaSpawnTime += Time.deltaTime;
        if (deltaSpawnTime >= minDeltaSpawnTime)
            CreatePowerUp();
    }

    private void CreatePowerUp() {
        Vector3 initialPosition = piccione.position + Vector3.right * xDistanceSpawn;
        initialPosition.y = Random.Range(minY, maxY);
        if (Random.value <= spawnProbability)
            Instantiate(powerUp[Random.Range(0, powerUp.Length)], initialPosition, Quaternion.identity);
        deltaSpawnTime = 0f;
    }
}
