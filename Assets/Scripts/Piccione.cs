﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Piccione : NetworkBehaviour {
    private Rigidbody rb;
    private Transform tr;
    private ParticleSystem ps;

    public float forceModule;

    public int initialLife = 6;
    public int life;

    public GameObject[] skins;
    public GameObject[] feavers;

    public float initialSpeed = 50f;
    public float speed;

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
        life = initialLife;
        deltaTimeDamage = 0f;
        damageIndex = -1;
        speed = initialSpeed;
        invincible = noDowns = false;
    }

    private void Update() {
        // speed
        rb.velocity = (Vector3.up * rb.velocity.y) + Vector3.right * speed;

        // jump
        if (Input.GetButtonDown("Jump") || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            rb.AddForce(Vector3.up * forceModule, ForceMode.Impulse);

        // feavers
        deltaTimeDamage += Time.deltaTime;
        if (deltaTimeDamage > minDeltaTimeDamage && damageIndex >= 0)
            feavers[damageIndex].SetActive(false);

        // powers
        if (powerUpDuration > maxPowerUpDuration)
            ResetPowers();
        powerUpDuration += Time.deltaTime;
    }

    private void RemoveLife(int damage = 1) {
        if (deltaTimeDamage < minDeltaTimeDamage || life <= 0 || invincible)
            return;
        life -= damage;

        foreach (GameObject skin in skins)
            skin.SetActive(false);

        damageIndex++;
        skins[damageIndex + 1].SetActive(true);
        feavers[damageIndex].SetActive(true);

        ps.Play();
        deltaTimeDamage = 0f;
        if (life <= 0)
            Death();
    }

    private void Death() {
        ; // TODO
    }

    public override void OnStartClient() {
        base.OnStartClient();

        Debug.Log("2");
        SceneManager.LoadScene("PiccioneNuovo", LoadSceneMode.Additive);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Borders"))
            RemoveLife();
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
        speed = speed / 2f;
        powerUpDuration = 0f;
    }

    private void ResetPowers() {
        Vector3 newPos = tr.position;
        if(tr.localScale.x < 1)
            newPos.y *= 2f;
        tr.localScale = Vector3.one;
        tr.position = newPos;

        invincible = noDowns = false;
        speed = initialSpeed;
    }
}
