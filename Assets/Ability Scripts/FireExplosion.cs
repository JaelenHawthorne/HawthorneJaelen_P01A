using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExplosion : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform shotPos;
    [SerializeField] AudioSource Boom;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Boom.Play(0);
            Instantiate(projectile, shotPos.position, shotPos.rotation);
        }


    }

}
