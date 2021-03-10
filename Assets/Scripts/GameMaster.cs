using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    #region Singleton
    private static GameMaster _instance;
    public static GameMaster Instance { get { return _instance; } }
    #endregion

    // GameOjects
    public EnemyFactory enemyFactory;
    public CameraMove mainCamera;

    public EnemyCollection enemyCollection = new EnemyCollection();

    public int playerHealth { set; get; }

    // Enemy
    public float enemyHealthMultiplier { private set; get; }
    public float enemySpeedMultiplier { private set; get; }
    public float enemyDamageMultiplier { private set; get; }
    public float baseSpawnTimer { private set; get; }
    public int enemiesKilled { set; get; }

    private void Awake() {
        if (_instance != null && _instance != this)
        {
            Debug.Log("Dat hoort niet, je doet iets verkeerd ;)");
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
        SetStartSettings();
    }

    public void SetStartSettings() {
        playerHealth = 250;
        enemyHealthMultiplier = 1f;
        enemySpeedMultiplier = 1f;
        enemyDamageMultiplier = 1f;
        baseSpawnTimer = 7f;
        enemiesKilled = 0;
    }

    public void AddEnemyToCollection(GameObject enemy) {
        EnemyCollection.enemiesCollection.Add(enemy);
    }

    public void RemoveEnemyFromCollection(GameObject enemy) {
        EnemyCollection.enemiesCollection.Remove(enemy);
    }

    // Update is called once per frame
    private void Update() {
        
    }
}
