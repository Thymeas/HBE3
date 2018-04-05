using System;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _startSpeed = 10.0f, _maxSpeed = 50.0f;
    [SerializeField] private float _moveSpeed;
    private float _rotationspeed = 2.5f;

   // private Rigidbody _mRigidbody;

    public Waypoints[] _waypoint;
    public int counter;
    public int _lap;
    private float distance = 20.0f;


    public string _horizontalAxis;
    public string _verticalAxis;
    public string _jumpButton;
    public string _breakButton;
    private float _inputHorizontal;
	private float _inputVertical;

    private void Start()
    {
        _moveSpeed = _startSpeed;
        //_mRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (UIManager._canCount)
        {
            _inputHorizontal = SimpleInput.GetAxis(_horizontalAxis);
            _inputVertical = SimpleInput.GetAxis(_verticalAxis);

            if (SimpleInput.GetButton(_breakButton))
                Slip();
            else
                _rotationspeed = 2.5f;

            MoveForward();
            CalculateNextWaypoint();
            Rotate();
            // Jump();
        }

        if (_lap >= 3)
        {
            UIManager._canCount = false;
            InputMenu.LoadWinScreen();
            WinBoard._winner = this.name;
        }
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
        transform.Rotate(0f, _inputHorizontal * _rotationspeed, 0f, Space.World);
    }

    //void Jump()
    //{
    //    if (SimpleInput.GetButtonDown(_jumpButton) && IsGrounded())
    //        _mRigidbody.AddForce(0f, 5.0f, 0f, ForceMode.Impulse);
    //}

    //bool IsGrounded()
    //{
    //    return Physics.Raycast(transform.position, Vector3.down, 1.75f);
    //}

    void Slip()
    {
        if (_moveSpeed > _startSpeed)
            _moveSpeed -= 1.0f;

        _rotationspeed = 5.0f;
    }
}