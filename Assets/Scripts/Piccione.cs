using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piccione : MonoBehaviour {
    private Rigidbody rb;
    private ParticleSystem ps;

    public float forceModule;

    public float initialLife = 100;
    private float life;

    public float initialSpeed = 50f;
    private float speed;

    public float minDeltaTimeDamage = 1;
    private float deltaTimeDamage;

    private void Start () {
        rb = GetComponent<Rigidbody>();
        ps = GetComponent<ParticleSystem>();
        life = initialLife;
        deltaTimeDamage = 0f;
    }

    private void Update () {
        rb.velocity = (Vector3.up * rb.velocity.y) + Vector3.right * initialSpeed;
        if (Input.GetButtonDown("Jump"))
            rb.AddForce(Vector3.up * forceModule, ForceMode.Impulse);
        deltaTimeDamage += Time.deltaTime;
    }

    private void RemoveLife(float damage = 0f) {
        if (deltaTimeDamage < minDeltaTimeDamage)
            return;

        life -= damage;
        ps.Play();
        deltaTimeDamage = 0f;
        if (life <= 0)
            Death();
    }

    private void Death() {
        ; // TODO
    }
    
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Borders"))
            RemoveLife();
    }
}
