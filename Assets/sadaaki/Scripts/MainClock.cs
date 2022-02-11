using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainClock : MonoBehaviour
{
    public static float Timer = 0.0F;
    public static int Clock = 9;
    public Text ClockText;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);

    }

    // Update is called once per frame
    void Update()
    {
        ClockText.text = Clock + ":00";
        Timer += Time.deltaTime;
        if (Timer>37.5)
        {
            Timer = 0;
            Clock += 1;
        }
    }
}
