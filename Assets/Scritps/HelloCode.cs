using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //string name = "라라";
        //char bloodType = 'A';
        //int age = 17;
        //float height = 168.3f;
        //bool isFemale = true;


        //Debug.Log("Hello World");

        int love = 70;

        if(love > 70)
        {
            Debug.Log("히로인과 사귀게 되었다!");
        }

        if(love <= 70)
        {
            Debug.Log("히로인과 사귀게 차였다!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
