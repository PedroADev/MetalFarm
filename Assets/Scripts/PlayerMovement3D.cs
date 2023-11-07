using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rb;

    private Vector3 _movement;
    
    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.z = Input.GetAxisRaw("Vertical");
    }
    
    private void FixedUpdate()
    {
        if (_movement.magnitude > 0f)
        {
            transform.Translate(_movement.normalized * 0.1f, Space.World);
            transform.rotation = Quaternion.LookRotation(_movement, Vector3.up);
        }
    }
}
