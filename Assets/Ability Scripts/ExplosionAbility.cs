using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAbility : MonoBehaviour
{
    [SerializeField] float thrust;
    [SerializeField] Rigidbody rb;
    [SerializeField] AudioSource boom;
    public bool createForce = true;
    public bool shouldExplode = false;
    public float LifeTime = 10f;

    public float power = 10f;
    public float radius = 5f;
    public float upwardThrust = 3f;

    public GameObject explosion;

    private Collider[] overlappers;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();


    }

    public void Update()
    {
        if(LifeTime > 0)
        {
            LifeTime -= Time.deltaTime;
            if(LifeTime <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void FixedUpdate()
    {
        if (createForce)
        {
            rb.AddForce(transform.forward * thrust);
            createForce = false;
        }

        if (shouldExplode)
        {
            Collider[] colliders = GetOverLappers();

            foreach(Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if(rb != null)
                {
                    boom.Play(0);
                    rb.AddExplosionForce(power, this.transform.position, radius, upwardThrust);
                }
            }
            Destroy(this.gameObject);
            
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        shouldExplode = true;
        Instantiate(explosion, this.transform.position, this.transform.rotation);
    }

    Collider[] GetOverLappers()
    {
        return Physics.OverlapSphere(this.transform.position, radius);
    }


}
