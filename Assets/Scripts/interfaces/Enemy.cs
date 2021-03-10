using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, ITakeDamage
{
    public string enemyName { private set; get; }
    public float health { private set; get; }
    public float speed { set; get; }
    public EnemyFactory.EnemyState state { set; get; }
    public float damage { set; get; }
    public TextMesh nameText;
    public TextMesh healthText;
    protected GameObject player;

    // When being clicked on by the player, get damage
    public void TakeDamage(int damage){
        health -= damage;
        healthText.text = health.ToString();
        if(health <= 0) {
            Kill();
        }
    }
    
    // Used as constructor
    public void Initialise(string enemyName, float health, float speed, float damage) {
        this.enemyName = enemyName;
        this.health = health;
        this.speed = speed;
        this.damage = damage;
        player = GameObject.Find("Player");
        nameText.text = enemyName;
        healthText.text = health.ToString();
        state = EnemyFactory.EnemyState.Normal;
    }

    // Follow player till reached max distance
    protected void ChasePlayer(int maxDistance) {
        float distance = Vector2.Distance(player.transform.position, gameObject.transform.position);
        if(distance > maxDistance) {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    public void Kill() {
        GameMaster.Instance.enemiesKilled++;
        GameMaster.Instance.RemoveEnemyFromCollection(gameObject);
        Destroy(gameObject);
    }

    public abstract void Attack();

    public abstract void SetState();
}
