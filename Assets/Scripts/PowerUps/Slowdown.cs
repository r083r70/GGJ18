using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowdown : PowerUp {
    public override void PowerUpEffect(Piccione p) {
        //p.Slowdown();
    }

    protected override void AddToHUD() {
        HudManager.Instance.Change(4, true);
    }
}
