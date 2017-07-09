using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    public Transform target;
    public float speed = 0.05f;
    public float minimumDistanceFromTarget = 1;

    // Use this for initialization
    void Start()
    {
        if (!target)
            target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 difference = target.position - transform.position;
        float distance = difference.magnitude;

        if (distance > minimumDistanceFromTarget)
        {
            Vector2 direction = difference.normalized;
            Vector2 movement = direction * speed;
            transform.Translate(movement, Space.World);
        }
    }
}
