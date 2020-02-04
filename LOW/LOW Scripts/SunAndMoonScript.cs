using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunAndMoonScript : MonoBehaviour
{

    public int rotaionSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.right, 10f * Time.deltaTime * rotaionSpeed*0.1f);
        transform.LookAt(Vector3.zero);

    }
}
