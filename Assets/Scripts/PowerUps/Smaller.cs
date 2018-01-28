using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smaller : PowerUp {
    public override void PowerUpEffect(Piccione p) {
        //p.Smaller();
    }

    protected override void AddToHUD() {
        HudManager.Instance.Change(2, true);
    }
}
