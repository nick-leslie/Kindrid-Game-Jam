using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIbrain : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float raySize;
    [SerializeField]
    private Transform attackPos;
    [SerializeField]
    private Vector3 attackSize;
    [SerializeField]
    private int Dammage;
    [SerializeField]
    public bool alive; // this is to protect from an infint loop in spaw minyohs
    
    public float Speed
    {
        get
        {
            return speed;
        }
    }
    public float RaySize
    {
        get
        {
            return raySize;
        }
    }
    public void attack()
    {
        //trigger animation
        gameObject.GetComponent<Animator>().SetBool("shouldKick", true);
    }
    public void DealDammage()
    {
        Collider2D[] thingsInZone = Physics2D.OverlapBoxAll(attackPos.position, attackSize, 0);
        for (int i = 0; i < thingsInZone.Length; i++)
        {
            if (thingsInZone[i].CompareTag("Player"))
            {
                thingsInZone[i].GetComponent<HealthManiger>().DealDamage(Dammage);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(attackPos.position, attackSize);
    }
    public void Die()
    {

        Destroy(gameObject);
    }
}
