using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 2;
    Vector2 direction = Vector2.right;
    private Vector3 offset = new Vector3(0.25f, 0, 0);

    public AudioClip enemyHit;


    void Start()
    {
     
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

  
    void Flip()
    {
        Vector3 scale = transform.localScale;
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Wall")
        {
            Debug.Log("Hola");
            var s = transform.localScale;
            s.x *= -1;
            transform.localScale = s;
            offset = offset * -1;
            if(direction == Vector2.right)
            {
                direction = Vector2.left;
            }
            else
            {
                direction = Vector2.right;
            }
        }
    }
}
