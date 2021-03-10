using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollection : Collection
{
    public static List<GameObject> enemiesCollection = new List<GameObject>();

    public Iterator GetIterator() {
        return new EnemyIterator();
    }

    private class EnemyIterator : Iterator {
        private int index = 0;

        public bool hasNext() {
            if(index < enemiesCollection.Count) {
                return true;
            }
            return false;
        }

        public GameObject next() {
            if (this.hasNext()) {
                return enemiesCollection[index++];
            }
            return null;
        }
        
        public void orderMinToMaxHealth() {
            // List<GameObject> sortedEnemiesCollection = new List<GameObject>();

            // foreach(GameObject enemy in enemiesCollection) {
            //     var health = enemy.GetComponent<Enemy>().health;
            // }
            // TODO order collection by enemy health
        } 
    }

    
}
