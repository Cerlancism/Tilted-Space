using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    private float timePassedSinceLastStateChange = 0;
    public enum State { IDLE, ASTEROID, GREEN_UFO };
    public State state = State.IDLE;

    public float enemyZ = -1;
    public float width;
    public float height;

    public Transform[] asteroids;
    public float asteroidChancePerSecond = 1;
    public float asteroidTorqueMin = -50;
    public float asteroidTorqueMax = 50;
    public Vector2 asteroidForceMin = new Vector2(-300, -200);
    public Vector2 asteroidForceMax = new Vector2(300, 500);
    public float asteroidSizeMin = 1;
    public float asteroidSizeMax = 3;
    public float asteroidDuration = 10;
    public State asteroidNextState = State.GREEN_UFO;

    public Transform greenUFO;
    public float greenUFOChancePerSecond = 1;
    public float greenUFODuration = 10;
    public State greenUFONextState = State.IDLE;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Update time
        timePassedSinceLastStateChange += Time.deltaTime;

        switch (state)
        {
            case State.ASTEROID:
                if (Random.value < asteroidChancePerSecond * Time.deltaTime)
                {
                    // Spawn asteroid
                    Transform newAsteroid = (Transform) Instantiate(RandomSelect(asteroids), new Vector3(
                        Random.Range(transform.position.x - width / 2, transform.position.x + width / 2),
                        transform.position.y + height, enemyZ), Quaternion.Euler(0, 0, Random.Range(0, 360)));

                    float size = Random.Range(asteroidSizeMin, asteroidSizeMax);
                    newAsteroid.localScale = new Vector3(size, size, 1);

                    Rigidbody2D rb = newAsteroid.gameObject.GetComponent<Rigidbody2D>();
                    rb.AddForce(new Vector2(Random.Range(asteroidForceMin.x, asteroidForceMax.x), Random.Range(asteroidForceMin.y, asteroidForceMax.y)));
                    rb.AddTorque(Random.Range(asteroidTorqueMin, asteroidTorqueMax));
                }

                // Change state if time up
                if (timePassedSinceLastStateChange >= asteroidDuration)
                {
                    ChangeState(asteroidNextState);
                }

                break;

            case State.GREEN_UFO:
                if (Random.value < greenUFOChancePerSecond * Time.deltaTime)
                {
                    // Spawn green UFO
                    Transform newGreenUFO = (Transform) Instantiate(greenUFO, new Vector3(
                        Random.Range(transform.position.x - width / 2, transform.position.x + width / 2),
                        transform.position.y + height, enemyZ), Quaternion.Euler(0, 0, Random.Range(0, 360)));
                }

                // Change state if time up
                if (timePassedSinceLastStateChange >= greenUFODuration)
                {
                    ChangeState(greenUFONextState);
                }

                break;
        }
	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(new Vector3(-width / 2, height, 0), new Vector3(width / 2, height, 0));
    }

    Object RandomSelect(Object[] array)
    {
        return array[Random.Range(0, array.Length - 1)];
    }

    void ChangeState(State newState)
    {
        state = newState;

        // Reset time
        timePassedSinceLastStateChange = 0;
    }
}
