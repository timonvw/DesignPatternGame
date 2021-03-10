using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyDecorator : Enemy
{
    protected Enemy decoratedEnemy;

    // Start is called before the first frame update
    public EnemyDecorator(Enemy decoratedEnemy) {
        this.decoratedEnemy = decoratedEnemy;
    }
    public override void SetState() {
        decoratedEnemy.SetState();
    }
    public override void Attack() {}

}
