using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveDestination : MonoBehaviour
{
    public GameObject npc;
    public GameObject time;
    public GameObject tavernArea;
    public GameObject mineArea;
    public GameObject fishArea;
    public GameObject millArea;
    public GameObject tailorArea;
    public GameObject blackSmithArea;
    public GameObject lumberJackArea;
    public GameObject sheperdArea;
    public GameObject farmArea;
    public GameObject playGround;
    
    public Transform goal;



    private const int TIMESCALE = 255;

    public int hour;
    private double minute, day, second, month, year;
    void Start()
    {
        hour = 12;
        month = 4;
        day = 1;
        year = 1445;

       
    }

    // Update is called once per frame
    void Update()
    {
        CalculateTime();
        if (gameObject.GetComponent<DailyRoutineScript>().dailyRoutine[hour] == "Job")
        {
            if (gameObject.GetComponent<NpCharacter>().Job == "Inkeeper")
            {
                goal = tavernArea.transform;
                NavMeshAgent agent = GetComponent<NavMeshAgent>();
                agent.destination = goal.position;
            }

            else if (gameObject.GetComponent<NpCharacter>().Job == "Miner")
            {
                goal = mineArea.transform;
                NavMeshAgent agent = GetComponent<NavMeshAgent>();
                agent.destination = goal.position;
            }

            else if (gameObject.GetComponent<NpCharacter>().Job == "Fisher")
            {
                goal = fishArea.transform;
                NavMeshAgent agent = GetComponent<NavMeshAgent>();
                agent.destination = goal.position;
            }

            else if (gameObject.GetComponent<NpCharacter>().Job == "Miller")
            {
                goal = millArea.transform;
                NavMeshAgent agent = GetComponent<NavMeshAgent>();
                agent.destination = goal.position;
            }

            else if (gameObject.GetComponent<NpCharacter>().Job == "Tailor")
            {
                goal = tailorArea.transform;
                NavMeshAgent agent = GetComponent<NavMeshAgent>();
                agent.destination = goal.position;
            }

            else if (gameObject.GetComponent<NpCharacter>().Job == "BlackSmith")
            {
                goal = blackSmithArea.transform;
                NavMeshAgent agent = GetComponent<NavMeshAgent>();
                agent.destination = goal.position;
            }

            else if (gameObject.GetComponent<NpCharacter>().Job == "LumberJack")
            {
                goal = lumberJackArea.transform;
                NavMeshAgent agent = GetComponent<NavMeshAgent>();
                agent.destination = goal.position;
            }

            else if (gameObject.GetComponent<NpCharacter>().Job == "Sheperd")
            {
                goal = sheperdArea.transform;
                NavMeshAgent agent = GetComponent<NavMeshAgent>();
                agent.destination = goal.position;
            }

            else if (gameObject.GetComponent<NpCharacter>().Job == "Farmer")
            {
                goal = farmArea.transform;
                NavMeshAgent agent = GetComponent<NavMeshAgent>();
                agent.destination = goal.position;
            }

            else if (gameObject.GetComponent<NpCharacter>().Job == "Child")
            {
                goal = playGround.transform;
                NavMeshAgent agent = GetComponent<NavMeshAgent>();
                agent.destination = goal.position;
            }
        }
        else if(gameObject.GetComponent<DailyRoutineScript>().dailyRoutine[hour] == "Home")
        {


            goal = gameObject.GetComponent<npcHome>().home.transform;
                NavMeshAgent agent = GetComponent<NavMeshAgent>();
                agent.destination = goal.position;
        }

        else if (gameObject.GetComponent<DailyRoutineScript>().dailyRoutine[hour] == "FreeTime")
        {
            goal = tavernArea.transform;
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.destination = goal.position;
        }



    }



    
    
    public void CalculateTime()
    {
        second += Time.deltaTime * TIMESCALE;

        if (second >= 60)
        {
            minute++;
            second = 0;

        }
        else if (minute >= 60)
        {
            hour++;
            minute = 0;

        }
        else if (hour >= 24)
        {
            day++;
            hour = 0;

        }
    }
   
    


}
