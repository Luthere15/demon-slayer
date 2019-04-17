using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    private SpriteRenderer damaged;
    public bool showingDamage = false;
    public float showDamageDuration = 5f;
    public float damageDoneTime = 5f;
    

    // Start is called before the first frame update
    void Start()
    {
        damaged = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (showingDamage == true && Time.time > damageDoneTime)
        {
            unShowDamage();
            //showingDamage = false;
        }
    }

    void unShowDamage()
    {
        damaged.color = Color.white;
        showingDamage = false;

    }

    void OnCollisionEnter2D(Collision2D other)
    {

        

        if (other.gameObject.tag == "fissure")
        {

            showingDamage = true;
            damaged.color = new Color();
            damaged.color = Color.red;
            
            damageDoneTime = Time.time + showDamageDuration;



        }

    }
}
