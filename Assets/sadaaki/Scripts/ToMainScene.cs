using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainScene : MonoBehaviour
{
    public void ChangeScene()
    {
        FadeManager.Instance.LoadScene("MainSlot", 1.0f);

    }
}
