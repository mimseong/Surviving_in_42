using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyStory : MonoBehaviour
{
    [SerializeField] private StudyUIManager studyUIManager;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    private void SoloCoding(DialogController dialogController)
    {
        dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "스스로 학습하기로 했다", "...\n...\n...", "열심히 코딩을 했다!", "코딩 레벨 += 1 \n스트레스 += 10");
        Invoke("NextButton", 0.5f);
    }

    private void DuoCoding(DialogController dialogController)
    {
        dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "동료와 함께 코딩학습을 했다", "...\n...\n...", "많은 것을 배웠다!", "코딩레벨 += 1 \n동료와의 관계 += 5 \n스트레스 += 10");
        Invoke("NextButton", 0.5f);
    }

    private void Evaluate(DialogController dialogController)
    {
        int situation = Random.Range(0, 5);
        switch (situation)
        {
            case 0:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "평가를 하러 갔다", "동료가 다른 층에 있었다", "계단을 이용해서 조금 건강해진 기분이다", "코딩레벨 += 0.5 \n동료와의 관계 += 5 \n스트레스 += 5");
                Invoke("NextButton", 10.0f);
                break;
            case 1:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "평가를 하러 갔다", "나보다 진도가 느린 사람을 만났다", "내가 배운 것을 알려주고 왔다", "뿌듯하다", "코딩레벨 += 0.5 \n동료와의 관계 += 5 \n스트레스 += 5");
                Invoke("NextButton", 10.0f);
                break;
            case 2:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "평가를 하러 갔다", "동료와 친해졌다", "꿀팁을 공유하고 왔다", "코딩레벨 += 0.5 \n동료와의 관계 += 5 \n스트레스 += 5");
                Invoke("NextButton", 10.0f);
                break;
            case 3:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "평가를 하러 갔다", "나보다 더 진도가 빠른 사람을 만났다", "조금 긴장됐지만 잘 가르쳐줘서 많은 것을 배웠다", "코딩레벨 += 0.5 \n동료와의 관계 += 5 \n스트레스 += 5");
                Invoke("NextButton", 10.0f);
                break;
            case 4:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "평가를 하러 갔다", "무례한 동료를 만났다", "너무 속상하다", "ㅂㄷㅂㄷ...", "스트레스 += 40");
                Invoke("NextButton", 10.0f);
                break;
        }
    }

    private void Evaluted(DialogController dialogController)
    {
        int situation = Random.Range(0, 5);
        switch (situation)
        {
            case 0:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "평가를 받았다", "버그가 없었으면 좋겠다", "두근두근", "...\n...\n...", "무사히 통과했다!", "42레벨 += 0.8 \n코딩레벨 += 0.5 \n동료와의 관계 += 5 \n스트레스 += 5");
                Invoke("NextButton", 10.0f);
                break;
            case 1:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "평가를 받았다", "norm 체크를 했던가?", "...\n...\n...", "다행히 통과했다!", "42레벨 += 0.8 \n코딩레벨 += 0.5 \n동료와의 관계 += 5 \n스트레스 += 5");
                Invoke("NextButton", 10.0f);
                break;
            case 2:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "평가를 받았다", "제발 한번에 통과했으면...", "...\n...\n...", "segmentation fault!", "코딩레벨 += 0.5 \n동료와의 관계 += 5 \n스트레스 += 10");
                Invoke("NextButton", 10.0f);
                break;
            case 3:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "평가를 받았다", "이번엔 제발 통과하자!", "...\n...\n...", "드디어 통과했다!", "42레벨 += 0.8 \n코딩레벨 += 0.5 \n동료와의 관계 += 5 \n스트레스 += 5");
                Invoke("NextButton", 10.0f);
                break;
            case 4:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "평가를 받았다", "이번엔 제발 통과하자!", "...\n...\n...", "segmentation fault가 또...", "코딩레벨 += 0.5 \n동료와의 관계 += 5 \n스트레스 += 10");
                Invoke("NextButton", 10.0f);
                break;
        }
    }

    private void Cheating(DialogController dialogController)
    {
        int situation = Random.Range(0, 2);
        switch (situation)
        {
            case 0:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "컨닝을 했다", "양심의 가책을 느낀다", "...\n...\n...", "다행스럽게도 무사히 통과했다!", "42레벨 += 0.8 \n코딩레벨 += 0");
                break;
            case 1:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "컨닝을 했다", "찔리지만 어쩔 수 없어", "...\n...\n...", "부정행위를 걸려버렸다!", "-42점을 받았다", "코딩레벨 += 0 \n동료와의 관계 -= 5 \n스트레스 += 10");
                break;
        }
    }
}
