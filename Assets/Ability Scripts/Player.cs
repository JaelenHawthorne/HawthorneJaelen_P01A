using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] AbilityLoadout abilityLoadout;
    [SerializeField] Ability startingAbility;
    [SerializeField] Ability newAbilityToTest;

    [SerializeField] Transform testTarget = null;

    public Transform CurrentTarget { get; private set; }

    private void Awake()
    {
        if( startingAbility != null)
        {
            abilityLoadout?.EquipApility(startingAbility);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        CurrentTarget = newTarget;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            abilityLoadout.UseEquippedAbility(CurrentTarget);
        }
        //use equipped weapon
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            abilityLoadout.EquipApility(newAbilityToTest);
        }
        // set target for testing
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetTarget(testTarget);
        }
    }

}
