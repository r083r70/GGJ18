using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighQuality : PowerUp {
    protected override void PowerUpEffect(Piccione p) {
        p.HighQuality();
    }
}
