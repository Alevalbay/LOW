using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonController : MonoBehaviour
{
    public Button generateNpc;
    public Button generateJob;
    void Start()
    {
        generateJob.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
