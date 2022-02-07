using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int[] slotnum = {112,140,168,189,216,243,270,298,321,349,377,517,629,685,713,769,825,853,909,965};
    int butslotnum;
    public Text Number1;
    public Text Number2;
    public Text Number3;
    public GameObject[] kakushi;
    int iti, zyu, hya;
    public Animator[] anim;
    public RectTransform[] numrec;
    int slott;
    public Text ScoreText;
    public Text HABETUTEXT;
    public int slot;
    // Start is called before the first frame update
    void Start()
    {
        anim[0].SetTrigger("Start");
        anim[1].SetTrigger("Start");
        anim[2].SetTrigger("Start");

    }

    public void SlotStart()
    {
        int butslot = Random.Range(100, 1000);
        int slotrandom = Random.Range(1, slotnum.Length + 1);
        int slotnumm = slotnum[slotrandom];
        int slot = Random.Range(1, 5);
        if(slot < 3)
        {
            slott = butslot;
        }
        else
        {
            slott = slotnumm;
        }
        for(int i = 0;i < anim.Length; i++)
        {
            anim[i].SetTrigger("back");
        }
         hya = slott / 100;
         int hyakuamari = slott % 100;
         zyu = hyakuamari / 10;
         iti = hyakuamari % 10;
      
        StartCoroutine(Reset());
        HABETUTEXT.text = "";

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
    }

    
    IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.15f);
        for(int i = 0;i < numrec.Length;i++)
        {
            switch (i)
            {
                case 0:
                    numrec[i].localPosition = new Vector3(-235, 202, 0);
                    break;
                case 1:
                    numrec[i].localPosition = new Vector3(0, 202, 0);
                    break;
                case 2:
                    numrec[i].localPosition = new Vector3(227, 202, 0);
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
        StartCoroutine(OpenHyaku());
        StartCoroutine(Openzyuu());
        StartCoroutine(Openbyou());
    }

    IEnumerator OpenHyaku()
    {
        yield return new WaitForSeconds(2);
        Number1.text = hya.ToString();
        Number1.gameObject.SetActive(true);
        kakushi[0].SetActive(true);
        anim[0].SetTrigger("Start");
    }
    IEnumerator Openzyuu()
    {
        yield return new WaitForSeconds(3);
        Number2.text = zyu.ToString();
        Number2.gameObject.SetActive(true);
        kakushi[1].SetActive(true);
        anim[1].SetTrigger("Start");
    }
    IEnumerator Openbyou()
    {
        yield return new WaitForSeconds(4);
        Number3.text = iti.ToString();
        Number3.gameObject.SetActive(true);
        kakushi[2].SetActive(true);
        anim[2].SetTrigger("Start");
    }
}