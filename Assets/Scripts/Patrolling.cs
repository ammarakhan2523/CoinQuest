using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrolling : MonoBehaviour
{
    public List<Transform> wayPoints;

    NavMeshAgent Enemy;
    private Animator enemyAnim;
    public int currentWaypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        Enemy = GetComponent<NavMeshAgent>();
        enemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

     void Patrol()
    {

        enemyAnim.SetBool("Walking", true);

        if (wayPoints.Count == 0)
        {

            return;
        }


        float distanceToWaypoint = Vector3.Distance(wayPoints[currentWaypointIndex].position, transform.position);

        // Check if the agent is close enough to the current waypoint
        if (distanceToWaypoint <= 2)
        {

            currentWaypointIndex = (currentWaypointIndex + 1) % wayPoints.Count;
        }

        // Set the destination to the current waypoint
        Enemy.SetDestination(wayPoints[currentWaypointIndex].position);
    }


}
