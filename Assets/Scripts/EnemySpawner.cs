﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    private float timePassedSinceLastStateChange = 0;
    public enum State { IDLE, ASTEROID, GREEN_UFO };
    public State state = State.IDLE;

    public float enemyZ = -1;

    public Transform[] asteroids;
    public float asteroidChancePerSecond = 1;
    public float asteroidTorqueMin = -50;
    public float asteroidTorqueMax = 50;
    public float asteroidForceMin = 200;
    public float asteroidForceMax = 500;
    public float asteroidSizeMin = 1;
    public float asteroidSizeMax = 3;
    public float asteroidSpawnRadius;
    public Vector2 asteroidTargetSize;
    public float asteroidDuration = 10;
    public State asteroidNextState = State.GREEN_UFO;

    public Transform greenUFO;
    public float greenUFOChancePerSecond = 1;
    public float greenUFOSpawnRadius;
    public Vector2 greenUFOTargetSize;
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
                    // Spawn somewhere on the spawn circle (blue circle)
                    // newPosition is based around 0,0
                    Vector2 newPosition = Random.insideUnitCircle.normalized * asteroidSpawnRadius;
                    Transform newAsteroid = (Transform) Instantiate(RandomSelect(asteroids),
                        transform.position + new Vector3(newPosition.x, newPosition.y, enemyZ), 
                        Quaternion.Euler(0, 0, Random.Range(0, 360)));

                    // Random size
                    float size = Random.Range(asteroidSizeMin, asteroidSizeMax);
                    newAsteroid.localScale = new Vector3(size, size, 1);
                    newAsteroid.gameObject.GetComponent<EnemyHitPoint>().HitPoints = (int) ((float)newAsteroid.gameObject.GetComponent<EnemyHitPoint>().HitPoints * size);

                    // Add random torque
                    // Add random force towards target position, which is a random point inside the target boundaries (green box)
                    Rigidbody2D rb = newAsteroid.gameObject.GetComponent<Rigidbody2D>();
                    Vector2 targetPosition = new Vector2(
                        Random.Range(-asteroidTargetSize.x / 2, asteroidTargetSize.x / 2), 
                        Random.Range(-asteroidTargetSize.y / 2, asteroidTargetSize.y / 2));
                    rb.AddForce((targetPosition - newPosition).normalized * Random.Range(asteroidForceMin, asteroidForceMax));
                    rb.AddTorque(Random.Range(asteroidTorqueMin, asteroidTorqueMax));
                }

                // Change state if time up
                if (timePassedSinceLastStateChange >= asteroidDuration)
                {
                    ChangeState(asteroidNextState);
                }

                break;

            /*case State.GREEN_UFO:
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

                break;*/
        }
	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, asteroidSpawnRadius);
        Gizmos.DrawWireSphere(transform.position, greenUFOSpawnRadius);

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(asteroidTargetSize.x, asteroidTargetSize.y, 1));
        Gizmos.DrawWireCube(transform.position, new Vector3(greenUFOTargetSize.x, greenUFOTargetSize.y, 1));
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
