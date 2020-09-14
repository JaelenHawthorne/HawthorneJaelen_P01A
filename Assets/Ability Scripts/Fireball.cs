using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Ability
{
    [SerializeField] GameObject projectilSpawned = null;

    int rank = 1;

    public override void Use(Transform origin, Transform target)
    {
        // spawn jrojectile using origin's forward direction by default
        GameObject projectile = Instantiate(projectilSpawned, origin.position, origin.rotation);
        // if we have a target, rotate projectile towards it on spawn

        if (target != null)
        {
            projectile.transform.LookAt(target);
        }

        Destroy(projectile, 3.5f);
    }



}
