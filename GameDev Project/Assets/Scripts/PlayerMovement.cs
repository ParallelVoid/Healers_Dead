using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;

    private Vector2 moveDirection;
    private Animator anim;

    private bool facingLeft;

    

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        //FindObjectOfType<AudioManager>().Play("PlayerWalk");
    }

    void FixedUpdate()
    {
        Move();
        if(Input.GetAxisRaw("Horizontal") > 0 && !facingLeft)
        {
            Flip();
        }
        if(Input.GetAxisRaw("Horizontal") < 0 && facingLeft)
        {
            Flip();
        }
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= 1;
        gameObject.transform.localScale = currentScale;

        facingLeft = !facingLeft;
    }





}