using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtOnCollison : MonoBehaviour
{
    [SerializeField]
    private int dammage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<HealthManiger>().DealDamage(dammage);
        }
    }
}
