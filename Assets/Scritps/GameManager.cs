using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    public Text timeText;
    public Text recordText;

    public GameObject level;
    public GameObject bulletSpawnerPrefab;
    public GameObject itemPrefab;
    int prevItemCheck;

    private Vector3[] bulletSpawners = new Vector3[4];
    int spawnCounter = 0;

    private float surviveTime;
    private bool isGameover;


    // Start is called before the first frame update
    void Start()
    {
        isGameover = false;
        surviveTime = 0f;

        bulletSpawners[0].x = 8f;
        bulletSpawners[0].y = 1;
        bulletSpawners[0].z = 8f;

        bulletSpawners[1].x = -8f;
        bulletSpawners[1].y = 1;
        bulletSpawners[1].z = 8f;

        bulletSpawners[2].x = 8f;
        bulletSpawners[2].y = 1;
        bulletSpawners[2].z = -8f;


        bulletSpawners[3].x = -8f;
        bulletSpawners[3].y = 1;
        bulletSpawners[3].z = -8f;

    }

    // Update is called once per frame
    void Update()
    {
        if(isGameover == false)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time: " + (int)surviveTime;

            if (surviveTime % 5f <= 0.01f && prevItemCheck ==4)
            {
                Vector3 randPos = new Vector3(Random.Range(-8f, 8f), 0, Random.Range(-8f, 8f));
                GameObject item = Instantiate(itemPrefab, randPos, Quaternion.identity);
                item.transform.parent = level.transform;
                item.transform.localPosition = randPos;
            }
            prevItemCheck = (int)(surviveTime % 5f);


            if(surviveTime < 5f && spawnCounter == 0)
            {
                GameObject bulletSpawner = Instantiate(bulletSpawnerPrefab, bulletSpawners[spawnCounter], Quaternion.identity);
                
                bulletSpawner.transform.parent = level.transform;
                bulletSpawner.transform.localPosition = bulletSpawners[spawnCounter];
                level.GetComponent<Rotator>().rotationSpeed += 15f;
                spawnCounter++;
            }
            else if (surviveTime >= 5f && surviveTime < 10f && spawnCounter == 1)
            {
                GameObject bulletSpawner = Instantiate(bulletSpawnerPrefab, bulletSpawners[spawnCounter], Quaternion.identity);
                
                bulletSpawner.transform.parent = level.transform;
                bulletSpawner.transform.localPosition = bulletSpawners[spawnCounter];
                level.GetComponent<Rotator>().rotationSpeed += 15f;
                spawnCounter++;
            }
            else if (surviveTime >= 10f && surviveTime < 15f && spawnCounter == 2)
            {
                GameObject bulletSpawner = Instantiate(bulletSpawnerPrefab, bulletSpawners[spawnCounter], Quaternion.identity);
                
                bulletSpawner.transform.parent = level.transform;
                bulletSpawner.transform.localPosition = bulletSpawners[spawnCounter];
                level.GetComponent<Rotator>().rotationSpeed += 15f;
                spawnCounter++;
            }
            else if (surviveTime >= 15f && surviveTime < 20f && spawnCounter == 3)
            {
                GameObject bulletSpawner = Instantiate(bulletSpawnerPrefab, bulletSpawners[spawnCounter], Quaternion.identity);
                
                bulletSpawner.transform.parent = level.transform;
                bulletSpawner.transform.localPosition = bulletSpawners[spawnCounter];
                level.GetComponent<Rotator>().rotationSpeed += 15f;
                spawnCounter++;
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Samplescene");
            }

        }
    }

    public void EndGame()
    {
        isGameover = true;
        gameOverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if(surviveTime > bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Time: " + (int)bestTime;
    }
}
