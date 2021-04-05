using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManiger : MonoBehaviour
{
    //TODO ADD UI CODE
    [SerializeField]
    private int MaxHealth;
    private int health;
    public int Health
    {
        get 
        {
            return health;
        }
        set
        {
            if(value < MaxHealth && value > 0)
            {
                health = value;
            }
        }
    }
    private void Start()
    {
        health = MaxHealth;
    }
    private Transform respawnPoint;
    public void changeSpawn(Transform newSpawn)
    {
        respawnPoint = newSpawn;
    }
    public void DealDamage(int dammage)
    {
        health -= dammage;
        if (health <= 0)
        {
            death();
        }
    }
    public void Heal(int amount)
    {
        health += amount;
        if(health > MaxHealth)
        {
            health = MaxHealth;
        }
    }
    public void death()
    {
        // here is where we would do death animation
        //TODO add code to wait for death animation
        gameObject.transform.position = respawnPoint.position;
        health = MaxHealth;
    }
}
