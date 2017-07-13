using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitPoint : MonoBehaviour {

    // === Public Variables ====
    public GameObject Explosion;
    public int HitPoints;
	
	
	// === Private Variables ====
	
	
	
	// Use this for initialization
	void Start () 
	{
    }
	
	// Update is called once per frame
	void Update () 
	{
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Projectile"))
        {
            GlobalManagement.ChangeScore(collision.gameObject.GetComponent<ProjectileScript>().Damage);
            HitPoints = HitPoints - collision.gameObject.GetComponent<ProjectileScript>().Damage;
            if (HitPoints <= 0)
            {
                var exp = Instantiate(Explosion, transform.position, Quaternion.identity);
                exp.transform.localScale = exp.transform.localScale * gameObject.GetComponent<Renderer>().bounds.size.x * 0.75f;
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Projectile"))
        {
            GlobalManagement.ChangeScore(collision.gameObject.GetComponent<ProjectileScript>().Damage);
            HitPoints = HitPoints - collision.gameObject.GetComponent<ProjectileScript>().Damage;
            if (HitPoints <= 0)
            {
                var exp = Instantiate(Explosion, transform.position, Quaternion.identity);
                exp.transform.localScale = exp.transform.localScale * gameObject.GetComponent<Renderer>().bounds.size.x * 0.75f;
                Destroy(gameObject);
            }
        }
    }

}
