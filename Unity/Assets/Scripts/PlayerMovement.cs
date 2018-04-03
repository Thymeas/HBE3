using System;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _startSpeed = 20.0f, _maxSpeed = 75.0f;
    [SerializeField] private float _moveSpeed;

    private Rigidbody _mRigidbody;

    public Waypoints[] _waypoint;
    public int counter;
    public int _lap;
    private float distance = 2.0f;


    public string _horizontalAxis;
    public string _verticalAxis;
    public string _jumpButton;
    public string _breakButton;
    private float _inputHorizontal;
	private float _inputVertical;

    private void Start()
    {
        _moveSpeed = _startSpeed;
        _mRigidbody = GetComponent<Rigidbody>();
        _waypoint = FindObjectsOfType<Waypoints>();
        //_waypoint.Reverse();
    }

    void Update()
    {
        _inputHorizontal = SimpleInput.GetAxis(_horizontalAxis);
        _inputVertical = SimpleInput.GetAxis(_verticalAxis);

        if (SimpleInput.GetButton(_breakButton))
            Slip();

        MoveForward();
        CalculateNextWaypoint();
        Rotate();
        Jump();
    }

    void MoveForward()
    {
        var movement = Vector3.forward * _inputVertical;
        transform.Translate(movement * Time.deltaTime * _moveSpeed);

        if (_inputVertical > 0.05f && _moveSpeed < _maxSpeed)
            _moveSpeed += 0.5f;
        else if (_inputVertical < 0.05f && _moveSpeed > _startSpeed)
            _moveSpeed -= 0.5f;
    }
    private void CalculateNextWaypoint()
    {
        var direction = _waypoint[counter].transform.position - transform.position;
        if (direction.magnitude < distance)
        {
            if (counter < _waypoint.Length - 1)
                counter++;
            else
            {
                counter = 0;
                _lap += 1;
            }
        }
    }

    void Rotate()
    {
        transform.Rotate(0f, _inputHorizontal * 2.5f, 0f, Space.World);
    }

    void Jump()
    {
        if (SimpleInput.GetButtonDown(_jumpButton) && IsGrounded())
            _mRigidbody.AddForce(0f, 5.0f, 0f, ForceMode.Impulse);
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.75f);
    }

    void Slip()
    {
        if(_moveSpeed > _startSpeed)
        _moveSpeed -= 1.0f;
    }
}