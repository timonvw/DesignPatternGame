using UnityEngine;
using System.Collections;
public interface IBullet
{
    float speed { get; set; }
    Vector2 playerPos  { get; set; }
    float damage  { get; set; }
    void Shoot();
    void OnTriggerEnter2D(Collider2D coll);
    IEnumerator DestroyTimer();
}
