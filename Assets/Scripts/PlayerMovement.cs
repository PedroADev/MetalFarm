using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;

    private Vector2 _movement;
    
    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
    }

   

private void FixedUpdate()
    {
        rb.MovePosition(rb.position + _movement * (moveSpeed * Time.fixedDeltaTime));
    }
}
