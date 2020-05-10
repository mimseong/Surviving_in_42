using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamStory : MonoBehaviour
{
    [SerializeField] private ExamUI examUI = null;

    void Start()
    {
        Invoke("ActiveTerminal", 1.5f);
    }

    void Update()
    {

    }

    private void ActiveTerminal()
    {
        examUI.ActiveTerminal();
    }

    /// <summary>
    /// 시험 결과를 알려주는 함수
    /// </summary>
    /// <param name="dialogController">대사를 출력하는 스크립트</param>
    /// <param name="nextButton">넥스트 버튼을 나타내는 함수</param>
    public void ExamResult(DialogController dialogController, ConvertMethod NextButton)
    {
        float result = 0;

        if (!GameManager.instance.GetisExam() && GameManager.instance.GetWeek() != 4)
            dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "시험이 시작되었습니다", "두근두근.. \n떨린다", "...\n...?\n???\n??????????", "시험에 등록하지 않아서 시험을 칠 수 없습니다");
        else
        {
            GameManager.instance.SetWork(Work.NONE);
            switch (GameManager.instance.GetWeek())
            {
                case 1:
                    result = GameManager.instance.GetCodingLevel() / 12.0f;
                    break;
                case 2:
                    result = GameManager.instance.GetCodingLevel() / 24.0f;
                    break;
                case 3:
                    result = GameManager.instance.GetCodingLevel() / 36.0f;
                    break;
                case 4:
                    result = GameManager.instance.GetCodingLevel() / 42.0f;
                    break;
            }
            if (result > 1)
                result = 1;
            float score = result * 100;
            string scoreTxt = "점수는 " + (int)score + "점 입니다";
            if (GameManager.instance.GetCodingLevel() <= 5.0f)
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "시험이 시작되었습니다", "두근두근.. \n떨린다", "...\n...?\n???\n??????????", "로그인조차 하지 못했다", "점수는 0점입니다");
            else
            {
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "시험이 시작되었습니다", "두근두근.. \n떨린다", "...\n...?\n???\n??????????", scoreTxt, "무사히 시험을 마쳤다");
                GameManager.instance.AddFortytwoLevel(result * 1.5f);
            }
        }
        GameManager.instance.AddStress(-50);
        GameManager.instance.SetClean(100);
        GameManager.instance.SetSleep(0);
        GameManager.instance.AddCountGoHome(1);
        GameManager.instance.NextDaySchedule(Schedule.MORNING);
        GameManager.instance.SetisExam(false);
    }
}
