using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtOnCollison : MonoBehaviour
{
    [SerializeField]
    private int dammage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<HealthManiger>().DealDamage(dammage);
        }
    }
}
