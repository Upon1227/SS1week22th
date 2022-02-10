using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager5 : MonoBehaviour
{
    int[] slotnum = {10948,11508,11648,11676,12096,12432,12768,13328,13608,14448,14728,15288,15568,15680,16268,16296,17444,18676,18928,19096};
    int butslotnum;
    public Text Number1;
    public Text Number2;
    public Text Number3;
    public Text Number4;
    public Text Number5;
    public GameObject[] kakushi;
    int iti, zyu, hya,sen,man;
    public Animator[] anim;
    public RectTransform[] numrec;
    int slott;
    public Text ScoreText;
    public Text HABETUTEXT;
    public int slot;
    bool isStart;
    // Start is called before the first frame update
    void Start()
    {
        anim[0].SetTrigger("Start");
        anim[1].SetTrigger("Start");
        anim[2].SetTrigger("Start");
        anim[3].SetTrigger("Start");
        anim[4].SetTrigger("Start");

    }

    public void SlotStart()
    {
        if(isStart == false)
        {
            int butslot = Random.Range(10000, 100000);
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
            Debug.Log(slott);
            //12590
            man = slott / 10000;
            //1
            int amariman = slott % 10000;
            //2590
            sen = amariman / 1000;
            //2
            int senamari = amariman % 1000;
            //590
            //結果250
            hya = senamari / 100;
            //2
            int hyakuamari = senamari % 100;
            //90
            zyu = hyakuamari / 10;
            //9
            iti = hyakuamari % 10;
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
                score += slott * 0.5f;
            }
        }
        isStart = false;
    }

    
    IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.15f);
        for(int i = 0;i < numrec.Length;i++)
        {
            switch (i)
            {
                case 0:
                    numrec[i].localPosition = new Vector3(485, 202, 0);
                    break;
                case 1:
                    numrec[i].localPosition = new Vector3(258, 202, 0);
                    break;
                case 2:
                    numrec[i].localPosition = new Vector3(23, 202, 0);
                    break;
                case 3:
                    numrec[i].localPosition = new Vector3(-220, 202, 0);
                    break;
                case 4:
                    numrec[i].localPosition = new Vector3(-469, 202, 0);
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
            StartCoroutine(OpenMan());
        }
       
    }

    IEnumerator OpenMan()
    {
        yield return new WaitForSeconds(2);
        Number5.text = man.ToString();
        Number5.gameObject.SetActive(true);
        kakushi[4].SetActive(true);
        anim[4].SetTrigger("Start");
        Debug.Log(man);
    }

    IEnumerator OpenSen()
    {
        yield return new WaitForSeconds(3);
        Number4.text = sen.ToString();
        Number4.gameObject.SetActive(true);
        kakushi[3].SetActive(true);
        anim[3].SetTrigger("Start");
        Debug.Log(sen);
    }

    IEnumerator OpenHyaku()
    {
        yield return new WaitForSeconds(4);
        Number3.text = hya.ToString();
        Number3.gameObject.SetActive(true);
        kakushi[0].SetActive(true);
        anim[0].SetTrigger("Start");
        Debug.Log(hya);
    }
    IEnumerator Openzyuu()
    {
        yield return new WaitForSeconds(5);
        Number2.text = zyu.ToString();
        Number2.gameObject.SetActive(true);
        kakushi[1].SetActive(true);
        anim[1].SetTrigger("Start");
        Debug.Log(zyu);
    }
    IEnumerator Openbyou()
    {
        yield return new WaitForSeconds(6);
        Number1.text = iti.ToString();
        Number1.gameObject.SetActive(true);
        kakushi[2].SetActive(true);
        anim[2].SetTrigger("Start");

        Debug.Log(iti);
    }
}
