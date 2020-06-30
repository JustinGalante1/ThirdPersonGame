using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject shurikenPrefab;
    private float shurikenDelay;
    public float shurikenDelayAmount;
    //private Transform playerTarget; // where player is looking

    private void Start()
    {
        //playerTarget = GameObject.FindGameObjectWithTag("PlayerTarget").transform;
        shurikenDelay = 0;
    }

    private void LateUpdate()
    {
        if(shurikenDelay > 0)
        {
            shurikenDelay -= Time.deltaTime;
        }
    }

    public void melee(Animator animator)
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
        }
    }

    public void throwShuriken(Animator animator)
    {
        if (Input.GetMouseButton(1) && shurikenDelay <= 0)
        {
            GameObject shurikenObject = Instantiate(shurikenPrefab);
            shurikenObject.layer = 9;
            shurikenObject.transform.position = this.transform.position + transform.forward * 2;
            shurikenObject.transform.rotation = Camera.main.transform.rotation;
            shurikenDelay = shurikenDelayAmount;
        }
    }
}
