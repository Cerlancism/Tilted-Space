using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfScreenDespawner : MonoBehaviour
{
    public float limitWidth;
    public float limitHeight;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -limitWidth / 2 || transform.position.x > limitWidth / 2 ||
            transform.position.y < -limitHeight / 2 || transform.position.y > limitHeight / 2)
        {
            Destroy(gameObject);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector3(0, 0, 0), new Vector3(limitWidth, limitHeight, 1));
    }
}
