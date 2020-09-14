using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cure : Ability
{
    int healamount = 25;

    public override void Use(Transform origin, Transform target)
    {
        // dont allow us to cast this spell without a target
        if(target == null) { return; }


        Debug.Log("Cast Cure on " + target.gameObject.name);
            //if the target has health, heal it
        target.GetComponent<Health>()?.Heal(healamount);
    }
}
