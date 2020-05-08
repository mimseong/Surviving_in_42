using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestStory : MonoBehaviour
{
    [SerializeField] private RestUIManager restUIManager = null;
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
        GameManager.instance.AddCountGoHome(1);
        GameManager.instance.AddCountDrinking(1);
    }

    private void Sleep(DialogController dialogController)
    {
        dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "소파에서 조금 자기로 합니다", "...\n..zzzzZZZ");
        GameManager.instance.AddSleep(-30);
        GameManager.instance.AddStress(-10);
        GameManager.instance.AddClean(-15);
        GameManager.instance.NextSchedule(1);
    }

    private void GoHome(DialogController dialogController)
    {
        dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "이만 집에 가는 게 좋겠다!\n집으로 돌아갑니다");
        GameManager.instance.AddStress(-50);
        GameManager.instance.SetClean(100);
        GameManager.instance.SetSleep(0);
        GameManager.instance.NextSchedule(2);
        GameManager.instance.AddCountGoHome(1);
    }

    private void Lazy(DialogController dialogController)
    {
        string[][] multiText = new string[4][];
        string name = GameManager.instance.GetName();

        multiText[0] = new string[] { "동료들과 수다를 떨었다", name + " : 할게 너무 많아서 힘들어 \n미스포츈 : 그거 나는 다 맞았는데 \n" + name + " : ..." };
        multiText[1] = new string[] { "동료들과 장난쳤다", "누누 : 기침은 Calloc Calloc! \n" + name +" : 하하하! 너무 웃겨! \n윌럼프 : 또 시작이군" };
        multiText[2] = new string[] { "동료들과 빈둥댔다", name + " : 요 앞에 고깃집 맛있던데 \n아무무 : 다음에 먹으러 가자! \n말파이트 : 넌 누구야? \n아무무: 흑흑..." };
        multiText[3] = new string[] { "동료들과 노닥거렸다", name + " : 이건 뭐지? \n카이사 : yeah it's merge \n지나가던 제드 : ......" };

        dialogController.ShowRandomTexts(0.5f, 0.5f, 0.02f, 0.5f, NextButton, multiText);
        
        GameManager.instance.AddStress(-30);
        GameManager.instance.NextSchedule(1);
        GameManager.instance.AddSleep(10);
        GameManager.instance.AddClean(-15);
        GameManager.instance.AddFriendship(5);
    }
}
