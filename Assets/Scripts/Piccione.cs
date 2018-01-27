using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Piccione : NetworkBehaviour
{
    private Rigidbody rb;
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

    public bool trigger;

    private int damageIndex;

    private void Start () {
        rb = GetComponent<Rigidbody>();
        ps = GetComponent<ParticleSystem>();
        life = initialLife;
        deltaTimeDamage = 0f;
        damageIndex = 0;
    }

    private void Update () {
        rb.velocity = (Vector3.up * rb.velocity.y) + Vector3.right * initialSpeed;
        if (Input.GetButtonDown("Jump"))
            rb.AddForce(Vector3.up * forceModule, ForceMode.Impulse);
        deltaTimeDamage += Time.deltaTime;

        if (trigger)
            RemoveLife();
    }

    private void RemoveLife(int damage = 1) {
        trigger = false;

        if (deltaTimeDamage < minDeltaTimeDamage || life <= 0)
            return;
        life -= damage;

        foreach (GameObject skin in skins)
            skin.SetActive(false);
        foreach (GameObject feaver in feavers)
            feaver.SetActive(false);

        skins[damageIndex + 1].SetActive(true);
        feavers[damageIndex].SetActive(true);
        damageIndex++;

        ps.Play();
        deltaTimeDamage = 0f;
        if (life <= 0)
            Death();
    }

    private void Death() {
        ; // TODO
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        
        Debug.Log("2");
        SceneManager.LoadScene("PiccioneNuovo", LoadSceneMode.Additive);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Borders"))
            RemoveLife();
    }
}
