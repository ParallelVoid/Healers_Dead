using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : MonoBehaviour
{
    public int bossHealth = 500;
    public playerStats playerstats;
    private Animator anim;
    public int expAmount = 100;

    public void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        //playerstats = gameObject.GetComponent<playerStats>();
    }


    public void TakeDamage(int damage) {
        bossHealth -= damage;
        anim.SetTrigger("isHurt");
    }

    public void Update() {
        if (bossHealth <= 0 && gameObject != null) {
            //ExperienceManager.Instance.AddExperience(expAmount);
            playerstats.AddExperience(expAmount);
            Destroy(gameObject);
        }
    }

  
}

