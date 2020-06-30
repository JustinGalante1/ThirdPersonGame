using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrackerController : MonoBehaviour
{
    private EnemyBasic eb;
    public Animator animator;
    private float swingDelay;
    public float swingDelayAmount;

    private void Start()
    {
        eb = this.GetComponent<EnemyBasic>();
        swingDelay = 0;
    }

    private void Update()
    {
        if(eb.inRange && eb.seesPlayer)
        {
            //Debug.Log(eb.inRange);
            swingSword();
        }
    }

    private void LateUpdate()
    {
        if(swingDelay > 0)
        {
            swingDelay -= Time.deltaTime;
        }
    }

    private void swingSword()
    {
        if(swingDelay <= 0)
        {
            swingDelay = swingDelayAmount;
            if(eb.getStunLock() == false)
            {
                animator.SetTrigger("SwingSword");
            }
        }
    }

}
