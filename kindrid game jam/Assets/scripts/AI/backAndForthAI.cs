using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backAndForthAI : MonoBehaviour
{
    private GameObject pathfinder;
    [SerializeField]
    private AIbrain brain;
    [SerializeField]
    private float moveDire = 1;
    //private AiCombat combat;
    [SerializeField]
    RaycastHit2D down;
    [SerializeField]
    RaycastHit2D leftRigt;
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
        leftRigt = Physics2D.Raycast(pathfinder.transform.position, moveDire * Vector2.left, brain.RaySize);
        if (leftRigt.collider != null)
        {
            Debug.Log(leftRigt.collider.name);
        }
        if (down.collider != null)
        {
            Debug.Log(down.collider.name);
        }
        if (down.collider != null && leftRigt.collider == null)
        {
            Debug.Log("should be fireing");
            transform.Translate(brain.Speed * Time.deltaTime, 0, 0);
        }
        else
        {
            if (leftRigt.collider != null)
            {
            
                //Flip();
            }
            else
            {
                //Flip();
            }
        }
        Debug.DrawRay(pathfinder.transform.position, -Vector2.up * brain.RaySize, color: Color.blue);
        Debug.DrawRay(pathfinder.transform.position, moveDire * Vector2.left * brain.RaySize, color: Color.blue);
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
