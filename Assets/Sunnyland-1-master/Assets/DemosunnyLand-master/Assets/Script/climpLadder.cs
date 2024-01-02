using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class climpLadder : MonoBehaviour
{
   private float vertical;
    private float speed = 8f;
    private bool isLadder;
    private bool isClimbing;
    private Animator anim;

    [SerializeField] private Rigidbody2D rb;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");

        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
            anim.SetBool("climp", true);
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {
            rb.gravityScale = 2.5f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}
