using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private bool _isGrounded;
    private Vector3 _velocity;
    private float _gravityForce = -9.81f;
    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _isGrounded = _characterController.isGrounded;
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = 0f;
        }

        Vector3 move = transform.right * Input.GetAxis("Horizontal") +
                         transform.forward * Input.GetAxis("Vertical"); ;
        _characterController.Move(move * Time.deltaTime * _speed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y += Mathf.Sqrt(_jumpForce * -3.0f * _gravityForce);
        }

        _velocity.y += _gravityForce * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);
        //MoveCharacter();
        //Jump();
        //Gravity();
    }

    private void MoveCharacter()
    {
        Vector3 playerPosition = Vector3.zero;

        playerPosition = transform.right * Input.GetAxis("Horizontal") +
                         transform.forward * Input.GetAxis("Vertical");

        _characterController.Move(playerPosition * _speed * Time.deltaTime);  
    }

    private void Gravity()
    {
        _velocity.y += _gravityForce * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jumpForce * -2f * _gravityForce);
            _characterController.Move(_velocity * Time.deltaTime);
        }
        Debug.Log(_isGrounded);
    }

}
