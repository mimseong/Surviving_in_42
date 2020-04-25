using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExamStory : MonoBehaviour
{
    [SerializeField] private ExamUI examUI;

    void Start()
    {
        examUI.ActiveTerminal();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ExamResult(DialogController dialogController, ConvertMethod NextButton)
    {
        float result = 0;

        if (!GameManager.instance.GetisExam())
            dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "시험이 시작되었습니다", "두근두근.. \n떨린다", "...\n...?\n???\n??????????", "시험에 등록하지 않아서 시험을 칠 수 없습니다", "42레벨 +0 \n스트레스 증가");
        else
        {
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
            string scoreTxt = "점수는 " + score + "점 입니다";
            string fortytwoTxt = "42레벨 += " + GameManager.instance.GetFortytwoLevel();
            if (GameManager.instance.GetCodingLevel() <= 5.0f)
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "시험이 시작되었습니다", "두근두근.. \n떨린다", "...\n...?\n???\n??????????", "로그인조차 하지 못했다", "점수는 0점입니다", "42레벨 +0 \n스트레스 증가");
            else
            {
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "시험이 시작되었습니다", "두근두근.. \n떨린다", "...\n...?\n???\n??????????", "무사히 시험을 마쳤다", scoreTxt, fortytwoTxt);
                GameManager.instance.AddFortytwoLevel(result * 2);
            }
        }
        GameManager.instance.AddStress(-50);
        GameManager.instance.SetClean(100);
        GameManager.instance.SetSleep(0);
        GameManager.instance.NextDaySchedule(Schedule.MORNING);
    }
}
