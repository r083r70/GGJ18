using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    private Transform tr;
    public Transform piccione;

    private float offset;

    private void Start() {
        tr = GetComponent<Transform>();
        offset = tr.position.x - piccione.position.x;
    }

    void LateUpdate() {
        tr.position = new Vector3(piccione.position.x + offset, 0.25f, -7f);
    }
}
