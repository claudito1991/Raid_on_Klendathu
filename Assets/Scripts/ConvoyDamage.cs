using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConvoyDamage : MonoBehaviour
{

    public int totalHealth;
    public int maxHealth;

    public static Action loseConditionTrue;

    public HealthManager healthBar;


void Start()
{
    totalHealth = maxHealth;
    healthBar.SetMaxHealth(totalHealth);

    
}
void OnEnable()
    {
        EnemyMovement.enemyCatched += TakeDamage;
    }

    public void TakeDamage(int damageTaken)
    {
        totalHealth -= damageTaken;
        if(totalHealth<= 0)
        {
            loseConditionTrue?.Invoke();
        }
        
        healthBar.SetHealth(totalHealth);
    }

     void OnDisable()
    {
        EnemyMovement.enemyCatched -= TakeDamage;
    }
        

}
