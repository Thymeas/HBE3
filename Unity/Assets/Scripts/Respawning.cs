using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class Respawning : MonoBehaviour
{
    [SerializeField] private Waypoints[] waypoints;
    [SerializeField] private Transform tMin;
    private Collision _col;

    void Start()
    {
        waypoints = FindObjectsOfType<Waypoints>();
    }

    void OnCollisionEnter(Collision other)
    {
        _col = other;
        for (int i = 0; i < waypoints.Length; i++)
        {
            Transform[] tempTranform = waypoints[i].GetComponents<Transform>();
            GetClosestWaypoint(tempTranform, other.transform.position);
        }      
    }

    void Respawn(Transform respawnPos)
    {
        if(_col!= null)
        _col.transform.position = respawnPos.position;
    }

    Transform GetClosestWaypoint(Transform[] waypointPos, Vector3 player)
    {
        tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 playerPos = player;
        foreach (Transform t in waypointPos)
        {
            float dist = Vector3.Distance(playerPos, t.position);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        Respawn(tMin);
        _col = null;
        return tMin;     
    }
}
