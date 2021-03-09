﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    // Update is called once per frame
    void Update() {
        Attack();
    }

    public override void Attack() {
        ChasePlayer(0);
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.name == "Player") {
            GameMaster.Instance.mainCamera.Shake(0.1f);
            GameMaster.Instance.playerHealth -= (int)damage;
            Kill();
        }
    }
}
