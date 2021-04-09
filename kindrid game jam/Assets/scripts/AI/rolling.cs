using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rolling : MonoBehaviour
{
    [SerializeField]
    private int dire;
    [SerializeField]
    private float roatationSpeed;
    private Rigidbody2D rb;
    [SerializeField]
    private float MoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, dire * roatationSpeed * Time.deltaTime); //rotates 50 degrees per second around z axis
        rb.velocity = new Vector2(dire * MoveSpeed, rb.velocity.y);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            collision.collider.gameObject.GetComponent<HealthManiger>().death();
        }
    }
}
