using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backAndForthAI : MonoBehaviour
{
    private GameObject pathfinder;
    [SerializeField]
    private AIbrain brain;
    [SerializeField]
    private float moveDire;
    [SerializeField]
    private int frountOveride;
    //private AiCombat combat;
    [SerializeField]
    RaycastHit2D down;
    [SerializeField]
    RaycastHit2D leftRigt;
    [SerializeField]
    private bool AnimationControledWalk;
    // Start is called before the first frame update
    void Start()
    {
        pathfinder = gameObject.transform.GetChild(0).gameObject;
        brain = gameObject.GetComponent<AIbrain>();
        //Flip();
        //combat = transform.GetComponentInChildren<AiCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        down = Physics2D.Raycast(pathfinder.transform.position, -Vector2.up, brain.RaySize);
        leftRigt = Physics2D.Raycast(pathfinder.transform.position, (moveDire * frountOveride) * Vector2.right, brain.RaySize);
        if (down.collider != null && leftRigt.collider == null)
        {
            if (AnimationControledWalk == false)
            {
                transform.Translate(brain.Speed * Time.deltaTime, 0, 0);
            }
        }
        else
        {
                if (leftRigt.collider != null)
                {
                    if(leftRigt.collider.CompareTag("Player"))
                    {
                        brain.attack();   
                    }
                }
                else
                {
                    Flip();
                }
        }
        Debug.DrawRay(pathfinder.transform.position, -Vector2.up * brain.RaySize, color: Color.blue);
        Debug.DrawRay(pathfinder.transform.position, (moveDire * frountOveride) * Vector2.right * brain.RaySize, color: Color.blue);
    }
    public void Walk()
    {
        transform.Translate(brain.Speed * Time.deltaTime, 0, 0);
    }
    void Flip()
    {
        moveDire = moveDire * -1;
        if (transform.rotation.y == 0)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
}
