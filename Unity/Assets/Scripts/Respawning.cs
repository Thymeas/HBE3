using System.Linq;
using UnityEngine;

public class Respawning : MonoBehaviour
{
    [SerializeField] private Waypoints[] waypoints;
    
    void Start()
    {
        waypoints = FindObjectsOfType<Waypoints>();
    }

    void OnCollisionEnter(Collision other)
    {
        var pos = waypoints.Select(x => x.transform)
            .OrderBy(x => Vector3.Distance(other.transform.position, x.position)).First();

        other.transform.position = pos.position;
    }
}