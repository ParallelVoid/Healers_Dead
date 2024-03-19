using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int enemyHealth = 50;
    public int damage = 10;
    public playerStats playerHealth;

    public CapsuleCollider2D cap2d;

    public void TakeDamage(int damage) {
        enemyHealth -= damage;
    }

    public void Update() {
        if (enemyHealth <= 0 && gameObject != null) {
            Destroy(gameObject);
        }
    }

  
}
