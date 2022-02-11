using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainClock : MonoBehaviour
{
    public static float Timer = 0.0F;
    public float timercopy = 0.0F;
    public static int Clock = 9;
    public Text ClockText;
    creditManager creditManager;

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
        timercopy += Time.deltaTime;
        if (Timer>37.5)
        {
            Timer = 0;
            timercopy = 0;
            Clock += 1;
        }

        if(Clock == 17)
        {
            SceneManager.LoadScene("MainSlot5");
            creditManager = GameObject.Find("credit").GetComponent<creditManager>();
            float Score = creditManager.credit;
            naichilab.RankingLoader.Instance.SendScoreAndShowRanking(Score);
        }

    }
}
