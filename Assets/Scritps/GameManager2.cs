using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{

    public Text timeText;
  
    public GameObject level;
    public GameObject bulletSpawnerPrefab;
    public GameObject itemPrefab;

    int prevTime;
    private float surviveTime;
    private bool isGameover;


    // Start is called before the first frame update
    void Start()
    {
        isGameover = false;
        surviveTime = 0f;
        prevTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameover == false)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time: " + (int)surviveTime;

            int currTime = (int)(surviveTime % 5f);
            if (currTime == 0 && prevTime != currTime)
            {
                Vector3 randPosBullet = new Vector3(Random.Range(-20f, 20f), 0, Random.Range(-8f, 8f));
                GameObject bulletSpawner = Instantiate(bulletSpawnerPrefab, randPosBullet, Quaternion.identity);
                bulletSpawner.transform.parent = level.transform;
                bulletSpawner.transform.localPosition = randPosBullet;

                Vector3 randPos = new Vector3(Random.Range(-20f, 20f), 0, Random.Range(-8f, 8f));
                GameObject item = Instantiate(itemPrefab, randPos, Quaternion.identity);
                item.transform.parent = level.transform;
                item.transform.localPosition = randPos;
            }
            prevTime = currTime;


        }
        
    }

   
}
