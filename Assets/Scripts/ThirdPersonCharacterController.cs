using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Third Person Game
public class ThirdPersonCharacterController : MonoBehaviour {

    public Rigidbody rb;
    private HealthSystem hs;
    public Animator animator;
    private PlayerAttack playerAttackController;

    public float speed;
    public float sprintSpeed;
    public bool isGrounded;
    public float GravityStrength;
    public float jumpHeight;
    public float combatDelay;
    public float jumpDelay;

    float timeDelay = 0;

    public bool ignoreInput; //from animations
    public bool allowMovement; //from inventory and game controller

    private float h;
    private float v;
    private float fakeV;
    private float tempV;
    private float curSprintSpeed;

    public int maxHealth;
    public int startHealth;

    void Start()
    {
        ignoreInput = false;
        allowMovement = true;

        rb = GetComponent<Rigidbody>();
        hs = GetComponent<HealthSystem>();
        playerAttackController = GetComponent<PlayerAttack>();

        curSprintSpeed = 0;
        isGrounded = true;

        Vector3 gravityS = new Vector3(0, GravityStrength, 0);
        Physics.gravity = gravityS;

        hs.setHealth(startHealth);
        hs.setHealthMax(maxHealth);
        hs.setHealthDisplay();

        //debug();
    }

    void debug()
    {
        Debug.Log("Health: " + hs.getHealth());
        
    }
    
    void PlayerMovement(float h, float v)
    {     
        Vector3 moveX = rb.transform.right * h;
        Vector3 moveZ = rb.transform.forward * v;
        Vector3 movement = moveX + moveZ;
        movement.y = 0;

        if (v < 0)
        {
            animator.SetBool("WalkingBack", true);
        }
        else
        {
            animator.SetBool("WalkingBack", false);
        }

        if (v > 0)
        {
            animator.SetBool("MovingForward", true);
        }
        else
        {
            animator.SetBool("MovingForward", false);
        }

        movement = movement * (speed + curSprintSpeed) * Time.deltaTime;

        rb.MovePosition(transform.position + movement);

        if (rb.transform.position.y < -4)
        {
            rb.transform.position = new Vector3(0, 0.5f, 0);
        }
    }

    public void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && jumpDelay <= 0)
        {
            animator.SetTrigger("Jump");
        }
    }

    private void FixedUpdate()
    {
        if(ignoreInput == false)
        {
            PlayerMovement(h, v);
        }
    }

    private void Update()
    {
        if(allowMovement == true)
        {
            getWASD();
            if(ignoreInput == false)
            {
                jump();
                playerCrouch();
                playerAttackController.melee(animator);
                playerAttackController.throwShuriken(animator);
                rollForward();
                setSprintSpeed();
            }
        }

        if(v <= 1)
        {
            fakeV = Mathf.Lerp(v, 1, 0, Time.deltaTime);
        }
        else
        {
            fakeV = v;
        }
        animator.SetFloat("Speed", v * (speed + curSprintSpeed));

    }

    private void LateUpdate()
    {
        if(timeDelay > 0)
        {
            timeDelay -= Time.deltaTime;
        }

        if (combatDelay > 0)
        {
            combatDelay -= Time.deltaTime;
        }

        if(jumpDelay > 0)
        {
            jumpDelay -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            isGrounded = true;
        }

    }

    private void getWASD()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        Debug.Log(v);
        //animator.SetFloat("Forward", Input.GetAxis("Vertical"));
        //animator.SetFloat("Turn", Input.GetAxis("Horizontal"));
    }

    private void setSprintSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift) && v > 0) {
            if ((speed + curSprintSpeed) < sprintSpeed)
            {
                curSprintSpeed += Time.deltaTime * 5;
            }
        }
        else // slow down
        {
            if (curSprintSpeed > 0)
            {
                curSprintSpeed -= Time.deltaTime * 7;
            }
            else
            {
                curSprintSpeed = 0;
            }
        }
        
    }

    private void playerCrouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", false);
        }

    }

    private void rollForward()
    {
        if (Input.GetKey(KeyCode.R))
        {
            animator.SetTrigger("RollForward");
        }
    }

    public HealthSystem getHS()
    {
        return this.hs;
    }

    public void hasBeenSeen()
    {
        combatDelay = 5;
    }

}
