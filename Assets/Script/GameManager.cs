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
    bool isStart;
    bool isStop;
    creditManager creditManager;
    bool HABETUstandby;
    public SlotGimickManager slotGimickManager;
    // Start is called before the first frame update
    void Start()
    {
        score = creditManager.credit;
        creditManager = GameObject.Find("credit").GetComponent<creditManager>();
        anim[0].SetTrigger("Start");
        anim[1].SetTrigger("Start");
        anim[2].SetTrigger("Start");

    }

    public void SlotStart()
    {
        
        if (isStart == false && score >= 100)
        {
            SoundManager.Instance.PlaySE(SESoundData.SE.Hundle);
            //SoundManager.Instance.PlayReelSE(BGMSoundData.BGM.Reel);
            slotGimickManager.HundleGimick();
            score -= 100;
            creditManager.minus(100);
            int butslot = Random.Range(100, 1000);
            int slotrandom = Random.Range(4, 36);
            int slotnumm = 28 * slotrandom;
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
            hya = slott / 100;
            int hyakuamari = slott % 100;
            zyu = hyakuamari / 10;
            iti = hyakuamari % 10;

            StartCoroutine(Reset());
            HABETUTEXT.text = "";
            isStart = true;
            isStop = true;
            
        }
       

    }
    float score;
    private void Update()
    {
        ScoreText.text = score.ToString();
    }
    public void HANBETI(bool isHABETU)
    {
        if (HABETUstandby)
        {
            if (isHABETU)
            {
                if (slott % 28 == 0)
                {
                    HABETUTEXT.text = "?????????";
                    score += slott;
                    creditManager.Plus(slott);
                    slotGimickManager.Flash28();
                    slotGimickManager.TurnOnBounusLump();
                    SoundManager.Instance.PlaySE(SESoundData.SE.True);
                }
                else
                {
                    HABETUTEXT.text = "????????????";
                    SoundManager.Instance.PlaySE(SESoundData.SE.False);
                }
            }
            else
            {
                if (slott % 28 == 0)
                {
                    HABETUTEXT.text = "????????????";
                    SoundManager.Instance.PlaySE(SESoundData.SE.False);

                }
                else
                {
                    HABETUTEXT.text = "?????????";
                    if (slott % 2 == 1)
                    {
                        slott += 1;
                    }
                    score += slott * 0.5f;
                    creditManager.Plus(slott * 0.5f);
                    slotGimickManager.Flash28();
                    SoundManager.Instance.PlaySE(SESoundData.SE.True);
                    slotGimickManager.TurnOnBounusLump();
                }
            }
            HABETUstandby = false;
            isStart = false;
            
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
                    numrec[i].localPosition = new Vector3(-252, 202, 0);
                    break;
                case 1:
                    numrec[i].localPosition = new Vector3(-12, 202, 0);
                    break;
                case 2:
                    numrec[i].localPosition = new Vector3(220, 202, 0);
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
        if(isStop == true)
        {
            SoundManager.Instance.PlaySE(SESoundData.SE.Click);
            StartCoroutine(OpenHyaku());
            StartCoroutine(Openzyuu());
            StartCoroutine(Openbyou());
            isStop = false;
            Debug.Log("Stop");
        }

    }

    IEnumerator OpenHyaku()
    {
        yield return new WaitForSeconds(2);
        Number1.text = hya.ToString();
        Number1.gameObject.SetActive(true);
        kakushi[0].SetActive(true);
        anim[0].SetTrigger("Start");
        SoundManager.Instance.PlaySE(SESoundData.SE.Stop);

    }
    IEnumerator Openzyuu()
    {
        yield return new WaitForSeconds(3);
        Number2.text = zyu.ToString();
        Number2.gameObject.SetActive(true);
        kakushi[1].SetActive(true);
        anim[1].SetTrigger("Start");
        SoundManager.Instance.PlaySE(SESoundData.SE.Stop);
    }
    IEnumerator Openbyou()
    {
        yield return new WaitForSeconds(4);
        Number3.text = iti.ToString();
        Number3.gameObject.SetActive(true);
        kakushi[2].SetActive(true);
        anim[2].SetTrigger("Start");
        SoundManager.Instance.PlaySE(SESoundData.SE.Stop);
        HABETUstandby = true;
    }
}
