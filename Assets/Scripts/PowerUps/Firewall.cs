using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firewall : PowerUp {
    protected override void PowerUpEffect(Piccione p) {
        p.Firewall();
    }
}
