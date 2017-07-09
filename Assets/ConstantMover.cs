using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMover : MonoBehaviour {
    public float velocityX;
    public float velocityY;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector2(velocityX * Time.deltaTime, velocityY * Time.deltaTime), Space.World);
	}

    public void SetVelocity(Vector2 velocity)
    {
        velocityX = velocity.x;
        velocityY = velocity.y;
    }
}
