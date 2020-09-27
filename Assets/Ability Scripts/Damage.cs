using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour{


    [SerializeField] int damageAmount = 1;

    public AudioSource hurtSound;


    // Start is called before the first frame update
    void Start()
    {
        hurtSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            hurtSound.Play();
            FindObjectOfType<Health1>().hurtPlayer(damageAmount);
        }
    }
}
