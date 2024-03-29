using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LichRangedAttack : MonoBehaviour
{
    public float distance;

    public Transform shotPoint;
    public GameObject projectile;
 
    private Transform player;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public static bool lichIsAttacking;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < 10)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (timeBtwShots <= 0 && projectile != null) 
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
                lichIsAttacking = true;
            }
            else {
                timeBtwShots -= Time.deltaTime;
                lichIsAttacking = false;
            }
    }


}
