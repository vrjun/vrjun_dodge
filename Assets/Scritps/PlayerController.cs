using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    public float speed = 8f;

    public int hp = 100;
    public HPBar hpbar;
    private Transform tr;


    private float spawnRate = 0.2f;
    private float timeAfterSpawn;
    public GameObject playerbulletPrefab;

    public void GetDamage(int damage)
    {
        hp -= damage;
        hpbar.SetHP(hp);
        if (hp <= 0)
        {
            Die();
        }
    }

    public void GetHeal(int healAmount)
    {
        hp += healAmount;
        
        if (hp > 100)
        {
            hp = 100;
        }

        hpbar.SetHP(hp);
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidBody.velocity = newVelocity;

        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray.origin, ray.direction, out hit))
        {
            Vector3 projectedPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            Vector3 currentPos = transform.position;
            Vector3 direction = projectedPos - currentPos;
            tr.forward = direction;
        }




        timeAfterSpawn += Time.deltaTime;
        if(Input.GetButton("Fire1") && timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            GameObject bullet = Instantiate(playerbulletPrefab, transform.position, transform.rotation);
        }

    }

    

    void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManger = FindObjectOfType<GameManager>();
        gameManger.EndGame();
    }
}
