using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void LoadZombie()
    {
        SceneManager.LoadScene(1);
    }
    
    public void LoadCar()
    {
        SceneManager.LoadScene(2);
    }

    
    
    
    private void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
    }
}
