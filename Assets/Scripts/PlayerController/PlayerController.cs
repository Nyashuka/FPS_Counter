using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _walkingSpeed;
    [SerializeField] private float _runningSpeed;
    [SerializeField] private float _jumpForce = 100f;

    private bool _isGrounded;
    private Vector3 _velocity;
    private float _gravityForce = -9.81f * 3f;
    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        IsGroundedChek();
        WalkAndRun();
        JumpWithGravity();
    }

    private void WalkAndRun()
    {
        Vector3 move = transform.right * Input.GetAxis("Horizontal") +
                         transform.forward * Input.GetAxis("Vertical");

        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? _runningSpeed : _walkingSpeed;

        _characterController.Move(move * Time.deltaTime * currentSpeed);
    }

    private void IsGroundedChek()
    {
        _isGrounded = _characterController.isGrounded;
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = 0f;
        }     
    }

    private void JumpWithGravity()
    {
        if (Input.GetKey(KeyCode.Space) && _isGrounded)
        {
            _velocity.y += Mathf.Sqrt(_jumpForce * -2f * _gravityForce);
        }

        _velocity.y += _gravityForce * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);
    }
}
