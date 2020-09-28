using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cure1 : MonoBehaviour
{


    [SerializeField] int HealAmount = 10;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            FindObjectOfType<Health1>().healPlayer(HealAmount);
            
        }
    }

  
}
