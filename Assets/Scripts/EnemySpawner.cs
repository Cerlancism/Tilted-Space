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
    public float asteroidTorqueMin = -50;
    public float asteroidTorqueMax = 50;
    public Vector2 asteroidForceMin = new Vector2(-200, -200);
    public Vector2 asteroidForceMax = new Vector2(200, -500);
    public float asteroidSizeMin = 1;
    public float asteroidSizeMax = 3;

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
                    Transform newAsteroid = (Transform) Instantiate(asteroid, new Vector3(
                        Random.Range(transform.position.x - height / 2, transform.position.x + height / 2),
                        transform.position.y + height / 2, enemyZ), Quaternion.Euler(0, 0, Random.Range(0, 360)));

                    float size = Random.Range(asteroidSizeMin, asteroidSizeMax);
                    newAsteroid.localScale = new Vector3(size, size, 1);

                    Rigidbody2D rb = newAsteroid.gameObject.GetComponent<Rigidbody2D>();
                    rb.AddForce(new Vector2(Random.Range(asteroidForceMin.x, asteroidForceMax.x), Random.Range(asteroidForceMin.y, asteroidForceMax.y)));
                    rb.AddTorque(Random.Range(asteroidTorqueMin, asteroidTorqueMax));
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
