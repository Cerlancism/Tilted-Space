using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public enum State { IDLE, ASTEROID };
    public State state = State.IDLE;

    public float enemyZ = -1;
    public float width;
    public float height;

    public Transform asteroid;
    public float chancePerSecond = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		switch (state)
        {
            case State.ASTEROID:
                if (Random.value < chancePerSecond * Time.deltaTime)
                {
                    // Spawn asteroid
                    Instantiate(asteroid, new Vector3(
                        Random.Range(transform.position.x - height / 2, transform.position.x + height / 2),
                        transform.position.y + height / 2, enemyZ), Quaternion.Euler(0, 0, Random.Range(0, 360)));
                }
                break;
        }
	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 1));
    }
}
