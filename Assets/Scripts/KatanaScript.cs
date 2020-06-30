using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaScript : MonoBehaviour
{
    public int damage;
    private Collider katanaCollider;

    private void Start()
    {
        katanaCollider = this.GetComponent<Collider>();
        katanaCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Enemy") || collider.CompareTag("Player"))
        {
            HealthSystem hs = collider.GetComponent<HealthSystem>();
            hs.damage(damage);
            if (hs.gracePeriod <= 0)
            {
                hs.gracePeriod = 1;
            }
        }

        if (collider.CompareTag("Enemy"))
        {
            EnemyBasic eb = collider.GetComponent<EnemyBasic>();
            eb.stun();
        }
    }

    public void hitBoxOn()
    {
        katanaCollider.enabled = true;
    }

    public void hitBoxOff()
    {
        katanaCollider.enabled = false;
    }
}
