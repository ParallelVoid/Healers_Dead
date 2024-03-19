using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float enemyInterval = 3.5f;

    private float enemyNumber;
    private bool enemyCanSpawn = true;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(enemyInterval, enemyPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy){
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        enemyNumber = enemyNumber + 1;
        if (enemyNumber < 10 && enemyCanSpawn) {
            StartCoroutine(spawnEnemy(interval, enemy));
        }
        else if (enemyNumber >= 10) {
            enemyCanSpawn = false;
        }
       
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
