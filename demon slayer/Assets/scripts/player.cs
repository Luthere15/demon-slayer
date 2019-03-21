using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Vector2 movement;
    public float speed;
    private Rigidbody2D rb;

    public float jumpForce;

    public bool isjumping;

    private bool facingright;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb.AddForce(movement);
        //Rigidbody2D constraints;
        facingright = true;


    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb.AddForce(movement);

        flip(moveHorizontal);
        jump();
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isjumping)
        {
            isjumping = true;

            rb.AddForce(new Vector2(movement.x, jumpForce));
        }
    }

    private void flip(float moveHorizontal)
    {
        if (moveHorizontal > 0 && !facingright || moveHorizontal < 0 && facingright)
        {
            facingright = !facingright;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Ground"))
        {
            isjumping = false;


        }
    }
    }
