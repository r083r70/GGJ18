using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighQuality : PowerUp {
    public override void PowerUpEffect(Piccione p) {
        p.HighQuality();
    }

    protected override void AddToHUD() {
        HudPowerUp.Instance.AddPowUp(1, this);
    }
}
