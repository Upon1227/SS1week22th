using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainScene : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("MainSlot");
    }
}
