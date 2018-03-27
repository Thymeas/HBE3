using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal.Input;

public class PlayerMovement : MonoBehaviour
{
    private float _startSpeed = 20.0f, _maxSpeed = 75.0f;
    [SerializeField] private float _moveSpeed;
    public PlayerMovement[] players;
    [SerializeField] private bool _canJump;

    private void Start()
    {
        _moveSpeed = _startSpeed;
        players = FindObjectsOfType<PlayerMovement>();
    }

    void Update()
    {
        MoveForward(Input.GetAxis("Vertical"));
        Rotate(Input.GetAxis("Horizontal"));
        Jump(Input.GetKeyDown(KeyCode.Space));
    }

    void MoveForward(float input)
    {
        var movement = Vector3.forward * input;
        transform.Translate(movement * Time.deltaTime * _moveSpeed);

        if (input > 0.05f && _moveSpeed < _maxSpeed)
            _moveSpeed += 0.05f;
        else if (input < 0.05f && _moveSpeed > _startSpeed)
            _moveSpeed -= 0.05f;
    }

    void Rotate(float input)
    {
        if (input > 0.05f)
            transform.Rotate(Vector3.up * _moveSpeed * Time.deltaTime);

        if (input < -0.05f)
            transform.Rotate(-Vector3.up * _moveSpeed * Time.deltaTime);
    }

    void Jump(bool isPressingJump)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_canJump)
                transform.GetComponent<Rigidbody>().AddForce(0, 200, 0);
            _canJump = false || Physics.Raycast(transform.position, Vector3.down, 0.25f);
        }
    }
}