using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExplosion : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform shotPos;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(projectile, shotPos.position, shotPos.rotation);
        }


    }

}
