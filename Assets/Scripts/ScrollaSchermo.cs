using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollaSchermo : MonoBehaviour {
    private Transform cam;
    public Transform bordersOne;
    public Transform bordersTwo;

    public Mesh mesh;

    private float distance;

    private void Start() {
        cam = Camera.main.GetComponent<Transform>();
        distance = mesh.bounds.size.x * bordersOne.localScale.x * 3 * 0.109675f;
        bordersOne.position = Vector3.zero;
        bordersTwo.position = bordersOne.position + Vector3.right * distance;
    }

    private void Update() {
        ControlUpdate(bordersOne, bordersTwo);
        ControlUpdate(bordersTwo, bordersOne);
    }

    private void ControlUpdate(Transform t1, Transform t2) {
        if (Difference(cam, t1) >= distance)
            t1.position = t2.position + Vector3.right * distance;
    }

    private float Difference(Transform t1, Transform t2) {
        return t1.position.x - t2.position.x;
    }
}
