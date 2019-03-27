using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    public GameObject fissure;
    public float fissureSpeed = 40;
    public float speed = 1f;
    public float leftAndRightEdge = 1f;
    public float chanceToChangeDirections = 0.1f;
    public float secondsBetweenFissureattack = 5f;
    public static float leftScreen = -10f;

    public Transform target;
    public float chaseRange;

    private bool facingright;




    // Use this for initialization
    void Start()
    {

        Invoke("tempFire", 2f);
        facingright = false;
    }

    
    // Update is called once per frame
    void Update()
    {
        Vector2 pos = target.transform.position;
        //pos.x += speed * Time.deltaTime;
        //transform.position = pos;

        


    }

    private void FixedUpdate()
    {
        float playerPlace = target.transform.position.x;
        flip(playerPlace);
    }
    private void flip(float playerPlace)
    {
        if (playerPlace > 0 && !facingright || playerPlace < 0 && facingright)
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
        attack.transform.position = new Vector2(transform.position.x, 0);


        Rigidbody2D rigidB = attack.GetComponent<Rigidbody2D>();
        //rigidB.transform.position = new Vector2(0, -1);
        rigidB.velocity = Vector2.left * fissureSpeed;

        Invoke("tempFire", secondsBetweenFissureattack);

    }

    void OnCollisionEnter2D(Collision2D coll)
    {




        if (coll.gameObject.tag == "Player")
        {
            // Destroy(coll.gameObject);


            // Destroy(fissure.gameObject);

            return;
        }



    }
}
