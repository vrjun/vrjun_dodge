using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3.0f;

    private Transform target;
    private float spawnRate;
    private float timerAfterSpawn;
    // Start is called before the first frame update

    public int hp = 100;
    public HPBar hpbar;
    public GameObject level;

    public void GetDamage(int damage)
    {
        hp -= damage;
        hpbar.SetHP(hp);
        if(hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void Start()
    {
        timerAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        timerAfterSpawn += Time.deltaTime;

        if(timerAfterSpawn >= spawnRate)
        {
            timerAfterSpawn = 0f;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
