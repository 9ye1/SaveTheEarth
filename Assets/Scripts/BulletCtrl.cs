using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    public float damage = 20.0f;
    public float speed = 1000.0f;
    public float DestroyTime = 1.0f;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        Destroy(gameObject, DestroyTime);
    }


    
    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision coll)
    {

        if (coll.collider.CompareTag("Monster"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            
        }
        Destroy(gameObject);
        
    }
}
