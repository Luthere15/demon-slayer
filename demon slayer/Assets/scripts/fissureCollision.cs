﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fissureCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {



        if (other.gameObject.tag == "fissure")
        {


            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Ground")
        {


            //Destroy(this.gameObject);
        }


    }
}