using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class CreateNpcScript : MonoBehaviour
{
    public GameObject adultNpc;
    public GameObject childNpc;

    public TMP_Text textPopulation;
    public TMP_Text textAdultPopulation;
    public TMP_Text textChildPopulation;

    public int population;
    public int childs;

    public int adult;

    public int x = 0;



   
       

    private void Start()
    {
        CreateNpcVanilla();
    }

    public void CreateNpcVanilla()
    {


        //Decide Population
        population = Random.Range(40, 60);
        //Decide Childs
        childs = Random.Range(5, 15);

        adult = (population - childs);

        for (int i = 0; i < population; i++, x +=3)
        {


            if (i <= childs)
                Instantiate(childNpc, new Vector3(0, 5f, -x), Quaternion.identity);

            else
                Instantiate(adultNpc, new Vector3(0, 5f, +x), Quaternion.identity);
        }



        //Declarion for UI tmp_Text
        textPopulation.text       =("Population:"+population.ToString());
        textAdultPopulation.text  =("Adult Population:"+adult);
        textChildPopulation.text  =("Child Population:")+childs.ToString();

       


    }

   

   
}

