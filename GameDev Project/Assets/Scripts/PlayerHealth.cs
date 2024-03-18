using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour

{
    public int maxHealth = 100;
    public int currentHealth;
    public int damage = 5;
    public int healAmount = 5;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            TakeDamage(damage);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Heal(healAmount);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    void Heal(int damage)
    {
        currentHealth += healAmount;
        healthBar.SetHealth(currentHealth);
    }
}

