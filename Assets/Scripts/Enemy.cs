using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Transform target;
    private int waypointIndex = 0;

    private void Start()
    {
        target = Waypoint.waypoints[0];
    }
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }
    private void GetNextWaypoint()
    { 
        if(waypointIndex >= Waypoint.waypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        waypointIndex++;
        target = Waypoint.waypoints[waypointIndex];
    }
}
