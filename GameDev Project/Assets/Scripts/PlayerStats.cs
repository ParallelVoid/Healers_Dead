using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerStats : MonoBehaviour {

    public int maxHealth = 100;
    public int currentHealth;

    public int maxMana = 100;
    public int currentMana;

    public int healAmount;
    public int healCost;

    public float healthRegen;
    public float manaRegen;

    public HealthBar healthBar;
    public ManaBar manaBar;

    private Animator anim;

    // Start is called before the first frame update
    void Start() {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
        currentMana = maxMana;
        manaBar.SetMaxMana(maxMana);
        
        //manaRegen += 5 * Time.deltaTime;
        StartCoroutine(addMana());


        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        
        healthBar.SetHealth(currentHealth);
        manaBar.SetMana(currentMana);
        
        if (Input.GetKeyDown(KeyCode.Space) && currentMana > 25) {
            Heal();
        }
        
        if (currentHealth < 0) {
            PlayerDeath();
        }


        if (currentHealth > maxHealth) {
            currentHealth = 100;
        }
        
        

        if (currentMana > maxMana) {
            currentMana = 100;
        }


        
        //currentMana = currentMana + Mathf.RoundToInt(manaRegen);

        
    }


    void Heal() 
    {
        currentHealth += healAmount;
        healthBar.SetHealth(currentHealth);
        currentMana -= healCost;
        manaBar.SetMana(currentMana);
    }

    public void TakeDamage(int damage) 
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        anim.SetTrigger("isHurt");
        //anim.Play("TakeDamage");

    }

    IEnumerator addMana()
    {
        while (true)
        {
            if (currentMana < 100)
            {
                currentMana += 1;
                yield return new WaitForSeconds(1);

            }
            else
            {
                yield return null;
            }
        }
    }

    void PlayerDeath() 
    {
        Debug.Log("You have Died");
        SceneManager.LoadScene("MainMenu");
    }

    // void PassiveRegeneration()
    // {
        
    // }
    
}
