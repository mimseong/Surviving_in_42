using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestStory : MonoBehaviour
{
    [SerializeField] private RestUIManager restUIManager;
    // Start is called before the first frame update
    void Start()
    {
        restUIManager.ActiveImage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 선택지에 따라 어떤 스케쥴을 실행할지 결정하는 함수
    /// </summary>
    /// <param name="dialogController">대사를 출력하는 스크립트</param>
    /// <param name="work">할일</param>
    public void DecideRest(DialogController dialogController, Work work)
    {
        GameManager.instance.SetWork(work);
        switch (work)
        {
            case Work.DRINKING:
                Beer(dialogController);
                break;
            case Work.SLEEP:
                Sleep(dialogController);
                break;
            case Work.GO_HOME:
                GoHome(dialogController);
                break;
            case Work.LAZY:
                Lazy(dialogController);
                break;
        }
    }

    private void NextButton()
    {
        restUIManager.NextButton(true);
    }

    private void Beer(DialogController dialogController)
    {
        dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "언제까지 어깨춤을 추게 할거야~\n동료들과 함께 술을 마셨다\n...\n만취해서 집에 갑니다");
        GameManager.instance.AddFriendship(10);
        GameManager.instance.AddStress(-60);
        GameManager.instance.SetClean(100);
        GameManager.instance.SetSleep(0);
        GameManager.instance.NextSchedule(2);
    }

    private void Sleep(DialogController dialogController)
    {
        dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "소파에서 조금 자기로 합니다", "...\n..zzzzZZZ");
        GameManager.instance.AddSleep(-30);
        GameManager.instance.AddStress(-10);
        GameManager.instance.NextSchedule(1);
    }

    private void GoHome(DialogController dialogController)
    {
        dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "이만 집에 가는 게 좋겠다!\n집으로 돌아갑니다");
        GameManager.instance.AddStress(-50);
        GameManager.instance.SetClean(100);
        GameManager.instance.SetSleep(0);
        GameManager.instance.NextSchedule(2);
    }

    private void Lazy(DialogController dialogController)
    {
        int situation = Random.Range(0, 5);
        switch (situation)
        {
            case 0:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "도비와 함께 춤을!", "도비와 사진 찍고 놀았다");
                break;
            case 1:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "동료들과 수다를 떨었다", "동료A : 할게 너무 많아서 힘들어 \n동료B : 그거 나는 다 맞았는데 \n동료들 : ...");
                break;
            case 2:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "유튜브 알고리즘을 따라 게임방송까지 흘러갔다", "시간이 순삭됐다");
                break;
            case 3:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "멍하니 검은 창을 바라보았다", "...\n...\n...\n아무것도 안했는데 시간이 왜이리 잘가지?");
                break;
            case 4:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "동료들과 노닥거렸다", "동료A : 기침은 Calloc Calloc! \n동료들 : 하하하! 너무 웃겨! \n동료B : 또 시작이군");
                break;
        }
        GameManager.instance.AddStress(-5);
        GameManager.instance.NextSchedule(1);
        GameManager.instance.AddSleep(10);
        GameManager.instance.AddClean(-10);
    }
}
