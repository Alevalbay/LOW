using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasScript : MonoBehaviour
{



    public GameObject UI;
    public GameObject characterSheet;
    public FirstPersonAIO fpt;
    private bool isActive;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape") && characterSheet.activeSelf==false)
        {
            isActive = !isActive;
            UI.SetActive(isActive);
            fpt.enableCameraMovement = (!isActive);
            fpt.playerCanMove = (!isActive);


        }
    }
}
