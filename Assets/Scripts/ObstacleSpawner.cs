using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {
    public Obstacle obstacle;

    public float minDeltaSpawnTime;
    private float deltaSpawnTime;

    public int minNum = 0, maxNum = 2;

    public Transform piccione;
    public float xDistanceSpawn;
    public float minY, maxY;

    void Start () {
        deltaSpawnTime = 0f;
    }
	
	void Update () {
        deltaSpawnTime += Time.deltaTime;
        if (deltaSpawnTime >= minDeltaSpawnTime)
            CreateObstacle();
    }

    private void CreateObstacle() {
        Vector3 initialPosition = piccione.position + Vector3.right * xDistanceSpawn;

        switch(UnityEngine.Random.Range(minNum, maxNum + 1)) {
            case 0: break;
            case 1:
                initialPosition.y = Random.Range(minY, maxY);
                var k = Instantiate(obstacle, initialPosition, Quaternion.identity);
                break;
            case 2:
                initialPosition.y = Random.Range(minY, 0);
                Instantiate(obstacle, initialPosition, Quaternion.identity);
                initialPosition.y = Random.Range(0, maxY);
                Instantiate(obstacle, initialPosition, Quaternion.identity);
                break;
        }
        deltaSpawnTime = 0f;
    }
}
