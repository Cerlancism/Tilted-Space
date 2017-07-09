using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    // === Public Variables ====
    public float Speed;
    public int Damage;

    // === Private Variables ====
    private Rigidbody2D rb;
    private AudioSource SFX;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, Speed);

        SFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
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
            SFX.PlayOneShot(SFX.clip, 0.08f);
            rb.velocity = new Vector2(0, 0);
            gameObject.GetComponent<Animator>().SetTrigger("Hit");
            Destroy(gameObject, gameObject.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0).Length * 0.6f);
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            SFX.PlayOneShot(SFX.clip, 0.8f);
            rb.velocity = new Vector2(0, 0);
            gameObject.GetComponent<Animator>().SetTrigger("Hit");
            Destroy(gameObject, gameObject.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0).Length);
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}
