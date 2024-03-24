using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loadout : MonoBehaviour
{

    public static int healthChange;
    public static int manaChange;
    public static int speedChange;
    public static int damageChange;
    public static int healChange;

    [SerializeField] private int skillPoints = 20;
    private int skillCost = 1;

    private bool changeLoadout;
    private bool canChange;

    public GameObject loadoutMenu;
    public BoxCollider2D bc2d;


    // Start is called before the first frame update
    void Start()
    {
        loadoutMenu.SetActive(false);
        canChange = false;
        changeLoadout = false;
        bc2d = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && this != null)
        {
            if(canChange)
            {
                PauseMenu.isPaused = true;
                loadoutMenu.SetActive(true);
                changeLoadout = true;
                Debug.Log("Player is changing their loadout");
            }
            else
            {
                PauseMenu.isPaused = false;
                loadoutMenu.SetActive(false);
                changeLoadout = false;
            }
            
            
        }

        if(skillPoints <= 0)
        {
            skillPoints = 0;
        }
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            canChange = true;
            Debug.Log("Player can change their loadout");
        }
    }

    private void OnTriggerExit2D (Collider2D other)
    {
        canChange = false;
        loadoutMenu.SetActive(false);
        PauseMenu.isPaused = false;
    }

    public void AttackUpgrade()
    {
        
        if(skillPoints > skillCost)
        {
            damageChange += 10;
            healthChange -= 10;
            UseSkillPoints();
        }
        
    }

    public void HealUpgrade()
    {
        if(skillPoints > skillCost)
        {
            healChange += 10;
            damageChange -= 10;
            UseSkillPoints();
        }
    }

    public void ManaUpgrade()
    {
        if(skillPoints > skillCost)
        {
            manaChange += 10;
            speedChange -= 10;
            UseSkillPoints();
        }
    }

    public void HolyUpgrade()
    {
        if(skillPoints > skillCost)
        {
            speedChange += 10;
            healChange -= 10;
            UseSkillPoints();
        }
    }

    private void UseSkillPoints()
    {
        skillPoints -= skillCost;
        skillCost++;
    } 
}
