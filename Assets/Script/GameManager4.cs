using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager4 : MonoBehaviour
{
    int[] slotnum = {1428,1568,1064,1596,1680,1652,1904,1932,1120,1148,1008,1540,1260,685,1232,1260,1344,1848,1316,1456};
    int butslotnum;
    public Text Number1;
    public Text Number2;
    public Text Number3;
    public Text Number4;
    public GameObject[] kakushi;
    int iti, zyu, hya,sen;
    public Animator[] anim;
    public RectTransform[] numrec;
    int slott;
    public Text ScoreText;
    public Text HABETUTEXT;
    public int slot;
    creditManager creditManager;
    bool isStart;
    // Start is called before the first frame update
    void Start()
    {
        score = creditManager.credit;
        creditManager = GameObject.Find("credit").GetComponent<creditManager>();
        anim[0].SetTrigger("Start");
        anim[1].SetTrigger("Start");
        anim[2].SetTrigger("Start");
        anim[3].SetTrigger("Start");
    }

    public void SlotStart()
    {
        if(isStart == false && score >= 1000)
        {
            score -= 1000;
            int butslot = Random.Range(1000, 10000);
            int slotrandom = Random.Range(1, slotnum.Length + 1);
            int slotnumm = slotnum[slotrandom];
            int slot = Random.Range(1, 5);
            if (slot < 3)
            {
                slott = butslot;
            }
            else
            {
                slott = slotnumm;
            }
            for (int i = 0; i < anim.Length; i++)
            {
                anim[i].SetTrigger("back");
            }

            //1259
            sen = slott / 1000;
            //結果2
            int senamari = slott % 1000;
            //結果250
            hya = senamari / 100;
            //2
            int hyakuamari = senamari % 100;
            zyu = hyakuamari / 10;
            iti = zyu % 10;
            //50


            StartCoroutine(Reset());
            HABETUTEXT.text = "";
            isStart = true;
        }

    }
    float score;
    private void Update()
    {
        ScoreText.text = score.ToString();
    }
    public void HANBETI(bool isHABETU)
    {
        if (isHABETU)
        {
            if(slott % 28 == 0)
            {
                HABETUTEXT.text = "正解！";
                score += slott;
                creditManager.Plus(slott);
            }
            else
            {
                HABETUTEXT.text = "不正解！";
            }
        }
        else
        {
            if (slott % 28 == 0)
            {
                HABETUTEXT.text = "不正解！";
            }
            else
            {
                HABETUTEXT.text = "正解！";
                if (slott % 2 == 1)
                {
                    slott += 1;
                }
                score += slott * 0.5f;
                creditManager.Plus(slott * 0.5f);
            }
        }
    }

    
    IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.15f);
        for(int i = 0;i < numrec.Length;i++)
        {
            switch (i)
            {
                case 0:
                    numrec[i].localPosition = new Vector3(-102, 202, 0);
                    break;
                case 1:
                    numrec[i].localPosition = new Vector3(133, 202, 0);
                    break;
                case 2:
                    numrec[i].localPosition = new Vector3(360, 202, 0);
                    break;
                case 3:
                    numrec[i].localPosition = new Vector3(-345, 202, 0);
                    break;
            }
   
        }
        yield return new WaitForSeconds(0.2f); 
        for (int i = 0; i < kakushi.Length; i++)
        {
            kakushi[i].SetActive(false);
        }
    }
    public void Stop()
    {
        if(isStart == true)
        {
            StartCoroutine(OpenSen());
            StartCoroutine(OpenHyaku());
            StartCoroutine(Openzyuu());
            StartCoroutine(Openbyou());
        }

    }

    IEnumerator OpenSen()
    {
        yield return new WaitForSeconds(2);
        Number4.text = sen.ToString();
        Number4.gameObject.SetActive(true);
        kakushi[3].SetActive(true);
        anim[3].SetTrigger("Start");
    }

    IEnumerator OpenHyaku()
    {
        yield return new WaitForSeconds(3);
        Number1.text = hya.ToString();
        Number1.gameObject.SetActive(true);
        kakushi[0].SetActive(true);
        anim[0].SetTrigger("Start");
    }
    IEnumerator Openzyuu()
    {
        yield return new WaitForSeconds(4);
        Number2.text = zyu.ToString();
        Number2.gameObject.SetActive(true);
        kakushi[1].SetActive(true);
        anim[1].SetTrigger("Start");
    }
    IEnumerator Openbyou()
    {
        yield return new WaitForSeconds(5);
        Number3.text = iti.ToString();
        Number3.gameObject.SetActive(true);
        kakushi[2].SetActive(true);
        anim[2].SetTrigger("Start");
        isStart = false;
    }
}
