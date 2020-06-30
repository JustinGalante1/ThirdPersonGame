using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    private HealthSystem playerHealth;
    public int healAmount;

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();
    }

    public void heal()
    {
        Debug.Log("healing");
        playerHealth.heal(healAmount);
    }
}
