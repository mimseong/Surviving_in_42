using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSQstory : MonoBehaviour
{
    float jinxLv = 0;
    [SerializeField] private BSQUI bsqUI;

    // Start is called before the first frame update
    void Start()
    {
        bsqUI.BSQprocess();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// bsq 시작하는함수
    /// </summary>
    /// <param name="dialogController"></param>
    /// <param name="nextButton"></param>
    public void BSQstart(DialogController dialogController, ConvertMethod nextButton)
    {
        dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, nextButton, "BSQ를 시작합니다! \n시험 전까지 BSQ를 진행합니다", "랜덤으로 팀원이 배정되었습니다");
    }


    /// <summary>
    /// bsq결과 알려주는 함수
    /// </summary>
    /// <param name="dialogController"></param>
    /// <param name="nextButton"></param>
    public void BSQresult(DialogController dialogController, ConvertMethod nextButton)
    {
        float sum;
        float score = 0;
        string scoreTxt;

        sum = jinxLv + GameManager.instance.GetCodingLevel();
        score = sum / 2 / 42 * 100;
        scoreTxt = "최종 점수는 \n...\n...\n" + (int)score + "점 입니다";

        if (score < 50)
        {
            //fail;
            dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, nextButton, "동료에게 평가를 받습니다", "평가자 : 이 코드를 설명해 보시겠어요? \n 평가자(은)는 기습공격을 시전했다!", "...\n...\n...", scoreTxt, "BSQ Fail !!! \n42레벨 += 0 \n코딩레벨 += 2 \n동료와의 관계 += 5 \n스트레스 += 20", "집으로 돌아갑니다", "졸림 = 0 \n청결 = MAX \n스트레스 -= 50");
            GameManager.instance.AddCodingLevel(2);
            GameManager.instance.AddFriendship(5);
            GameManager.instance.AddStress(20);
        }
        else
        {
            //pass;
            dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, nextButton, "동료에게 평가를 받습니다", "평가자 : 이 코드를 설명해 보시겠어요?\n평가자(은)는 기습공격을 시전했다!", "...\n...\n...", scoreTxt, "42레벨 += 1 \n코딩레벨 += 3 \n동료와의 관계 += 10 \n스트레스 += 5", "집으로 돌아갑니다", "졸림 = 0 \n청결 = MAX \n스트레스 -= 50");
            GameManager.instance.AddFortytwoLevel(1);
            GameManager.instance.AddCodingLevel(3);
            GameManager.instance.AddFriendship(10);
            GameManager.instance.AddStress(5);
        }
        GameManager.instance.AddStress(-50);
        GameManager.instance.SetClean(100);
        GameManager.instance.SetSleep(0);
        GameManager.instance.NextDay(3);
        GameManager.instance.NextDaySchedule(Schedule.MORNING);
    }

    /// <summary>
    /// 팀원 소개하는 함수
    /// </summary>
    /// <param name="dialogController"></param>
    /// <param name="nextButton"></param>
    public void Jinx(DialogController dialogController, ConvertMethod nextButton)
    {
        string jinxTxt;
        jinxLv = (float)GameManager.instance.GetFriendship() / 100f * 42f;

        jinxTxt = "징크스의 코딩레벨 == " + jinxLv;
        if (GameManager.instance.GetFriendship() >= 50)
            dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, nextButton, "동료와의 관계가 높아서 좋은 동료를 구했습니다!", "안녕하세요 징크스입니다 \n잘 부탁드려요!", jinxTxt);
        else
            dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, nextButton, "안녕하세요 징크스입니다 \n잘 부탁드려요!", jinxTxt);
    }
}
