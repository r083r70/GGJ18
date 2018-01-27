using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBar : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        HealthBar.health -=50;
    }



}
