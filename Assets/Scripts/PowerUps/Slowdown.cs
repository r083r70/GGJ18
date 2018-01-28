using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowdown : PowerUp {
    public override void PowerUpEffect(Piccione p) {
        p.Slowdown();
    }

    protected override void AddToHUD() {
        HudPowerUp.Instance.AddPowUp(3, this);
    }
}
