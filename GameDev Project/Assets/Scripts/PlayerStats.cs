using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour {

    public int maxHealth = 100;
    public int currentHealth;

    public int maxMana = 100;
    public int currentMana;

    public HealthBar healthBar;
    public ManaBar manaBar;

    // Start is called before the first frame update
    void Start() {
        currentHealth = maxHealth/10;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
        currentMana = maxMana;
        manaBar.SetMaxMana(maxMana);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Heal(20);
        }
    }

    void Heal(int damage) {
        currentHealth += damage;
        healthBar.SetHealth(currentHealth);
        currentMana -= damage;
        manaBar.SetMana(currentMana);
    }
}
