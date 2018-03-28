using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private float _startSpeed = 20.0f, _maxSpeed = 75.0f;
    public PlayerMovement[] players;

    public Waypoints[] _waypoint;
    public int counter;
    [SerializeField] private float distance = 2.0f;
    private PositionTracker _posTracker;

    private void Start()
    {
        _moveSpeed = _startSpeed;
        players = FindObjectsOfType<PlayerMovement>();
        _waypoint = FindObjectsOfType<Waypoints>();
        _posTracker = FindObjectOfType<PositionTracker>();
    }

    private void Update()
    {
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
    {
        var movement = Vector3.forward * input;
        transform.Translate(movement * Time.deltaTime * _moveSpeed);

        if (input > 0.05f && _moveSpeed < _maxSpeed)
            _moveSpeed += 0.05f;
        else if (input < 0.05f && _moveSpeed > _startSpeed)
            _moveSpeed -= 0.05f;
    }

    private void Rotate(float input)
    {
        if (input > 0.05f)
            transform.Rotate(Vector3.up * _moveSpeed * Time.deltaTime);

        if (input < -0.05f)
            transform.Rotate(-Vector3.up * _moveSpeed * Time.deltaTime);
    }

    private void Jump(bool isPressingJump)
    {
        if (isPressingJump && Physics.Raycast(transform.position, Vector3.down, 0.5f))
                transform.GetComponent<Rigidbody>().AddForce(0, 200, 0);
    }

    
}