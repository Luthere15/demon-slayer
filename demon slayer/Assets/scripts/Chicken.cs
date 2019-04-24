using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    public GameObject fissure;
    public GameObject chicken;

    public float fissureSpeed = 40;
    public float speed ;
   
    public float chanceToChangeDirections = 0.1f;
    public float secondsBetweenFissureattack = 5f;
    public static float leftScreen = -10f;

    private Animator anim;

    public Transform target;
   

    private bool facingright;

    //private bool attack;
  




    // Use this for initialization
    void Start()
    {
       
        anim = GetComponent<Animator>();
        Invoke("tempFire", 2f);
        facingright = false;
        chicken = this.gameObject;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
       
    }

    
    // Update is called once per frame
    void Update()
    {

        //pos.x += speed * Time.deltaTime;
        //transform.position = pos;
        if (Vector3.Distance(transform.position,target.position)> 10)
        {
            anim.SetBool("findingPlayer", true);
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            //attack = false;
        }
        if (Vector3.Distance(transform.position, target.position) <= 10)
        {
           anim.SetBool("findingPlayer", false);
        }
    }
     private void resetValues()
    {
       // attack = false;
    }
    

    private void FixedUpdate()
    {
        float playerPlace = target.transform.position.x;
        flip(playerPlace);
        resetValues();

       
    }
    private void flip(float playerPlace)
    {
        if (playerPlace > this.transform.position.x &&  !facingright|| playerPlace < this.transform.position.x && facingright)//Chicken.transform.position.x) // !facingright) //|| playerPlace < 0 && facingright)
        {
            facingright = !facingright;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;
            transform.localScale = theScale;

        }
        
        
    }
        void tempFire()
    {
        GameObject attack = Instantiate<GameObject>(fissure);
        Rigidbody2D rigidB = attack.GetComponent<Rigidbody2D>();
        if (transform.localScale.x > 0)
        { 
         attack.transform.position = new Vector2(transform.position.x, transform.position.y); 
         rigidB.velocity = Vector2.left * fissureSpeed;
        }
        if (transform.localScale.x < 0)
        {
            attack.transform.position = new Vector2(transform.position.x, transform.position.y);
            rigidB.velocity = Vector2.right * fissureSpeed;
        }

        /* rigidB.velocity = Vector2.left * fissureSpeed;
         if(this.transform.localScale.x >- 1)
         {
             attack.transform.position = new Vector2(transform.position.x*-1, 0);
         }*/

        Invoke("tempFire", secondsBetweenFissureattack);

    }



  void OnCollisionEnter2D(Collision2D coll)
    {




        if (coll.gameObject.tag == "Player")
        {
            // Destroy(coll.gameObject);


            // Destroy(fissure.gameObject);

           // return;
        }



    }
}
