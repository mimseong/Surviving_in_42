using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyStory : MonoBehaviour
{
    [SerializeField] private StudyUIManager studyUIManager;
    // Start is called before the first frame update
    void Start()
    {
        studyUIManager.ActiveImage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void NextButton()
    {
        studyUIManager.NextButton(true);
    }

    /// <summary>
    /// 선택지에 따라 어떤 스케쥴을 실행할지 결정하는 함수
    /// </summary>
    /// <param name="dialogController">대사를 출력하는 스크립트</param>
    /// <param name="work">할일</param>
    public void DecideStudy(DialogController dialogController, Work work)
    {
        switch (work)
        {
            case Work.SOLO_CODING:
                SoloCoding(dialogController);
                break;
            case Work.DUO_CODING:
                DuoCoding(dialogController);
                break;
            case Work.EVALUATE:
                Evaluate(dialogController);
                break;
            case Work.EVALUATED:
                Evaluted(dialogController);
                break;
            case Work.CHEATING:
                Cheating(dialogController);
                break;
        }
        GameManager.instance.NextSchedule(1);
    }

    private void SoloCoding(DialogController dialogController)
    {
        dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "스스로 학습하기로 했다\n열심히 코딩을 했다!");
        GameManager.instance.AddCodingLevel(1.0f);
        GameManager.instance.AddClean(-10);
        GameManager.instance.AddStress(10);
        GameManager.instance.AddSleep(20);
    }

    private void DuoCoding(DialogController dialogController)
    {
        dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "동료와 함께 코딩학습을 했다\n많은 것을 배웠다!");
        GameManager.instance.AddClean(-10);
        GameManager.instance.AddStress(10);
        GameManager.instance.AddSleep(20);
        GameManager.instance.AddCodingLevel(0.7f);
        GameManager.instance.AddFriendship(2);
    }

    private void Evaluate(DialogController dialogController)
    {
        int situation = Random.Range(0, 5);
        if (GameManager.instance.GetWeek() == 1 && (GameManager.instance.GetDay() == Day.TUE || GameManager.instance.GetDay() == Day.WED))
        {
            dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "평가를 하러 갔다", "엘레베이터가 지하로 내려가서 지각했다!");
            studyUIManager.Elevator();
            GameManager.instance.AddCodingLevel(0.5f);
        }
        else
        {
            if (GameManager.instance.GetCondition() == Condition.DIRTY)
                GameManager.instance.AddFriendship(-2);
            else
                GameManager.instance.AddFriendship(2);
            switch (situation)
            {
                case 0:
                    dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "평가를 하러 갔다", "동료가 다른 층에 있었다 \n계단을 이용해서 조금 건강해진 기분이다");
                    GameManager.instance.AddCodingLevel(0.5f);
                    break;
                case 1:
                    dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "평가를 하러 갔다", "나보다 진도가 느린 사람을 만났다\n내가 배운 것을 알려주고 왔다 \n뿌듯하다");
                    GameManager.instance.AddCodingLevel(0.5f);
                    break;
                case 2:
                    dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "평가를 하러 갔다", "동료와 친해졌다 \n꿀팁을 공유하고 왔다");
                    GameManager.instance.AddCodingLevel(0.5f);
                    break;
                case 3:
                    dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "평가를 하러 갔다", "나보다 더 진도가 빠른 사람을 만났다 \n조금 긴장됐지만 잘 가르쳐줘서 많은 것을 배웠다");
                    GameManager.instance.AddCodingLevel(0.5f);
                    break;
                case 4:
                    dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "평가를 하러 갔다", "무례한 동료를 만났다 \n너무 속상하다", "ㅂㄷㅂㄷ...");
                    StartCoroutine(RudeEval(2.0f));
                    GameManager.instance.AddStress(30);
                    GameManager.instance.AddFriendship(-2);
                    break;
            }
        }
        GameManager.instance.AddClean(-10);
        GameManager.instance.AddStress(10);
        GameManager.instance.AddSleep(20);
        GameManager.instance.AddEvalPoint(2);
    }

    private void Evaluted(DialogController dialogController)
    {
        int situation = Random.Range(0, 5);
        switch (situation)
        {
            case 0:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "평가를 받았다", "버그가 없었으면 좋겠다", "...\n...\n...\n무사히 통과했다!");
                GameManager.instance.AddFortytwoLevel(0.8f);
                break;
            case 1:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "평가를 받았다", "norm 체크를 했던가?", "...\n...\n다행히 통과했다!");
                GameManager.instance.AddFortytwoLevel(0.8f);
                break;
            case 2:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "평가를 받았다", "제발 한번에 통과했으면...", "...\n...\nsegmentation fault!");
                GameManager.instance.AddStress(10);
                break;
            case 3:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "평가를 받았다", "이번엔 제발 통과하자!", "...\n...\n드디어 통과했다!");
                GameManager.instance.AddFortytwoLevel(0.8f);
                break;
            case 4:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "평가를 받았다", "이번엔 제발 통과하자!", "...\n...\nsegmentation fault가 또...");
                GameManager.instance.AddStress(10);
                break;
        }
        if (GameManager.instance.GetCondition() == Condition.DIRTY)
            GameManager.instance.AddFriendship(-2);
        else
            GameManager.instance.AddFriendship(2);
        GameManager.instance.AddClean(-10);
        GameManager.instance.AddStress(10);
        GameManager.instance.AddSleep(20);
        GameManager.instance.AddCodingLevel(0.5f);
        GameManager.instance.AddEvalPoint(-2);
    }

    private void Cheating(DialogController dialogController)
    {
        int situation = Random.Range(0, 2);
        switch (situation)
        {
            case 0:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "컨닝을 했다", "양심의 가책을 느낀다", "...\n...\n다행스럽게도 무사히 통과했다!");
                StartCoroutine(CheatingResult(5.0f, true));
                GameManager.instance.AddFortytwoLevel(0.8f);
                break;
            case 1:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "컨닝을 했다", "찔리지만 어쩔 수 없어", "...\n...\n부정행위를 걸려버렸다!");
                StartCoroutine(CheatingResult(5.0f, false));
                GameManager.instance.AddFriendship(-5);
                GameManager.instance.AddStress(10);
                break;
        }
        GameManager.instance.AddClean(-10);
        GameManager.instance.AddStress(10);
        GameManager.instance.AddSleep(20);
        GameManager.instance.AddEvalPoint(-2);
    }

    private IEnumerator CheatingResult(float seconds, bool value)
    {
        yield return new WaitForSeconds(seconds);

        if (value)
            studyUIManager.CheatingSuccess();
        else
            studyUIManager.CheatingFailed();
    }

    private IEnumerator RudeEval(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        studyUIManager.RudePeer();
    }
}
