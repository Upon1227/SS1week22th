using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditManager : MonoBehaviour
{
    public static float credit;
    public static float scenecount;
    // Start is called before the first frame update

    public static creditManager Instance
    {
        get; private set;
    }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        scenecount++;
        if(scenecount == 1)
        {
            credit += 1000;
        }
    }
    public void Plus(float num)
    {
        credit += num;
    }

    public void minus(float num)
    {
        credit -= num;
    }
}
