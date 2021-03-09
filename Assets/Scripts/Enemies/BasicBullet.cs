using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour, IBullet
{
    public float speed { get; set; }
    public Vector2 playerPos { get; set; }
    public float damage { get; set; }

    // Start is called before the first frame update
    void Start()
    {   
        Transform player = GameObject.Find("Player").transform;
        playerPos = new Vector2(player.position.x, player.position.y);
        speed = 2f;
        StartCoroutine(DestroyTimer());
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    public void Shoot() {
        transform.position = Vector2.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
    }

    public IEnumerator DestroyTimer() {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.name == "Player") {
            Debug.Log("HITTTT");
        }
    }
}
