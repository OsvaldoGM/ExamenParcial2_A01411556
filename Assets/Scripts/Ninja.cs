using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ninja : MonoBehaviour {

    public float maxVel = 5f; 
    public float yJumpForce = 300f; 

    private bool isjumping = false;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 jumpforce;
    private bool movingRight = true;

    public AudioClip espadas; 
    public AudioClip jump; 
    public AudioClip hit; 
    public AudioClip shurikens;

    private Rigidbody2D rgb;       

    private Vector3 offset = new Vector3(0.25f, 0, 0);


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jumpforce = new Vector2(0, 0);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float v = Input.GetAxis("Horizontal");
        Vector2 vel = new Vector2(0, rb.velocity.y);
        v *= maxVel;
        vel.x = v;
        rb.velocity = vel;


        if (v != 0)
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }

        if (Input.GetAxis("Jump") > 0.01f)
        {
            if (!isjumping)
            {
                if (rb.velocity.y == 0)
                {

                    anim.SetBool("IsJumping", true);
                    isjumping = true;
                    jumpforce.x = 0f;
                    jumpforce.y = yJumpForce;
                    rb.AddForce(jumpforce);
                    AudioSource.PlayClipAtPoint(jump, transform.position);
                }
            }
        }
        else
        {
            isjumping = false;
        }
        if (movingRight && v < 0)
        {
            movingRight = false;
            Flip();
        }
        else if (!movingRight && v > 0)
        {
            movingRight = true;
            Flip();
        }
        if (Input.GetButtonDown("Vertical"))
        {
            anim.SetBool("IsCrouched", true);

        }
        
    }


    private void Flip()
    {
        var s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
        offset = offset * -1;

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        
        Espada espada = collider.gameObject.GetComponent<Espada>();
        Shuriken shuriken = collider.gameObject.GetComponent<Shuriken>();
        Enemy enemy = collider.gameObject.GetComponent<Enemy>();
        Puerta puerta = collider.gameObject.GetComponent<Puerta>();

        
        if (espada)
        {
            AudioSource.PlayClipAtPoint(espadas, transform.position);
            GameObject.Find("Playerstats").GetComponent<Playerstats>().score+=100;
            Destroy(collider.gameObject);
        }
        else if (puerta)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (shuriken)
        {
            AudioSource.PlayClipAtPoint(shurikens, transform.position);
            GameObject.Find("Playerstats").GetComponent<Playerstats>().health +=100;
            Destroy(collider.gameObject);
        }
        else if (enemy)
        {
            AudioSource.PlayClipAtPoint(hit, transform.position);
            GameObject.Find("Playerstats").GetComponent<Playerstats>().health -= 100;
            if(GameObject.Find("Playerstats").GetComponent<Playerstats>().health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        GameObject.Find("LevelManager").GetComponent<LevelManager>().LoadLevel("End");
    }

}
