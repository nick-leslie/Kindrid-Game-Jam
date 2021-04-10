using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
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
    [SerializeField]
    private Sprite[] spriteAnimations;
    [SerializeField]
    private float TimeBetweenSpriteChage;
    [SerializeField]
    private sceneManiger sManiger;
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
            StartCoroutine(HealthAniamtion(TimeBetweenSpriteChage, health-1, 1));
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
            StartCoroutine(HealthAniamtion(TimeBetweenSpriteChage, health - 1, -1));
        }
        else
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
        StopAllCoroutines();
        for (int i = 0; i < hearts.Length; i++)
        {
            while (hearts[i].GetComponent<Image>().sprite != spriteAnimations[0])
            {
                hearts[i].GetComponent<Image>().sprite = spriteAnimations[0];
            }
        }
        StartCoroutine(WaitToReload(0.2f));
    }
    IEnumerator WaitToReload(float timeDelay)
    {
        yield return new WaitForSecondsRealtime(timeDelay);
        sManiger.ReloadLvl();
    }

    IEnumerator HealthAniamtion(float timeDelay,int index,int dire)
    {
        if(dire == 1) {
            for (int i = 0; i < spriteAnimations.Length; i++)
            {
                yield return new WaitForSecondsRealtime(timeDelay);
                hearts[index].GetComponent<Image>().sprite = spriteAnimations[i];
            }
        } 
        else
        {
            for (int i = spriteAnimations.Length-1; i >= 0; i--)
            {
                yield return new WaitForSecondsRealtime(timeDelay);
                hearts[index].GetComponent<Image>().sprite = spriteAnimations[i];
            }
        }
    }
}
