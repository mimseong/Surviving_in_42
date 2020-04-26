﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RushStory : MonoBehaviour
{
    private float timoCodingLv = 0;
    private float yasuoCodingLv = 0;
    private int timoMental = 0;
    private int yasuoMental = 0;
    [SerializeField] private RushUI rushUI;

    // Start is called before the first frame update
    void Start()
    {
        rushUI.IsRegister();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RushResult(DialogController dialogController, ConvertMethod nextButton)
    {
        float sum;
        float score = 0;
        string scoreTxt;

        sum = timoCodingLv + yasuoCodingLv + GameManager.instance.GetCodingLevel();

        switch (GameManager.instance.GetWeek())
        {
            case 1:
                score = sum / 3 / 12 * 100;
                break;
            case 2:
                score = sum / 3 / 24 * 100;
                break;
            case 3:
                score = sum / 3 / 36 * 100;
                break;
            case 4:
                score = sum / 3 / 42 * 100;
                break;
        }
        scoreTxt = "최종 점수는 \n...\n...\n" + score + "점 입니다";

        if (score < 50)
        {
            //fail;
            dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, nextButton, "멘토에게 평가를 받습니다", "멘토 : 이 코드를 설명해 보시겠어요? \n 멘토(은)는 기습공격을 시전했다!", "...\n...\n...", scoreTxt, "Rush Fail !!! \n42레벨 += 0 \n코딩레벨 += 2 \n동료와의 관계 += 5 \n스트레스 += 20", "집으로 돌아갑니다", "졸림 = 0 \n청결 = MAX \n스트레스 -= 50");
            GameManager.instance.AddCodingLevel(2);
            GameManager.instance.AddFriendship(5);
            GameManager.instance.AddStress(20);
        }
        else
        {
            //pass;
            dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, nextButton, "멘토에게 평가를 받습니다", "멘토 : 이 코드를 설명해 보시겠어요?\n멘토(은)는 기습공격을 시전했다!", "...\n...\n...", scoreTxt, "42레벨 += 1 \n코딩레벨 += 3 \n동료와의 관계 += 10 \n스트레스 += 5", "집으로 돌아갑니다", "졸림 = 0 \n청결 = MAX \n스트레스 -= 50");
            GameManager.instance.AddFortytwoLevel(1);
            GameManager.instance.AddCodingLevel(3);
            GameManager.instance.AddFriendship(10);
            GameManager.instance.AddStress(5);
        }
        GameManager.instance.AddStress(-50);
        GameManager.instance.SetClean(100);
        GameManager.instance.SetSleep(0);
        GameManager.instance.NextDay(1);
        GameManager.instance.NextDaySchedule(Schedule.MORNING);
    }

    public void RushStart(DialogController dialogController, ConvertMethod nextButton)
    {
        dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, nextButton, "러시를 시작합니다!", "랜덤으로 팀원이 배정되었습니다");
    }

    public void Timo(DialogController dialogController, ConvertMethod nextButton)
    {
        string tmoTxt;

        timoCodingLv = RandomCodingLv();
        timoMental = Random.Range(0, 101);
        tmoTxt = "티모의 코딩레벨 == " + timoCodingLv + "\n티모의 멘탈 == " + timoMental;
        dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, nextButton, "안녕하세요 티모입니다 \n잘 부탁드려요!", tmoTxt);
        
        if (timoMental < Random.Range(0, 101))
        {
            //timoRun;
            dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, nextButton, "안녕하세요 티모입니다 \n잘 부탁드려요!", tmoTxt, "티모: 도저히 못하겠어 난 집에 갈래!", "앗, \n티모가 멘탈이 안좋아 집으로 가버렸습니다");
            timoCodingLv = 0;
            Invoke("NoTimo", 5.0f);
        }
    }

    public void Yasuo(DialogController dialogController, ConvertMethod nextButton)
    {
        string ysoTxt;

        yasuoCodingLv = RandomCodingLv();
        yasuoMental = Random.Range(0, 101);
        ysoTxt = "야스오의 코딩레벨 == " + yasuoCodingLv + "\n야스오의 멘탈 == " + yasuoMental;
        dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, nextButton, "안녕하십니까 야스오입니다 \n잘 부탁드립니다!", ysoTxt);

        if (yasuoMental < Random.Range(0, 101))
        {
            //yasuoRun;
            dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, nextButton, "안녕하십니까 야스오입니다 \n잘 부탁드립니다!", ysoTxt, "야스오는 어디서 뭘 하고 있는 거지?", "앗, \n야스오가 멘탈이 깨져서 집으로 가버렸습니다");
            yasuoCodingLv = 0;
            Invoke("NoYasuo", 5.5f);
        }
    }

    public void IsRegister(DialogController dialogController, ConvertMethod nextButton)
    {
        if (!GameManager.instance.GetisRush())
        {
            rushUI.ActiveTerminal();
            dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, nextButton, "러시를 등록하지 않았습니다");
        }
        else
            rushUI.RushProcess();
    }

    private void NoTimo()
    {
        rushUI.ActiveUnavailableTimo();
    }

    private void NoYasuo()
    {
        rushUI.ActiveUnavailableYasuo();
    }

    public float RandomCodingLv()
    {
        float codingLv = 0;

        switch (GameManager.instance.GetWeek())
        {
            case 1:
                codingLv = Random.Range(0.0f, 13.0f);
                break;
            case 2:
                codingLv = Random.Range(0.0f, 25.0f);
                break;
            case 3:
                codingLv = Random.Range(0.0f, 37.0f);
                break;
            case 4:
                codingLv = Random.Range(0.0f, 43.0f);
                break;
        }
        return (codingLv);
    }
}