using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LichProjectile : MonoBehaviour
{
    //public LayerMask whatIsSolid;
    public float speed;
    public playerStats currentHealth;
    public int damage = 20;
    //private int health = 20;
    public float lifeTime;

    public float distance;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Invoke("DestroyProjectile", lifeTime);
        //Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < 7){
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }


    }

    void OnTriggerEnter2D (Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<playerStats>().currentHealth -= 20;
            DestroyProjectile();
        }
    }



    void DestroyProjectile() 
    {
        Destroy(gameObject);
    
            
    }

}