using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    [SerializeField] private float knockBackStrength;


    private void OnCollisionEnter(Collision collision)
    {
        
            Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

            if (rb != null)
            {
                Vector3 direction = collision.transform.position - transform.position;
                direction.y = 0;

                rb.AddForce(direction.normalized * knockBackStrength, ForceMode.Impulse);
            }
        }
    
}
