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
                    damageable.TakeDamage(damage);
                    Debug.Log("HITTT");
                }
            }
        }
    }
}
