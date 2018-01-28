using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Piccione : Photon.MonoBehaviour {
    private Rigidbody rb;
    private Transform tr;
    private ParticleSystem ps;

    public float forceModule;
    public float maxVerticalSpeed;

    public int initialLife = 6;
    public int lifes;

    public GameObject[] skins;
    public GameObject[] feavers;

    public float initialSpeed = 50f;
    private float speed;
    public float speedMax = 100f;

    public float speedIncrementation;
    public float fixedDeltaTimeIncrementation;
    private float deltaTimeIncrementation;

    public float minDeltaTimeDamage = 1;
    private float deltaTimeDamage;

    public float maxPowerUpDuration;
    private float powerUpDuration;

    private int damageIndex;
    private bool invincible;
    private bool noDowns;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        ps = GetComponent<ParticleSystem>();
        lifes = initialLife;
        deltaTimeIncrementation = 0f;
        deltaTimeDamage = 0f;
        damageIndex = -1;
        speed = initialSpeed;
        invincible = noDowns = false;

        if (!photonView.isMine)
        {
            Rigidbody attachedRigidbody = GetComponent<Rigidbody>();
            if (attachedRigidbody != null)
            {
                attachedRigidbody.isKinematic = true;
            }
        }
    }

    private void Update() {
        if (!photonView.isMine) return;

        // speed
        rb.velocity = (Vector3.up * rb.velocity.y) + Vector3.right * speed;
        deltaTimeIncrementation += Time.deltaTime;
        if (deltaTimeIncrementation > fixedDeltaTimeIncrementation && speed >= initialSpeed && speed < speedMax) {
            speed *= speedIncrementation;
            initialSpeed = speed;
            deltaTimeIncrementation = 0f;
        }


        // jump
        if (Input.GetButtonDown("Jump") || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            rb.AddForce(Vector3.up * forceModule, ForceMode.Impulse);

        if (rb.velocity.y > maxVerticalSpeed)
            rb.velocity = new Vector3(rb.velocity.x, maxVerticalSpeed, rb.velocity.z);

        // feavers
        deltaTimeDamage += Time.deltaTime;
        if (deltaTimeDamage > minDeltaTimeDamage && damageIndex >= 0)
            feavers[damageIndex].SetActive(false);

        // powers
        if (powerUpDuration > maxPowerUpDuration)
            ResetPowers();
        powerUpDuration += Time.deltaTime;
    }

    private void RemoveLife() {
        if (deltaTimeDamage < minDeltaTimeDamage || lifes <= 0 || invincible)
            return;
        lifes--;

        HudManager.Instance.UpdateLife(lifes);

        foreach (GameObject skin in skins)
            skin.SetActive(false);

        damageIndex++;
        skins[damageIndex + 1].SetActive(true);
        feavers[damageIndex].SetActive(true);

        ps.Play();
        deltaTimeDamage = 0f;
        if (lifes <= 0)
            Death();
    }

    private void Death() {
        ; // TODO
    }
    
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Borders"))
            RemoveLife();
        else if (collision.gameObject.CompareTag("Obstacle"))
            if (invincible)
                collision.gameObject.GetComponent<Obstacle>().Explode();
            else {
                RemoveLife();
                collision.gameObject.GetComponent<SphereCollider>().isTrigger = true;
            }
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.gameObject.CompareTag("Borders"))
            if (tr.position.x - 15 > other.gameObject.GetComponent<Transform>().position.x)
                Destroy(other.gameObject);
    }

    //************************** POWER UPS **************************//
    public void Smaller() {
        Vector3 newPos = tr.position;
        newPos.y /= 2f;
        tr.localScale = Vector3.one * 0.5f;
        tr.position = newPos;
        powerUpDuration = 0f;
    }

    public void Firewall() {
        invincible = true;
        powerUpDuration = 0f;
    }

    public void HighQuality() {
        noDowns = true;
        powerUpDuration = 0f;
    }

    public void Slowdown() {
        initialSpeed = speed;
        speed = speed / 2f;
        powerUpDuration = 0f;
    }

    private void ResetPowers() {
        Vector3 newPos = tr.position;
        if (tr.localScale.x < 1)
            newPos.y *= 2f;
        tr.localScale = Vector3.one;
        tr.position = newPos;

        invincible = noDowns = false;
        speed = initialSpeed;
    }

    private void OnDisable() {
        Invoke("Stupid", 1);
    }

    private void Stupid() {
        gameObject.SetActive(true);
    }
}
