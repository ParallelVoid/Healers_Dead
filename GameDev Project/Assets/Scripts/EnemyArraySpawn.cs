using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArraySpawn : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;

    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject lichboss;

    [SerializeField] private bool canSpawn = true;
    //[SerializeField] private bool bossCanSpawn = false;
    private float enemyNumber;
    private float bossNumber;

    private bool canChangeScene = false;

    [SerializeField] private GameObject levelTransition;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
        StartCoroutine(CanChangeLevel());
        levelTransition.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyNumber >= 30)
        {
            canSpawn = false;
        }
        if (enemyNumber == 20)
        {
            if (bossNumber < 1)
            {
                SpawnBoss();
            }
            
        }

        if(canChangeScene)
        {
            levelTransition.SetActive(true);
        }

    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;
            int rand = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyToSpawn = enemyPrefabs[rand];

            Instantiate(enemyToSpawn, new Vector3(Random.Range(-6f, 6), Random.Range(-6f, 6f), 3), Quaternion.identity);
            enemyNumber = enemyNumber + 1;
        }
    }

    private IEnumerator CanChangeLevel()
    {
        yield return new WaitForSeconds(60);
        canChangeScene = true;
    }

    private void SpawnBoss()
    {
        Instantiate(lichboss, new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 3), Quaternion.identity);
        bossNumber = bossNumber + 1;
    }
}
