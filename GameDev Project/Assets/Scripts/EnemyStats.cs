using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EnemyStats : MonoBehaviour
{
    public int enemyHealth = 50;
    public playerStats playerstats;
    private Animator anim;
    public int expAmount = 10;
    public int enemyType = 0; // if enemyType = 1 - boss
    public int sceneBuildIndex;
    private bool canChangeScene;

    public void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        //playerstats = gameObject.GetComponent<playerStats>();
    }


    public void TakeDamage(int damage) {
        enemyHealth -= damage;
        anim.SetTrigger("isHurt");
    }

    public void Update() {
        if (enemyHealth <= 0 && gameObject != null) {
            //ExperienceManager.Instance.AddExperience(expAmount);
            playerstats.AddExperience(expAmount);
            if (enemyType == 1)
            {
                if (canChangeScene)
                {
                    SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
                }
            }
            Destroy(gameObject);
        }
    }

  
}
