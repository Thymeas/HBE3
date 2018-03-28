using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;


[Serializable]
public struct X
{
    public float Fraction;
    public PlayerMovement PlayerMovement;
}

public class PositionTracker : MonoBehaviour
{
    [SerializeField] private Waypoints[] _waypoints;
    [SerializeField] private PlayerMovement[] _players;
    [SerializeField] private int _counter;
    public int _lap;
    private float[] _fraction = new float[4];
    [SerializeField] private List<X> _xs = new List<X>(4);

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
        for (var t = 0; t < _players.Length; t++)
        {
            var player = _players[t];
            var fraction = GetFractionOfPathCovered(_players[t].transform.position,
                _waypoints[_counter].transform.position,
                _waypoints[_counter + 1].transform.position);

            _xs[t] = new X
            {
                Fraction = fraction,
                PlayerMovement = player
            };
        }

        _xs = _xs.OrderBy(x => x.Fraction).ToList();
    }

    private float GetFractionOfPathCovered(Vector3 playerPos, Vector3 lastWaypointReached, Vector3 nextWaypoint)
    {
        var displacementFromCurrentWaypoint = playerPos - lastWaypointReached;
        var currentSegmentVector = nextWaypoint - lastWaypointReached;

        return Vector3.Dot(displacementFromCurrentWaypoint, currentSegmentVector) /
               currentSegmentVector.sqrMagnitude;
        ;
    }
}