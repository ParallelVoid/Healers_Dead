using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerStats : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;

    public int maxMana = 100;
    public int currentMana;

    public int healAmount;
    public int healCost;

    public float healthRegen;
    public float manaRegen;

    [SerializeField] private int currentExperience;
    private int maxExperience = 50;
    [SerializeField] private int currentLevel;

    public HealthBar healthBar;
    public ManaBar manaBar;

    public EnemyStats enemystats;
    public Loadout loadout;
    public LoadoutStats loadoutstats;

    public HealBox healbox;
    public HealBox playerWithinAura;
    public Transform shotPoint;
    private bool playerIsHealing;
    private Coroutine coroutine;

    public float invulnerable = 3f;
    private bool isInvulnerable = false;

    //public GameObject player;

    [SerializeField] private Animator anim;

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
        //healbox = gameObject.GetComponent<Healbox>();

    }

    // private void OnEnable()
    // {
    //     ExperienceManager.Instance.OnExperienceChange += HandleExperienceChange;
    // }

    // private void OnDisable()
    // {
    //     ExperienceManager.Instance.OnExperienceChange -= HandleExperienceChange;
    // }

    // Update is called once per frame
    void Update() {
        
        healthBar.SetHealth(currentHealth);
        manaBar.SetMana(currentMana);
        
        if (Input.GetKeyDown(KeyCode.E) && currentMana > 25) {
           
            Instantiate(healbox, shotPoint.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("PlayerHeal");
            if(playerWithinAura)
            {
                coroutine = StartCoroutine(HealingAura());
                currentMana -= healCost;
                manaBar.SetMana(currentMana);
                playerIsHealing = true;
            }
            else if (!playerWithinAura)
            {
                StopCoroutine(coroutine);
            }
            
            
        }
        else
        {
            playerIsHealing = false;
        }
        
        if (currentHealth <= 0) {
            PlayerDeath();
        }


        if (currentHealth > maxHealth) {
            currentHealth = 100;
        }
        
        

        if (currentMana > maxMana) {
            currentMana = 100;
        }

        // if(Weapon.playerIsAttacking = true);
        // {
        //     anim.SetBool("isAttacking", true);
        // }


        
        //currentMana = currentMana + Mathf.RoundToInt(manaRegen);

        
    }

    IEnumerator HealingAura()
    {
        for (int i = 0; i < 5; i++)
        {
            if (currentHealth < 100)
            {
                currentHealth += 5;
                healthBar.SetHealth(currentHealth);
                yield return new WaitForSeconds(1);

            }
            else
            {
                yield return null;
            }
        }
    }

    IEnumerator JustHurt()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(invulnerable);
        isInvulnerable = false;
    }

    //Old Heal System
    // private void Heal() 
    // {

    //     // currentHealth += healAmount;
    //     // healthBar.SetHealth(currentHealth);
    //     // currentMana -= healCost;
    //     // manaBar.SetMana(currentMana);
    // }

    public void TakeDamage(int damage) 
    {
        if(!isInvulnerable)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            anim.SetTrigger("isHurt");
            StartCoroutine(JustHurt());
        }
        

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

    public void AddExperience(int expAmount)
    {
        currentExperience += expAmount;
        if(currentExperience >= maxExperience)
        {
            LevelUp();
        }

    }

    // private void HandleExperienceChange(int newExperience)
    // {
    //     currentExperience += newExperience;
    //     if(currentExperience >= maxExperience)
    //     {
    //         LevelUp();
    //     }
    // }
    
    private void LevelUp()
    {
        maxHealth += 10;
        currentHealth += 50;

        currentLevel++;

        currentExperience = 0;
        maxExperience += 100;

    }

    // void OnCollisionEnterBody2D (Collision2D collision)
    // {
    //     Debug.Log("Something hit player");
    //     if(collision.gameObject.tag == "EnemyProjectile")
    //     {
    //         Debug.Log("Player is hit");
    //         TakeDamage(20);
    //     }
    // }
}
