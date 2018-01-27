using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{

    public GameObject pickupEffect;
    public float multiplier = 1.4f;
    public float duration = 4f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            StartCoroutine(Pickup(other));
        }
    }
    IEnumerator Pickup(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        //player.transform.localScale *= multiplier;
        PlayerStats stats = player.GetComponent<PlayerStats>();
        stats.Health *= multiplier;
        
        Destroy(gameObject);



        yield return new WaitForSeconds(duration);
        //stats.health /= multiplier;

        Destroy(gameObject);

    }



}

