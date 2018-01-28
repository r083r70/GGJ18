using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firewall : PowerUp {
    public override void PowerUpEffect(Piccione p) {
        p.Firewall();
    }

    protected override void AddToHUD() {
        HudPowerUp.Instance.AddPowUp(0, this);
    }
}
