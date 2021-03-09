using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float randomStart;

    // Start is called before the first frame update
    private void Start() {
        randomStart = Random.Range(0.5f,GameMaster.Instance.baseSpawnTimer);

        StartCoroutine(SpawnEnemy(new Vector2(
            this.transform.position.x,
            this.transform.position.y), false));      
    }

    // Spawn every few seconds a new enemy
    private IEnumerator SpawnEnemy(Vector2 pos, bool started) {
        // check if first time
        float baseSeconds = started ? GameMaster.Instance.baseSpawnTimer : randomStart;
        float totalSeconds = baseSeconds + Random.Range(1f, (baseSeconds / 3f));
        
        yield return new WaitForSeconds(totalSeconds);
        
        GameMaster.Instance.enemyFactory.CreateEnemy("Random", pos);
        StartCoroutine(SpawnEnemy(pos, true));
    }
}
