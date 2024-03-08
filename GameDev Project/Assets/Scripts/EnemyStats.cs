using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField]
    private float enemyHealth = 50f;
    private float enemyMaxHealth;

    public BoxCollider2D bc2d;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

    }

    public void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            print("Playertakedamage");
            
    
        }
    }
}
