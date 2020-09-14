using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameController : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        { //If you press R
            SceneManager.LoadScene("AbilityTest"); 
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
}
