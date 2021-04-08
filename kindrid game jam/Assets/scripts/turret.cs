using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    public GameObject Bullet;
    public Transform shotLocation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
       
    }
   

    public void shoot()
    {
        Instantiate(Bullet,shotLocation.position, shotLocation.rotation);
    }
}
