using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.name == "Player") {
            // Kill 2 enemies
            Debug.Log("Enemy");
            Iterator iterator = GameMaster.Instance.enemyCollection.GetIterator();
            for(int i = 0; i < 3; i++) {
                if(iterator.hasNext()) {
                    GameObject enemy = iterator.next();
                    enemy.GetComponent<Enemy>().Kill();
                }
            }

        } else {
            Enemy enemy = coll.gameObject.GetComponent<Enemy>();
                if(enemy != null) {
                    BeefedEnemyDecorator beefedEnemy = new BeefedEnemyDecorator(enemy);
                    beefedEnemy.SetState();
                } 
        }
    }
}
