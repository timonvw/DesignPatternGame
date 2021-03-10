using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    private GameObject bulletPrefab;
    public float bulletSpeed = 8.5f;
    
    // Start is called before the first frame update
    void Start() {
        bulletPrefab = Resources.Load("Prefabs/Enemies/BasicBullet") as GameObject;
        StartCoroutine(AttackTimer());
        bulletSpeed = 8.5f * GameMaster.Instance.enemySpeedMultiplier;
    }

    // Update is called once per frame
    void FixedUpdate() {
        ChasePlayer(3);
    }

    public override void Attack() {
        GameObject bullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity) as GameObject;
        bullet.GetComponent<BasicBullet>().damage = damage;
        bullet.GetComponent<BasicBullet>().speed = bulletSpeed;
    }

    private IEnumerator AttackTimer() {
        yield return new WaitForSeconds(3f);
        Attack();
        StartCoroutine(AttackTimer());
    }

    public override void SetState() {
        // TODO Animations here depeding on the EnemyFactory.EnemyState

        switch (state) {   
            case EnemyFactory.EnemyState.Normal:
                bulletSpeed = 8.5f * GameMaster.Instance.enemySpeedMultiplier;
                break;
            case EnemyFactory.EnemyState.Beefed:
                bulletSpeed = bulletSpeed + 4;
                break;
            default:
                bulletSpeed = 8.5f;
                break;
        }

    }
}
