using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamScript : MonoBehaviour {

    // === Public Variables ====
    public float Speed;
	
	
	// === Private Variables ====
	private Rigidbody2D rb;
	
	
	// Use this for initialization
	void Start () 
	{
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity= new Vector2(0, Speed);
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (Camera.main.WorldToViewportPoint(transform.position).y > 1)
        {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            rb.velocity = new Vector2 (0, 0);
            gameObject.GetComponent<Animator>().SetTrigger("Hit");
            Destroy(gameObject, gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        }
    }
}
