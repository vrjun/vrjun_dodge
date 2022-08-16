using UnityEngine;

public class PlayerBullet : MonoBehaviour
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
        if (other.tag == "Bullet")
        {

            Bullet bullet = other.GetComponent<Bullet>();
            if (bullet != null)
            {

                Destroy(bullet.gameObject);

            }
            Destroy(gameObject);

        }
        else if(other.tag == "BulletSpawner")
        {
            
            BulletSpawner spawner = other.GetComponent<BulletSpawner>();
            if(spawner != null)
            {

                spawner.GetDamage(damage);
                
            }
            Destroy(gameObject);

        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
