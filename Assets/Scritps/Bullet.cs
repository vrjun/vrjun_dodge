using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    Rigidbody bulletRigidbody;
    public int damage = 30;

    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * 8f;

        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            
            PlayerController playerController = other.GetComponent<PlayerController>();
            if(playerController != null)
            {
               
                playerController.GetDamage(damage);
                Destroy(gameObject);
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
