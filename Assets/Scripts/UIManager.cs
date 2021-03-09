using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Singleton
    private static UIManager _instance;
    public static UIManager Instance { get { return _instance; } }
    #endregion
    
    public Text healthText;
    public Text enemyText;

    private void Awake() {
        if (_instance != null && _instance != this)
        {
            Debug.Log("Dat hoort niet, je doet iets verkeerd ;)");
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = GameMaster.Instance.playerHealth.ToString();
        enemyText.text = GameMaster.Instance.enemiesKilled.ToString();
    }
}
