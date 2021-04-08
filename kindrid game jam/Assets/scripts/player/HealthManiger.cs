using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthManiger : MonoBehaviour
{
    //TODO ADD UI CODE
    [SerializeField]
    private int MaxHealth;
    [SerializeField]
    private int health;
    private GameObject HealthCanvus;
    [SerializeField]
    private GameObject HealthPrefb;
    private GameObject[] hearts;
    [SerializeField]
    private Transform startPos;
    [SerializeField]
    private Vector3 offset;
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
        hearts = new GameObject[MaxHealth];
        HealthCanvus = GameObject.FindGameObjectWithTag("PlayerUI");
        //this should work but if not shit
        for(int i=0;i<hearts.Length;i++)
        {
            hearts[i] =Instantiate(HealthPrefb, (startPos.position + (offset * (i))) / HealthCanvus.GetComponent<Canvas>().scaleFactor,startPos.rotation);
            hearts[i].GetComponent<RectTransform>().SetParent(HealthCanvus.transform);        }
    }
    private Transform respawnPoint;
    public void changeSpawn(Transform newSpawn)
    {
        respawnPoint = newSpawn;
    }
    public void DealDamage(int dammage)
    {
        if (health - dammage >= 0)
        {
            hearts[health-1].SetActive(false);
            health -= dammage;
        }
        if (health <= 0)
        {
            death();
        }
    }
    public void Heal(int amount)
    {
        if (health + amount <= MaxHealth) {
            health += amount;
            hearts[health].SetActive(true);
        }
        else
        {
            health = MaxHealth;
            hearts[health].SetActive(true);
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
