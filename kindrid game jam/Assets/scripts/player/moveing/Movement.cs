using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{   
    //--------------------- values
    [Header("movement")]
    [SerializeField]
    private float MovementSpeed;
    [SerializeField]
    private Vector2 moveDire;
    [Header("Jump")]
    [SerializeField]
    private float jumpVelocity;
    private bool canJump;
    [SerializeField]
    private float JumpWaitTime;
    private bool jumpOveride;
    //------------------- refrences
    private Rigidbody2D rb;
    [SerializeField]
    private GameObject groundedManiger;
    //------------------- stop testing
    public bool deadStop;
    //public float stopSpeed;
    public float lerpSpeed;
    //public Vector2 velcocity;
    //private BoxCollider2D groundedManiger()
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity += moveDire * MovementSpeed * Time.deltaTime;
        rb.velocity = Vector2.Lerp(rb.velocity, new Vector2(moveDire.x * MovementSpeed, rb.velocity.y), lerpSpeed);
        //velcocity = rb.velocity;
        if(groundedManiger.GetComponent<grounedManiger>().Grouned == true && jumpOveride == false)
        {
            canJump = true;
        }
        //canJump = groundedManiger.GetComponent<grounedManiger>().Grouned;
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (canJump == true && groundedManiger.GetComponent<grounedManiger>().Grouned ==true)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
                canJump = false;
                jumpOveride = true;
                StartCoroutine("waitToJump");
                //Debug.Log("jumped");
            }
        }
    }
    public void Move(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Canceled)
        {
            moveDire = context.ReadValue<Vector2>();
        } else
        {
                moveDire = Vector2.zero;
               // rb.velocity *=  stopSpeed * Time.deltaTime;
        }
    }
    IEnumerator waitToJump()
    {
        yield return new WaitForSecondsRealtime(JumpWaitTime);
        jumpOveride = false;
    }
}
