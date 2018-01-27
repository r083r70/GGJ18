using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowdown : PowerUp {
    protected override void PowerUpEffect(Piccione p) {
        p.Slowdown();
    }
}
