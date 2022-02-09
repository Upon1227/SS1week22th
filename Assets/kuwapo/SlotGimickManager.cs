using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotGimickManager : MonoBehaviour
{
    [SerializeField] GameObject starText;
    [SerializeField] GameObject readyText;
    [SerializeField] GameObject bonusText;
    [SerializeField] GameObject insertMedal;

    [SerializeField] Animator center28Animator;
    [SerializeField] Animator reelFrameAnimator;
    [SerializeField] Animator hundleAnimator;

    [SerializeField] Button stopButton;
    [SerializeField] Button divisibleButton; 
    [SerializeField] Button indivisibleButton;




    public static SlotGimickManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        stopButton.interactable = false;
        divisibleButton.interactable = false;
        indivisibleButton.interactable = false;

    }

    //ハンドル（レバー）のアニメーション発動
    public void HundleGimick()
    {
        hundleAnimator.SetTrigger("HundleTrigger");
    }

    //28のエンブレムを点滅
    public void Flash28()
    {
        center28Animator.SetTrigger("28Trigger");
    }

    //リールの枠を点滅
    public void FlashReelFrame()
    {
        reelFrameAnimator.SetTrigger("SlotReelTrigger");
    }

    //右側にあるSTARTのパネルのテキストを点灯
    public void TurnOnStaratLump()
    {
        starText.SetActive(true);
    }
    //右側にあるSTARTのパネルのテキストを消灯
    public void TurnOffStaratLump()
    {
        starText.SetActive(false);
    }

    //右側にあるREADYのパネルのテキストを点灯
    public void TurnOnReadyLump()
    {
        readyText.SetActive(true);
    }
    //右側にあるREADYのパネルのテキストを消灯
    public void TurnOffReadyLump()
    {
        readyText.SetActive(false);
    }

    //Bonusのテキストを点灯
    public void TurnOnBounusLump()
    {
        bonusText.SetActive(true);
    }
    //Bounusのテキストを消灯
    public void TurnOffBonusLump()
    {
        bonusText.SetActive(false);
    }

    //InsertMedalを点灯
    public void TurnOnInsertLump()
    {
        insertMedal.SetActive(true);
    }
    //InsertMedalをを消灯
    public void TurnOffInsertLump()
    {
        insertMedal.SetActive(false);
    }

    //STOPボタンを有効にする
    public void ToEnableStopButton()
    {
        stopButton.interactable = true;

    }
    //STOPボタンを無効にする
    public void ToDisableStopButton()
    {
        stopButton.interactable = false;
    }

    //割切れるボタンを有効にする
    public void ToEnableDivisibleButton()
    {
       　divisibleButton.interactable = true;

    }
    //割切れるボタンを無効にする
    public void ToDisableDivisibleButton()
    {
        divisibleButton.interactable = false;
    }

    //割切れないボタンを有効にする
    public void ToEnableIndivisibleButton()
    {
        indivisibleButton.interactable = true;

    }
    //割切れないボタンを無効にする
    public void ToDisableIndivisibleButton()
    {
        indivisibleButton.interactable = false;
    }





}
