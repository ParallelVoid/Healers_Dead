using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int enemyHealth = 50;
    public int damage = 10;
    public playerStats playerHealth;
    private Animator anim;
    private int expAmount = 10;

    public void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }


    public void TakeDamage(int damage) {
        enemyHealth -= damage;
        anim.SetTrigger("isHurt");
    }

    public void Update() {
        if (enemyHealth <= 0 && gameObject != null) {
            ExperienceManager.Instance.AddExperience(expAmount);
            Destroy(gameObject);
        }
    }

  
}
