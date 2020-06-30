using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour
{
    private ThirdPersonCharacterController player;
    private Transform playerFace;
    public GameObject enemyFace;
    public Animator animator;

    private Rigidbody rb;
    private HealthSystem hs;

    private RaycastHit hit;

    public float moveSpeed;
    
    public float sightRange;
    
    public float stopDistance;
    public int damageToDeal;

    public int maxHealth;
    public int startHealth;

    public bool inRange;
    public bool seesPlayer;

    private float stunLockTimer;
    private bool isStunned;
    private bool isAttacking;

    void Start()
    {
        playerFace = GameObject.FindGameObjectWithTag("PlayerFace").transform;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonCharacterController>();

        inRange = false;
        seesPlayer = false;

        rb = this.GetComponent<Rigidbody>();
        hs = this.GetComponent<HealthSystem>();

        hs.setHealth(startHealth);
        hs.setHealthMax(maxHealth);
    }

    private void Update()
    {
        if(hs.getHealth() <= 0)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        enemyFace.transform.LookAt(playerFace);

        if (Physics.Raycast(enemyFace.transform.position, enemyFace.transform.forward, out hit, sightRange))
        {
            if (hit.collider.CompareTag("Player"))
            {
                player.hasBeenSeen();
                seesPlayer = true;

                transform.rotation = enemyFace.transform.rotation;
                if (Vector3.Distance(transform.position, playerFace.position) >= stopDistance)
                {
                    inRange = false;
                    if(isStunned == false)
                    {
                        if (getAttacking() == false)
                        {
                            animator.SetBool("MovingForward", true);
                            rb.MovePosition(transform.position + enemyFace.transform.forward * moveSpeed * Time.deltaTime);
                        }
                    }
                }
                else
                {
                    inRange = true;
                    animator.SetBool("MovingForward", false);
                }
            }
            else
            {
                seesPlayer = false;
            }
        }
    }

    private void LateUpdate()
    {
        if(stunLockTimer > 0)
        {
            stunLockTimer -= Time.deltaTime;
        }
    }

    public void stun()
    {
        animator.SetTrigger("Stunned");
    }

    public void setStunLock()
    {
        isStunned = true;
    }

    public void resetStunLock()
    {
        isStunned = false;
    }

    public bool getStunLock()
    {
        return isStunned;
    }

    public void setAttacking()
    {
        isAttacking = true;
    }

    public void resetAttacking()
    {
        Debug.Log("attack reset");
        isAttacking = false;
    }

    public bool getAttacking()
    {
        return isAttacking;
    }
}
