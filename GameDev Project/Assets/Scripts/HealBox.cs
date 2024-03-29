using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBox : MonoBehaviour
{

    public playerStats currentHealth;
    private Transform player;

    public bool playerWithinAura;
    private float lifeTime = 5;

    void Start()
    {
        Invoke("DestroyHealBox", lifeTime);
    }

    private void OnTriggerEnter2D (Collider2D other) {

        if (other.tag == "Player" && this != null) {
            playerWithinAura = true;
        }
        else
        {
            playerWithinAura = false;
        }
    }

    private void OnTriggerExit2D (Collider2D other)
    {
        playerWithinAura = false;
    }

    // IEnumerator HealingAura()
    // {
    //     while (true)
    //     {
    //         if (currentHealth < 100)
    //         {
    //             currentHealth += 5;
    //             yield return new WaitForSeconds(1);

    //         }
    //         else
    //         {
    //             yield return null;
    //         }
    //     }
    // }

    private void DestroyHealBox()
    {
        Destroy(gameObject);
    }
}
