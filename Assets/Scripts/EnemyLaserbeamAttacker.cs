using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserbeamAttacker : MonoBehaviour
{
    public Transform enemyLaserbeam;
    public Transform target;
    public float chancePerSecond = 1;
    public float inaccuracy = 20;

    // Use this for initialization
    void Start()
    {
        if (!target)
            target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.value < chancePerSecond * Time.deltaTime)
        {
            // Calculate angle
            Vector2 displacement = target.position - transform.position;
            float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg - 90;
            angle += Random.Range(-inaccuracy / 2, inaccuracy / 2);

            // Spawn enemy projectile
            Transform newLaserbeam = Instantiate(enemyLaserbeam, transform.position, Quaternion.Euler(0, 0, angle));
        }
    }
}
