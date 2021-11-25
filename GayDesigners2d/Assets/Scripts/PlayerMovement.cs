using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private LayerMask layerMask;
    private Rigidbody2D rb;
    private BoxCollider2D boxColider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;


    private void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        boxColider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Jump");

        //Reset MoveDelta
        moveDelta = new Vector3(x, y, 0);

        //Swap sprite direction, wether youre going right or left
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);


        // Making move
        hit = Physics2D.BoxCast(transform.position, boxColider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Floor"));
        if (hit.collider == null)
            rb.velocity = new Vector2(x * 10f, rb.velocity.y);

        //Jump
        if (IsGrounded() && y > 0 )
        {
            rb.velocity = new Vector2(rb.velocity.x, y * 10f);
       
        }
    }

    private bool IsGrounded()
    {
       RaycastHit2D rch2d = Physics2D.BoxCast(boxColider.bounds.center, boxColider.bounds.size, 0f, Vector2.down*0.1f,0.01f, layerMask);
        Debug.Log(rch2d.collider);
       return rch2d.collider != null;
        
    }
    
}