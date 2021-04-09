using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatforms : MonoBehaviour
{
    public Transform[] platformLocations;
    [SerializeField]
    private int targetInt;
    [SerializeField]
    private float MovmentSpeed;
    [SerializeField]
    private float closeDistence;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, platformLocations[targetInt].position,MovmentSpeed*Time.deltaTime);
        if(Vector2.Distance(transform.position, platformLocations[targetInt].position) <= closeDistence)
        {
            if(targetInt < platformLocations.Length-1)
            {
                targetInt++;
            } else
            {
                targetInt = 0;
            }
        }
    }
}
