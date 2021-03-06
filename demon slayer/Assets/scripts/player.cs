﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    [SerializeField]
    private Stat health;

    private Vector2 movement;
    public float speed;
    private Rigidbody2D rb;

    public float jumpForce;

    public bool isjumping;

    private bool facingright;

    private Animator anim;

    public GameObject chicken;

    private SpriteRenderer damage;
    public bool showingDamage = false;
    public float showDamageDuration = 100f;
    public float damageDoneTime = 5f;
    bool hit;

    Rigidbody2D constraints;

    private void Awake()
    {
        health.Initialize();
    }
    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb.AddForce(movement);
        //Rigidbody2D constraints;
        facingright = true;
        damage = GetComponent<SpriteRenderer>();

        constraints = GetComponent<Rigidbody2D>();
        

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (showingDamage == true && Time.time > damageDoneTime)
        {
            unShowDamage();
            showingDamage = false;
        }

        if (hit==true)
        {
           health.CurrentVal -= 10;
            hit = false;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
           // health.CurrentVal += 10;
        }

        if(health.CurrentVal == 0)
        {
            SceneManager.LoadScene(3);
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb.AddForce(movement);
       //legAttack();
       flip(moveHorizontal); 
        jump();
        


        if (moveHorizontal > 0 || moveHorizontal < 0)
        {
            anim.SetBool("isRunning", true);
          
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        legAttack();
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

        if (other.gameObject.tag == "fissure")
        {
            

            Destroy(other.gameObject);
            hit = true;

        }

        if (other.gameObject.tag == "fissure" )
        {
           
            showingDamage = true;
            damage.color = new Color();
            damage.color = Color.red;
            constraints.velocity = Vector2.zero;
            damageDoneTime = Time.time + showDamageDuration;



        }

    }

    void unShowDamage()
    {
        damage.color = Color.white;
        showingDamage = false;

    }

    private void legAttack()
    {
        if (Input.GetKeyDown(KeyCode.A))// && !isjumping )
        {
            anim.SetTrigger("legAttack");
            
        }
    }
   }
