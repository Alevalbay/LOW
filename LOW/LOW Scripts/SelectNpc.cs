using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectNpc : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject characterSheet;
    public GameObject npCharacter;
    public TMP_Text strength;
    public TMP_Text agility;
    public TMP_Text inteligence;
    public TMP_Text name;
    public TMP_Text height;
    public TMP_Text weight;
    public TMP_Text trait1;
    public TMP_Text trait2;
    public TMP_Text trait3;
    public TMP_Text trait4;
    public TMP_Text trait5;
    public string kidOrAdult;

    //For Stop Game
    public FirstPersonAIO fpt;
    private bool isActive;
   
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("r"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }


        // this code show nameobject with click   
        if (Input.GetKeyDown("e"))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    
            if(Physics.Raycast(ray, out hit,100.0f))
            {
                if(hit.transform !=null)
                {


                    npCharacter=hit.transform.gameObject;
                    Debug.Log("character has been selected");
                    isActive = true;

                    if(npCharacter.GetComponent<NpCharacter>().bodyType==false)
                    {
                        kidOrAdult = "(K)";
                    }
                    else
                    {
                        kidOrAdult = "(A)";
                    }

                    name.text        =  ("Name="         +npCharacter.GetComponent<NpCharacter>().npcName.text+"  "+kidOrAdult);
                    strength.text    =  ("Strength="     +npCharacter.GetComponent<NpCharacter>().strenght.ToString());
                    agility.text     =  ("Agility="      +npCharacter.GetComponent<NpCharacter>().agility.ToString());
                    inteligence.text =  ("Inteligence="  +npCharacter.GetComponent<NpCharacter>().intelligence.ToString());
                    height.text      =  ("Height=" + npCharacter.GetComponent<NpCharacter>().npcHeight.ToString());
                    weight.text      =  ("Weight=" + npCharacter.GetComponent<NpCharacter>().npcWeight.ToString());
                    //Assaigment traits to game objects
                    trait1.text = npCharacter.GetComponent<NpCharacter>().npcTraists[0];
                    trait2.text = npCharacter.GetComponent<NpCharacter>().npcTraists[1];
                    trait3.text = npCharacter.GetComponent<NpCharacter>().npcTraists[2];
                    trait4.text = npCharacter.GetComponent<NpCharacter>().npcTraists[3];
                    trait5.text = npCharacter.GetComponent<NpCharacter>().npcTraists[4];
                    characterSheet.SetActive(isActive);
                    fpt.enableCameraMovement = (!isActive);
                    fpt.playerCanMove = (!isActive);

                }
            }
        }
        if (Input.GetKeyDown("escape") && isActive==true)
        {
            characterSheet.SetActive(!isActive);
            fpt.enableCameraMovement = (isActive);
            fpt.playerCanMove = (isActive);
            isActive = false;
        }
    }

   
}

