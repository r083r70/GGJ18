using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighQuality : PowerUp {
    public override void PowerUpEffect(Piccione p) {
        p.HighQuality();
    }

    protected override void AddToHUD() {
        HudPowerUp.instance.AddPowUp(1, this);
    }
}
