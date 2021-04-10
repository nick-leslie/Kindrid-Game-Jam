using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinyeetmvmnt : MonoBehaviour
{
    public float SPEED = 5F;


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(SPEED * Time.deltaTime, 0, 0);
    }

    void OnTriggerStay2D(Collider2D frank)
    {
        Destroy(gameObject);
    }
}

