using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public GameObject chicken;
        float randX;
    Vector2 whereToSpawn;
    public float spawnrate = 2f;
    float nextSpawn = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time> nextSpawn)
        {
            nextSpawn = Time.time + spawnrate;
            randX = Random.Range(12.0f,80.0f);
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(chicken, whereToSpawn, Quaternion.identity);
        }
        
    }
}
