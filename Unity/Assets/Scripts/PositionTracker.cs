using System;
using System.Linq;
using UnityEngine;

public class PositionTracker : MonoBehaviour
{
    [SerializeField] private Waypoints[] _waypoints;
    [SerializeField] private PlayerMovement[] _players;
    [SerializeField] private int _counter;
    public int _lap;
    private float[] _fraction = new float[4];

    private void Start()
    {
        _players = FindObjectsOfType<PlayerMovement>();
        _waypoints = FindObjectsOfType<Waypoints>();
    }

    private void Update()
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
            for (int t = 0; t < _players.Length; t++)
            {
                GetFractionOfPathCovered(_players[t].transform.position, _waypoints[_counter].transform.position,
                    _waypoints[_counter + 1].transform.position, t);
            } 
    }

    private float GetFractionOfPathCovered(Vector3 playerPos, Vector3 lastWaypointReached, Vector3 nextWaypoint, int player)
    {
        Vector3 displacementFromCurrentWaypoint = playerPos - lastWaypointReached;
        Vector3 currentSegmentVector = nextWaypoint - lastWaypointReached;
        _fraction[player] = Vector3.Dot(displacementFromCurrentWaypoint, currentSegmentVector) /
                         currentSegmentVector.sqrMagnitude;
        print(Mathf.Min(_fraction) + player);
        return _fraction[player];
    }

}
