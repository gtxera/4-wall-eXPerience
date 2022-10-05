using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speed = 5.0f;
    [SerializeField] Rigidbody2D _rigidbody;
    private Vector2 _movement;
    private bool _canMove;
    void Start()
    {
        _canMove = true;
        EventManager.Instance.OpenGame += EnablePlayerMovement;
        EventManager.Instance.CloseGame += DisablePlayerMovement;
    }

    private void OnDisable()
    {
        EventManager.Instance.OpenGame -= EnablePlayerMovement;
        EventManager.Instance.CloseGame -= DisablePlayerMovement;
    }

    private void Update()
    {
        _movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));   
    }
    private void FixedUpdate()
    {
        if (_canMove)
        {
            _rigidbody.MovePosition((Vector2)transform.position + (_movement * _speed * Time.deltaTime));
        }
    }

    private void DisablePlayerMovement()
    {
        _canMove = false;
    }

    private void EnablePlayerMovement()
    {
        _canMove = true;
    }
}