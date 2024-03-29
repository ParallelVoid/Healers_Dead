using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{

    [SerializeField]
    public float speed;
    public float stoppingDistance;
    public playerStats currentHealth;
    public int damage;

    public float distance;
    private Transform player;
    


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(DifficultyRamping());
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        //Vector2 direction = player.transform.position - transform.position;

        if (distance < 7){
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
      
        

    }

    void OnCollisionEnter2D (Collision2D collision) 
    {
        if (collision.gameObject.tag == "Player") 
        {
            currentHealth.TakeDamage(damage);
            Debug.Log("Player is hit");
        }
    }

    IEnumerator DifficultyRamping()
    {
        for (int i = 0; i < 5; i++)
        {
            if (this != null)
            {
                speed += 0.3f;
                damage += 5;
                yield return new WaitForSeconds(10);

            }
            else
            {
                yield return null;
            }
        }
    }

}
