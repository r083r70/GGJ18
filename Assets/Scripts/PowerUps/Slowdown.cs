using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowdown : PowerUp {
    public override void PowerUpEffect(Piccione p) {
        p.Slowdown();
    }

    protected override void AddToHUD() {
        HudPowerUp.instance.AddPowUp(3, this);
    }
}
