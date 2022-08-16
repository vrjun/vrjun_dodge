using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int healAmount = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 15f * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {

                playerController.GetHeal(healAmount);
                
            }

            Destroy(gameObject);
        }
    }
}
