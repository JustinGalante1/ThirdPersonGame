using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    private int health;
    private int healthMax;
    public Slider healthBar;
    public float gracePeriod = 0;

    private float healthTimer;

    public void setHealth(int health)
    {
        this.health = health;
    }

    public void setHealthMax(int healthMax)
    {
        this.healthMax = healthMax;
    }

    public float getHealth()
    {
        return this.health;
    }

    public float getHealthMax()
    {
        return this.healthMax;
    }

    public void damage(int damage)
    {
        if(gracePeriod <= 0)
        {
            this.health -= damage;
            setHealthDisplay();
        }
    }

    public void heal(int amount)
    {
        this.health += amount;
        setHealthDisplay();
    }

    public float getPercent()
    {
        return this.getHealth() / this.getHealthMax(); 
    }

    public void setHealthDisplay()
    {
        healthBar.value = getPercent();
    }

    private void LateUpdate()
    {
        if (gracePeriod > 0)
        {
            gracePeriod -= Time.deltaTime;
        }

    }

}
