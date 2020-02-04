using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobGenerator : MonoBehaviour
{
    public GameObject CreateNpcObject;
    public  GameObject[] adultHumans;
    public GameObject[] kidHumans;
    private string[] Jobs = { "Farmer", "Miner", "Fisher", "TavernKeeper", "Miller", "Tailor", "BlackSmith", "LumberJack", "Sheperd", "child" };
    public int MinerNumber;
    public int FisherNumbers;
    public int MillerNumbers;
    public int TailorNumbers;
    public int BlacksmithNumbers;
    public int LumberjackNumbers;
    public int SheperdNumbers;
    public int inkeeperNumbers;
    public int farmerNumbers;
    void Start()
    {
        Invoke("GenerateJobs", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateJobs()
    {
        FindAdultHumans();
        DecisionOfPersonPerJob();
        GiveHumansJob();
        GiveJobsKids();
    }
    public void FindAdultHumans()
    {
        adultHumans = GameObject.FindGameObjectsWithTag("AdultNpc");
        kidHumans   = GameObject.FindGameObjectsWithTag("ChildNpc");
    }

    public void DecisionOfPersonPerJob()
    {
        MinerNumber = RandomNumberForJob();
        FisherNumbers = RandomNumberForJob();
        MillerNumbers = RandomNumberForJob();
        TailorNumbers = RandomNumberForJob();
        BlacksmithNumbers = RandomNumberForJob();
        LumberjackNumbers = RandomNumberForJob();
        SheperdNumbers = RandomNumberForJob();
        inkeeperNumbers = 1;
        farmerNumbers = CreateNpcObject.GetComponent<CreateNpcScript>().adult - (MinerNumber + FisherNumbers + MillerNumbers + TailorNumbers + BlacksmithNumbers + LumberjackNumbers + SheperdNumbers + inkeeperNumbers);


    }
    public void GiveHumansJob()
    {
        int humanNumber = 0;
            for(int y=-1;y<MinerNumber-1;y++)
             {
            adultHumans[humanNumber].GetComponent<NpCharacter>().Job = "Miner";
            humanNumber++;
             }
            for (int y = 0; y <FisherNumbers; y++)
            {
            adultHumans[humanNumber].GetComponent<NpCharacter>().Job = "Fisher";
            humanNumber++;
            }
            for (int y = 0; y < MillerNumbers; y++)
            {
            adultHumans[humanNumber].GetComponent<NpCharacter>().Job = "Miller";
            humanNumber++;
            }
            for (int y = 0; y < TailorNumbers; y++)
            {
            adultHumans[humanNumber].GetComponent<NpCharacter>().Job = "Tailor";
            humanNumber++;
            }
            for (int y = 0; y < BlacksmithNumbers; y++)
            {
            adultHumans[humanNumber].GetComponent<NpCharacter>().Job = "BlackSmith";
            humanNumber++;
            }
             for (int y = 0; y < LumberjackNumbers; y++)
             {
            adultHumans[humanNumber].GetComponent<NpCharacter>().Job = "LumberJack";
            humanNumber++;
            }
            for (int y = 0; y < SheperdNumbers; y++)
            {
            adultHumans[humanNumber].GetComponent<NpCharacter>().Job = "Sheperd";
            humanNumber++;
            }
            adultHumans[humanNumber].GetComponent<NpCharacter>().Job = "Inkeeper";
            humanNumber++;
            for (int y = 0; y < farmerNumbers-1; y++)
            {
            adultHumans[humanNumber].GetComponent<NpCharacter>().Job = "Farmer";
            humanNumber++;
            }




    }

    public void GiveJobsKids()
    {
        for(int i=0;i<kidHumans.Length;i++)
        {
           kidHumans[i].GetComponent<NpCharacter>().Job = "Child";
        }
    }


    public int RandomNumberForJob()
    {
        int r = Random.Range(1, 4);

        return r;
    }


}
