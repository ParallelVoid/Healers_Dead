using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBox : MonoBehaviour
{

    //public playerStats coroutine;
    private Transform player;

    public static bool playerWithinAura;
    private float lifeTime = 5;

    void Start()
    {
        Invoke("DestroyHealBox", lifeTime);
    }

    private void OnTriggerEnter2D (Collider2D other) {
 
        if (other.tag == "Player" && this != null) {
            playerWithinAura = true;
        }
        else if((other.tag == "Player" && this == null))
        {
            playerWithinAura = false;
        }
        
    }

    private void OnTriggerExit2D (Collider2D other)
    {
        playerWithinAura = false;
    }


    private void DestroyHealBox()
    {
        Destroy(gameObject);
    }
}
