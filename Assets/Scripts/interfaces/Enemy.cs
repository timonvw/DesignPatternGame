using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, ITakeDamage
{
    public string enemyName { private set; get; }
    public float health { private set; get; }
    public float speed { private set; get; }
    public string state { private set; get; }
    public TextMesh nameText;
    public TextMesh healthText;
    protected GameObject player;

    public void TakeDamage(int damage){
        health -= damage;
        healthText.text = health.ToString();
        if(health <= 0) {
            Destroy(gameObject);
        }
    }
    
    public void Initialise(string enemyName, float health, float speed) {
        this.enemyName = enemyName;
        this.health = health;
        this.speed = speed;
        player = GameObject.Find("Player");
        nameText.text = enemyName;
        healthText.text = health.ToString();
    }

    protected void ChasePlayer(int maxDistance) {
        float distance = Vector2.Distance(player.transform.position, gameObject.transform.position);
        if(distance > maxDistance) {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    public abstract void Attack();

    public void SetState() {
        Debug.Log("State");
    }
}
