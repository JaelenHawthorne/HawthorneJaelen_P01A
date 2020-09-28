using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health1 : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [SerializeField] int currentHealth;

    [SerializeField] Slider healthBar;
    [SerializeField] Text healthText;



    public bool IsDead = false;
 


    void Start()
    {
        healthBar.maxValue = maxHealth;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = currentHealth + " / 100";
        healthBar.value = currentHealth;
        if (currentHealth == 0)
        {
            FindObjectOfType<ThirdPersonMovement>().Dead();
        }
    }


    public void healPlayer(int healAmount)
    {
        currentHealth += healAmount;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        FindObjectOfType<ThirdPersonMovement>().Cure();
    }

    public void hurtPlayer(int damage)
    {
        currentHealth -= damage;

        FindObjectOfType<ThirdPersonMovement>().Hurt();
    }

        
    

}
