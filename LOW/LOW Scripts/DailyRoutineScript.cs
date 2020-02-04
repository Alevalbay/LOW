using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyRoutineScript : MonoBehaviour
{
    public List<string> dailyRoutine = new List<string>(23);
    
    void Start()
    {
        for (int i = 0; i <= 23; i++)
            dailyRoutine.Add("Bos");
            GenerateDailyRoutine();
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void GenerateDailyRoutine()
    {
        //Decision of wichone will start 3 routine(Job,Free Time,Home) for adults
        //S means start of routine
        //T Means time of Routines
        int r;
        string secondRoutine;
        string thirdRoutine;

        int startOfJob = Random.Range(0, 23);
        //Routine time minimum 4 max 10 hour
        int timeOfJob = Random.Range(4, 10);

        int endOfJob = startOfJob + timeOfJob;

        if (endOfJob >= 24)
        {
            endOfJob = endOfJob - 24;
            for (int ss = startOfJob; ss <= 23; ss++)
            {
                
                dailyRoutine[ss] = "Job";
            }

            for (int i = 0; i <= endOfJob; i++)
            {
              
                dailyRoutine[i] = "Job";
            }
        }

        else
        {
            for (int ss = startOfJob; ss <= endOfJob; ss++)
            {
                Debug.Log(ss);
                Debug.Log("Dizi değeri"+dailyRoutine[ss]);
                dailyRoutine[ss] = "Job";
            }
        }

        r = Random.Range(1, 2);

        if (r == 1)
        {
            secondRoutine = "FreeTime";
            thirdRoutine = "Home";
        }

        else
        {
            secondRoutine = "Home";
            thirdRoutine = "FreeTime";
        }


        //Same Calculation for Second Routine
        int secondRoutineStarts = endOfJob + 1;
        int timeOfSecondRoutine = Random.Range(4, 10);
        int endOfSecondRoutine = secondRoutineStarts + timeOfSecondRoutine;

        if (endOfSecondRoutine >= 24)
        {
            endOfSecondRoutine = endOfSecondRoutine - 24;
            for (int ss = secondRoutineStarts; ss <= 23; ss++)
            {
                dailyRoutine[ss] = secondRoutine;
            }

            for (int i = 0; i <= endOfSecondRoutine; i++)
            {
                dailyRoutine[i] = secondRoutine;
            }
        }

        else
        {
            for (int ss = secondRoutineStarts; ss <= endOfSecondRoutine; ss++)
            {
                dailyRoutine[ss] =secondRoutine;
            }
        }

        //Calculation for thrid Routine
        int timeOfThirdRoutine = 24 - (timeOfSecondRoutine + timeOfJob);
        int startOfThirdRoutine = endOfSecondRoutine + 1;
        int endOfThirdRoutine = timeOfThirdRoutine + startOfThirdRoutine;

        if (endOfThirdRoutine >= 24)
        {
            endOfThirdRoutine = endOfThirdRoutine - 24;
            for (int ss = startOfThirdRoutine; ss <= 23; ss++)
            {
                dailyRoutine[ss] = thirdRoutine;
            }

            for (int i = 0; i <= endOfThirdRoutine; i++)
            {
                dailyRoutine[i] = thirdRoutine;
            }
        }

        else
        {
            for (int ss = startOfThirdRoutine; ss <= endOfThirdRoutine; ss++)
            {
                dailyRoutine[ss] = thirdRoutine;
            }
        }


    }
}
   

 



    









    

