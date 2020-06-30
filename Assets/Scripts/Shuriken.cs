using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    public float speed = 20f;
    public float rotationSpeed = 10f;
    private Rigidbody rb;
    public float lifeDuration;
    private float lifeTimer;
    public int damage;
    private bool hit;

    private void Start()
    {
        hit = false;
        lifeTimer = lifeDuration;
        rb = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!hit)
        {
            rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
        }
        
        lifeTimer -= Time.deltaTime;
        if(lifeTimer <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hit)
        {
            if (collision.collider.CompareTag("Enemy") || collision.collider.CompareTag("Player"))
            {
                HealthSystem hs = collision.collider.GetComponent<HealthSystem>();
                hs.damage(damage);
                if (hs.gracePeriod <= 0)
                {
                    hs.gracePeriod = 1;
                }
            }
        }
        hit = true;
        rb.useGravity = true;
        speed /= 0;
    }
}
