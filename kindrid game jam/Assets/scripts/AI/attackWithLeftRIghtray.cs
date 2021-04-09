using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackWithLeftRIghtray : MonoBehaviour
{
    private RaycastHit2D attackRay;
    [SerializeField]
    private Transform locataion;
    [SerializeField]
    private float frountDire;
    private AIbrain brain;
    // Start is called before the first frame update
    void Start()
    {
        brain = gameObject.GetComponent<AIbrain>();
    }

    // Update is called once per frame
    void Update()
    {
        attackRay = Physics2D.Raycast(locataion.transform.position, frountDire * Vector2.right, brain.RaySize);
        if(attackRay.collider != null)
        {
            if(attackRay.collider.CompareTag("Player"))
            {
                brain.attack();
            }
        }
    }
}
