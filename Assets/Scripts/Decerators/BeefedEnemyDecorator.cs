using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeefedEnemyDecorator : EnemyDecorator
{
    public BeefedEnemyDecorator(Enemy decoratedEnemy) : base(decoratedEnemy) {}
    public override void SetState() {
        decoratedEnemy.SetState();
        BeefEnemy();
    }

    private void BeefEnemy() {
        decoratedEnemy.damage *= 2f;
        decoratedEnemy.speed *= 2f;
        decoratedEnemy.state = EnemyFactory.EnemyState.Beefed;
    }
}
