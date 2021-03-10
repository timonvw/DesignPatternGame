using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour, IBullet
{
    public float speed { get; set; }
    public Vector3 playerPos { get; set; }
    public float damage { get; set; }
    public Vector3 shootDirection { get; set; }

    // Start is called before the first frame update
    void Start()
    {   
        Transform player = GameObject.Find("Player").transform;
        playerPos = new Vector2(player.position.x, player.position.y);
        speed = speed * GameMaster.Instance.enemySpeedMultiplier;
        StartCoroutine(DestroyTimer());
        shootDirection = (playerPos - transform.position).normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    public void Shoot() {
        transform.position += shootDirection * Time.deltaTime;
    }

    public IEnumerator DestroyTimer() {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.name == "Player") {
            GameMaster.Instance.playerHealth -= (int)damage;
            GameMaster.Instance.mainCamera.Shake(0.04f);
            Destroy(gameObject);
        }
    }
}
