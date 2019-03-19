using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleController : MonoBehaviour
{
    public float Speed;
    //public GameObject explosion;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * Speed;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit Enemy");
            // Spawn explosion. Explosion removes itself
            //Instantiate(explosion, target.transform.position, target.transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
