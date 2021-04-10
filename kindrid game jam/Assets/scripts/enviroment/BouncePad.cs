using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    [SerializeField]
    private float jumpForce;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            gameObject.GetComponent<Animator>().SetBool("Bounce", true);
            collision.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }

    }
    public void BounceOver()
    {
        gameObject.GetComponent<Animator>().SetBool("Bounce", false);
    }
}
