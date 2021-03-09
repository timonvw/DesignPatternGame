using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int damage = 50;

    private Rigidbody2D body;
    private float horizontal;
    private float vertical;
    private float moveLimiter = 0.7f;
    public float speed = 8.5f;
    public GameObject explosionPrefab;
    
    // Start is called before the first frame update
    private void Start()
    {
        body = GetComponent<Rigidbody2D>(); 
    }

    private void FixedUpdate() {
        if (horizontal != 0 && vertical != 0) {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        } 
        body.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(0, 0, -550 * Time.deltaTime);
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if(Input.GetMouseButtonDown(0)) {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider != null) {
                ITakeDamage damageable = hit.collider.GetComponent<ITakeDamage>();
                if(damageable != null) {
                    SpawnExplosion(new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y));
                    damageable.TakeDamage(damage);
                    GameMaster.Instance.mainCamera.Shake(0.02f);
                }
            }
        }
    }

    // Create a particle explosion effect
    private void SpawnExplosion(Vector2 pos) {
         GameObject explosion = Instantiate(explosionPrefab, pos, Quaternion.identity) as GameObject;
         Destroy(explosion, 1f);
    }
}
