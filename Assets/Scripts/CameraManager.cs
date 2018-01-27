using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    private Transform tr;
    public Transform piccione;

    private Vector3 offset;

    private void Start() {
        tr = GetComponent<Transform>();
        offset = tr.position - piccione.position;
    }

    void LateUpdate() {
        tr.position = (Vector3.right * piccione.position.x) + offset;
    }
}
