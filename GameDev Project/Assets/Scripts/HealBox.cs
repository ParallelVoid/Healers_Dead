using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBox : MonoBehaviour
{

    public playerStats currentHealth;
    private Transform player;

    private void OnTriggerEnter2D (Collider2D other) {

        if (other.tag == "Player") {
            currentHealth.Heal();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
