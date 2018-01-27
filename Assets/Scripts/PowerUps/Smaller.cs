using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smaller : PowerUp {
    protected override void PowerUpEffect(Piccione p) {
        p.Smaller();
    }
}
