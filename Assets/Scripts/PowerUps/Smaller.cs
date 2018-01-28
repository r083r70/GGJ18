﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smaller : PowerUp {
    public override void PowerUpEffect(Piccione p) {
        p.Smaller();
    }

    protected override void AddToHUD() {
        HudPowerUp.Instance.AddPowUp(2, this);
    }
}
