using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loadout : MonoBehaviour
{

    public static int healthChange;
    public static int manaChange;
    public static int speedChange;
    public int damageChange;

    [SerializeField] private int skillPoints = 20;
    private int skillCost;

    private bool changeLoadout = false;
    private bool canChange;

    public GameObject loadoutMenu;
    public BoxCollider2D bc2d;


    // Start is called before the first frame update
    void Start()
    {
        loadoutMenu.SetActive(false);
        canChange = false;
        bc2d = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
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
    }

    private void AttackUpgrade()
    {
        if(skillPoints > skillCost)
        {
            damageChange += 10;
            healthChange -= 10;
            UseSkillPoints();
        }
        
    }

    private void UseSkillPoints()
    {
        skillPoints -= skillCost;
        skillCost++;
    } 
}
