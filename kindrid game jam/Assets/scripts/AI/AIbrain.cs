using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIbrain : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float raySize;
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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
