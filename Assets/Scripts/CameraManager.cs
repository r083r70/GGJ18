using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    private Transform tr;
    public Transform piccione;

    private float y, z;

    private float offset;

    public void setTarget(Transform target) {
        piccione = target;
        tr = GetComponent<Transform>();
        offset = tr.position.x - piccione.position.x;
        y = tr.position.y;
        z = tr.position.z;
    }

    void LateUpdate() {
        if (piccione)
            tr.position = new Vector3(piccione.position.x + offset, y, z);
    }
}
