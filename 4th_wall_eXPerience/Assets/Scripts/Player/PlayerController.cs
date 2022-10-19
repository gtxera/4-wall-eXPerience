using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speed = 5.0f;
    [SerializeField] Transform _transform;
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] Animator _animator;
    private Vector2 _movement;
    private Vector2 _lookDirection = Vector2.up;
    private bool _canMove;
    void Start()
    {
        _canMove = true;
        EventManager.Instance.OpenGame += EnablePlayerMovement;
        EventManager.Instance.CloseGame += DisablePlayerMovement;
        EventManager.Instance.Escape4thWall += Escape4thWall;
    }

    private void OnDisable()
    {
        EventManager.Instance.OpenGame -= EnablePlayerMovement;
        EventManager.Instance.CloseGame -= DisablePlayerMovement;
        EventManager.Instance.Escape4thWall -= Escape4thWall;
    }

    private void Update()
    {
        if (_canMove)
        {
            _movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (_movement != Vector2.zero)
            {
                _lookDirection = _movement;
                _animator.Play("Movement");
            }
            else
            {
                _animator.Play("Idle");
            }
            var _yRotation = 0f;
            if (_lookDirection.x < 0f)
            {
                _yRotation = 180f;
            }
            _transform.rotation = Quaternion.Euler(0, _yRotation, 0);
            _animator.SetFloat("MoveX", _lookDirection.x);
            _animator.SetFloat("MoveY", _lookDirection.y);
        }
    }
    private void FixedUpdate()
    {
        if (_canMove)
        {
            _rigidbody.MovePosition((Vector2)transform.position + (_movement.normalized * _speed * Time.deltaTime));
        }
    }

    public void DisablePlayerMovement()
    {
        _canMove = false;
    }

    public void EnablePlayerMovement()
    {
        _canMove = true;
    }

    private void Escape4thWall()
    {
        EventManager.Instance.CloseGame -= DisablePlayerMovement;
    }
}