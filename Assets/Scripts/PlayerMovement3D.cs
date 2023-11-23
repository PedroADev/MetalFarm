using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    public float moveSpeed;
    public Transform render;
    public Transform holder;

    private Vector3 _movement;

    [SerializeField] private CharacterAnimations characterAnimations;
    
    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.z = Input.GetAxisRaw("Vertical");
    }
    
    private void FixedUpdate()
    {
        if (_movement.magnitude > 0f)
        {
            transform.Translate(_movement.normalized * moveSpeed, Space.World);
            holder.rotation = Quaternion.LookRotation(_movement, Vector3.up);
            
            characterAnimations.SetMovementAnimation(_movement.x, _movement.z);

            var localScale = render.localScale;
            localScale.x = Mathf.Sign(_movement.x);
            render.localScale = localScale;
        }
        
        characterAnimations.SetIdleMovement(_movement.normalized.magnitude);
    }
}
