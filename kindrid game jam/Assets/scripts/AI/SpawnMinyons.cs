using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMinyons : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private int AmountPerCycle;
    [SerializeField]
    private int timebetweenSpawn;
    [SerializeField]
    private AIbrain brain;
    [SerializeField]
    private Transform[] spawnLocation;
    // Start is called before the first frame update
    void Start()
    {
        brain = gameObject.GetComponent<AIbrain>();
        StartCoroutine("spawn");
    }
    IEnumerator spawn()
    {
        while(brain.alive == true)
        {
            for (int i=0; i < AmountPerCycle;i++) 
            {
                Instantiate(enemy, spawnLocation[i].position, spawnLocation[i].rotation);
            }
            yield return new WaitForSecondsRealtime(timebetweenSpawn);
        }
    }
}
