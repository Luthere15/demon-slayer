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

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb.AddForce(movement);
        Rigidbody2D constraints;

       
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb.AddForce(movement);

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
}
