using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcHome : MonoBehaviour
{
    private GameObject[] avaibleHouses;
    public GameObject[] houses;
    public GameObject home;
    public int y = 0;
    void Start()
    {
        houses = GameObject.FindGameObjectsWithTag("House");
        DeclareHome();
        home.GetComponent<Occupcy>().PeoplesInHouse.Add(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeclareHome()
    {
        
        home=CheckHouseAvaible(houses);
       
        
    }

    public GameObject CheckHouseAvaible(GameObject[] houses)
    {
        Debug.Log("Evler Aranıyor");
        int r = Random.Range(0, houses.Length);
        if (houses[r].GetComponent<Occupcy>().PeoplesInHouse.Count == 4)
        {
            Debug.Log("Ev Dolu Yeni Ev Aranıyor");
            return CheckHouseAvaible(houses);
        }

        else
        {
            Debug.Log("Ev Bulundu Atama Yapılıyor");
            return houses[r];
        }

    }
    
}
