using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private Vector3 _moveVector;
    public float jumpForce;
    public float gravity = 9.8f;
    public float speed;
    private float _fallVelocity = 0;

    private CharacterController _characterContoller;

    void Start()
    {
        _characterContoller = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        //Movement
        _moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && _characterContoller.isGrounded)
        {
            _fallVelocity = -jumpForce;
        }
        if(_characterContoller.isGrounded)
        {
                _fallVelocity = 0;
        }
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        _characterContoller.Move(_moveVector * speed * Time.fixedDeltaTime);
        _fallVelocity += gravity * Time.deltaTime;
        _characterContoller.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
    }
}
