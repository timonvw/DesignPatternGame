using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    #region Singleton
    private static GameMaster _instance;
    public static GameMaster Instance { get { return _instance; } }
    #endregion
    public EnemyFactory enemyFactory;
    public int playerHealth { private set; get; }
    public float enemyHealthMultiplier { private set; get; }
    public float enemySpeedMultiplier { private set; get; }
    public float spawnTimer { private set; get; }

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
        spawnTimer = 3f;
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        GameObject enemy1 = enemyFactory.CreateEnemy("Melee", new Vector2(5,0));
        GameObject enemy2 = enemyFactory.CreateEnemy("Ranged", new Vector2(15,0));
        GameObject enemy3 = enemyFactory.CreateEnemy("Melee", new Vector2(25,0));
        GameObject enemy4 = enemyFactory.CreateEnemy("Ranged", new Vector2(35,0));

        enemy1.GetComponent<Enemy>().Attack();
        Debug.Log(enemy1.GetComponent<Enemy>().enemyName);
        Debug.Log(enemy1.GetComponent<Enemy>().health);

        enemy2.GetComponent<Enemy>().Attack();
        Debug.Log(enemy2.GetComponent<Enemy>().enemyName);
        Debug.Log(enemy2.GetComponent<Enemy>().health);

        enemy3.GetComponent<Enemy>().Attack();
        Debug.Log(enemy3.GetComponent<Enemy>().enemyName);
        Debug.Log(enemy3.GetComponent<Enemy>().health);

        enemy4.GetComponent<Enemy>().Attack();
        Debug.Log(enemy4.GetComponent<Enemy>().enemyName);
        Debug.Log(enemy4.GetComponent<Enemy>().health);
    }

    // Update is called once per frame
    private void Update() {
        
    }
}
