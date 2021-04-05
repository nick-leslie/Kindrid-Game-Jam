using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grounedManiger : MonoBehaviour
{
    public bool Grouned { 
        get
        {
            return grouned;
        } 
    }
    [SerializeField]
    private bool grouned;
    [SerializeField]
    private float coyoteTime;
    [SerializeField]
    private float landingTime;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(startCoyoteTime(landingTime));
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(grouned != true)
        {
            grouned = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(startCoyoteTime(coyoteTime));
    }
    IEnumerator startCoyoteTime(float timeing)
    {
        yield return new WaitForSecondsRealtime(timeing);
        grouned = !grouned;
    }
}
