using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class AI_Script : MonoBehaviour
{
    NavMeshAgent nm;
    Rigidbody rb;
    Animator anim;
    public Transform Target;
    public Transform[] WayPoints;
    public int cur_Waypoint;
    public float speed, stop_distance;
    public float pauseTimer;
    [SerializeField]
    private float cur_Timer;



    void Start()
    {
        nm = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        rb.freezeRotation = true;

        Target = WayPoints[cur_Waypoint];
        cur_Timer = pauseTimer;
    }

    // Update is called once per frame
    void Update()
    {
        //Settings Updated
        nm.acceleration = speed;
        nm.stoppingDistance = stop_distance;

        float distance = Vector3.Distance(transform.position, Target.position);
        //Move the WayPoint
        if (distance > stop_distance && WayPoints.Length > 0)
        {
            //Set Bool for moving =True
            //Set Bool for Idle=false
            //Find WayPoint
            Target = WayPoints[cur_Waypoint];
        }
        else if (distance <= stop_distance && WayPoints.Length > 0)
        {
            if (cur_Timer > 0)
            {
                cur_Timer -= 0.01f;
                //Set bool for Moving =False
                //Set Bool for Idle =True
            }

            if (cur_Timer <= 0)
            {
                cur_Waypoint++;

                if (cur_Waypoint >= WayPoints.Length)
                {
                    cur_Waypoint = 0;
                }
                Target = WayPoints[cur_Waypoint];
                cur_Timer = pauseTimer;
            }
        }
        nm.SetDestination(Target.position);
    }
}
