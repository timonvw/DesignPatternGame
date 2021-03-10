using UnityEngine;
using System.Collections;
public interface IBullet
{
    float speed { get; set; }
    Vector3 playerPos { get; set; }
    float damage { get; set; }
    Vector3 shootDirection { get; set; } 
    void Shoot();
    void OnTriggerEnter2D(Collider2D coll);
    IEnumerator DestroyTimer();
}
