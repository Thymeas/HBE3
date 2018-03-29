using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
<<<<<<< HEAD

    private Rigidbody _mRigidbody;

    public string _horizontalAxis;
    public string _verticalAxis;
    public string _jumpButton;
    public string _breakButton;
    private float _inputHorizontal;
	private float _inputVertical;
=======
    private float _startSpeed = 20.0f, _maxSpeed = 75.0f;
    public PlayerMovement[] players;
>>>>>>> Waypoints

    public Waypoints[] _waypoint;
    public int counter;
    [SerializeField] private float distance = 2.0f;
    private PositionTracker _posTracker;

    private void Start()
    {
        _moveSpeed = _startSpeed;
<<<<<<< HEAD
        _mRigidbody = GetComponent<Rigidbody>();
=======
        players = FindObjectsOfType<PlayerMovement>();
        _waypoint = FindObjectsOfType<Waypoints>();
        _posTracker = FindObjectOfType<PositionTracker>();
>>>>>>> Waypoints
    }

    private void Update()
    {
<<<<<<< HEAD
        _inputHorizontal = SimpleInput.GetAxis(_horizontalAxis);
        _inputVertical = SimpleInput.GetAxis(_verticalAxis);

        if (SimpleInput.GetButton(_breakButton))
            Slip();

        MoveForward();
        Rotate();
        Jump();
    }

    void MoveForward()
=======
        CalculateNextWaypoint();
        MoveForward(Input.GetAxis("Vertical"));
        Rotate(Input.GetAxis("Horizontal"));
        Jump(Input.GetKeyDown(KeyCode.Space));     
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
                _posTracker._lap += 1;
            }
        }
    }

    private void MoveForward(float input)
>>>>>>> Waypoints
    {
        var movement = Vector3.forward * _inputVertical;
        transform.Translate(movement * Time.deltaTime * _moveSpeed);

        if (_inputVertical > 0.05f && _moveSpeed < _maxSpeed)
            _moveSpeed += 0.5f;
        else if (_inputVertical < 0.05f && _moveSpeed > _startSpeed)
            _moveSpeed -= 0.5f;
    }

<<<<<<< HEAD
    void Rotate()
=======
    private void Rotate(float input)
>>>>>>> Waypoints
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

<<<<<<< HEAD
    void Slip()
=======
    private void Jump(bool isPressingJump)
>>>>>>> Waypoints
    {
        if(_moveSpeed > _startSpeed)
        _moveSpeed -= 1.0f;
    }

    
}