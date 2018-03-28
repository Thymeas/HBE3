using UnityEngine;

public class PositionTracker : MonoBehaviour
{
    [SerializeField] private Waypoints[] _waypoints;
    [SerializeField] private PlayerMovement[] _players;
    [SerializeField] private int _counter;
    private float _fraction;

    void Start()
    {
        _players = FindObjectsOfType<PlayerMovement>();
        _waypoints = FindObjectsOfType<Waypoints>();
    }

    void Update()
    {
        UpdateCounter();
        CalculatePlayerFraction();
    }

    private void UpdateCounter()
    {
        _counter = FindObjectOfType<PlayerMovement>().counter;
    }

    private void CalculatePlayerFraction()
    {
        foreach (PlayerMovement t in _players)
        {
            GetFractionOfPathCovered(t.transform.position, _waypoints[_counter].transform.position,
                _waypoints[_counter + 1].transform.position);
        }
    }

    private float GetFractionOfPathCovered(Vector3 playerPos, Vector3 lastWaypointReached, Vector3 nextWaypoint)
    {
        Vector3 displacementFromCurrentWaypoint = playerPos - lastWaypointReached;
        Vector3 currentSegmentVector = nextWaypoint - lastWaypointReached;
        _fraction = Vector3.Dot(displacementFromCurrentWaypoint, currentSegmentVector) /
                         currentSegmentVector.sqrMagnitude;
        return _fraction;
    }
}
