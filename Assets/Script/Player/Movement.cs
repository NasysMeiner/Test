using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask GroundLayer = 1;

    private Rigidbody _rigidbody;
    private CapsuleCollider _collider;

    public Rigidbody Rigidbody => _rigidbody;

    private bool _isGrounded
    {
        get
        {
            var bottomCenterPoint = new Vector3(_collider.bounds.center.x, _collider.bounds.min.y, _collider.bounds.center.z);

            return Physics.CheckCapsule(_collider.bounds.center, bottomCenterPoint, _collider.bounds.size.x / 2 * 0.1f, GroundLayer);
        }
    }

    private Vector3 _movementVector
    {
        get
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 move = horizontal * transform.right + vertical * transform.forward;

            return move;
        }
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        if (Math.Abs(_rigidbody.velocity.x) >= _maxSpeed || Math.Abs(_rigidbody.velocity.z) >= _maxSpeed)
            _rigidbody.velocity = new Vector3(_maxSpeed * _rigidbody.velocity.normalized.x, _rigidbody.velocity.y, _maxSpeed * _rigidbody.velocity.normalized.z);

        _rigidbody.AddForce(_movementVector * _speed, ForceMode.Impulse);
    }

    private void Jump()
    {
        if (_isGrounded && (Input.GetAxis("Jump") > 0))
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
}
