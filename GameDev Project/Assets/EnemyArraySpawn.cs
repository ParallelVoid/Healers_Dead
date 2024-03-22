using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArraySpawn : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;

    [SerializeField] private GameObject[] enemyPrefabs;

    [SerializeField] private bool canSpawn = true;
    private float enemyNumber;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyNumber >= 20)
        {
            canSpawn = false;
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
}
