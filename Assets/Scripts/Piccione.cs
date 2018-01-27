using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piccione : MonoBehaviour {
    private Rigidbody rb;
    private ParticleSystem ps;

    public float forceModule;

    private void Start () {
        rb = GetComponent<Rigidbody>();
        ps = GetComponent<ParticleSystem>();
    }

    private void Update () {
        if (Input.GetButtonDown("Jump"))
            rb.AddForce(Vector3.up * forceModule, ForceMode.Impulse);
	}
    
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Borders"))
            ps.Play();
    }
}
