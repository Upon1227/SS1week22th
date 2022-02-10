using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSlot : MonoBehaviour
{
    string SceneName;
    private void Start()
    {
        SceneName = SceneManager.GetActiveScene().name;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (SceneName == "MainSlot")
            {
                SceneManager.LoadScene("MainSlot4");
            }
            else if (SceneName == "MainSlot4")
            {
                SceneManager.LoadScene("MainSlot5");
            }
            else
            {
                //‰½‚à‚µ‚È‚¢
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (SceneName == "MainSlot5")
            {
                SceneManager.LoadScene("MainSlot4");
            }
            else if (SceneName == "MainSlot4")
            {
                SceneManager.LoadScene("MainSlot");
            }
            else
            {
                //‰½‚à‚µ‚È‚¢
            }
        }
    }

    
    
}
