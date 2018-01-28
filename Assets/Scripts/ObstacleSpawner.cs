using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {
    public Obstacle obstacle;

    public float minDeltaSpawnTime;
    private float deltaSpawnTime;

    private int creationIndex;

    public int minNum = 0, maxNum = 2;

    public Transform piccione;
    public float xDistanceSpawn;
    public float minY, maxY;

    void Start () {
        deltaSpawnTime = 0f;
        creationIndex = 0;
    }
	
	void Update () {
        deltaSpawnTime += Time.deltaTime;
        if (deltaSpawnTime >= minDeltaSpawnTime)
            CreateObstacle();
    }

    private void CreateObstacle() {
        Vector3 initialPosition = piccione.position + Vector3.right * xDistanceSpawn;
        creationIndex += 1;

        if (creationIndex % 4 != 0)
            switch (UnityEngine.Random.Range(minNum, maxNum + 1)) {
                case 0: break;
                case 1:
                    initialPosition.y = Random.Range(minY, maxY);
                    var k = Instantiate(obstacle, initialPosition, Quaternion.identity);
                    break;
                case 2:
                    initialPosition.y = Random.Range(minY, -0.3f);
                    Instantiate(obstacle, initialPosition, Quaternion.identity);
                    initialPosition.y = Random.Range(0.3f, maxY);
                    Instantiate(obstacle, initialPosition, Quaternion.identity);
                    break;
                case 3:
                    initialPosition.y = Random.Range(minY, -1.1f);
                    Instantiate(obstacle, initialPosition, Quaternion.identity);
                    initialPosition.y = Random.Range(-1.1f, 1.1f);
                    Instantiate(obstacle, initialPosition, Quaternion.identity);
                    initialPosition.y = Random.Range(1.1f, maxY);
                    Instantiate(obstacle, initialPosition, Quaternion.identity);
                    break;
            }
        deltaSpawnTime = 0f;
    }
}
