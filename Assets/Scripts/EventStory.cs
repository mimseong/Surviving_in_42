using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventStory : MonoBehaviour
{
    [SerializeField] private EventUI eventUI = null;
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
        eventUI.ActiveNextButton(true);
    }

    public void DecideEvent(DialogController dialogController, Surprise events)
    {
        switch (events)
        {
            case Surprise.REVERSE_COLOR:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "스크린 락을 걸지 않아서 색반전 당했다!", "도비가 왔다 간 것 같다!");
                break;
            case Surprise.EVAL_MISTAKE:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "평가할 때 실수하는 바람에 사람들 앞에서 주의사항을 큰소리로 공지해줘야 했다", "부끄럽다");
                break;
            case Surprise.CANDY:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "동료에게 사탕을 받았다!", "달달하다");
                GameManager.instance.AddCountSnack(1);
                GameManager.instance.AddStress(-5);
                break;
            case Surprise.MOUSE_PAD:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "마우스 패드를 받았다!", "이제 코딩이 좀 더 잘 되겠군!");
                GameManager.instance.AddStress(10);
                GameManager.instance.SetisMousePad(true);
                break;
            case Surprise.SQUAT:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "컴퓨터 근처에 텀블러를 놔뒀다가 적발됐다! \n벌칙으로 스쿼트를 합니다", "운동을 해서 건강해진 기분!");
                GameManager.instance.AddClean(-10);
                GameManager.instance.AddStress(10);
                GameManager.instance.AddSleep(20);
                break;
            case Surprise.CHOCOLATE:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "동료로부터 초콜릿을 받았다!", "당 떨어졌는데 잘 됐다!");
                GameManager.instance.AddStress(-10);
                GameManager.instance.AddSleep(-5);
                GameManager.instance.AddCountSnack(1);
                break;
            case Surprise.ENERGYBAR:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "동료로부터 에너지바를 받았다", "개발자의 필수품이지! \n밥 먹을 시간을 줄여서 코딩을 할 수 있겠다");
                GameManager.instance.AddCodingLevel(0.5f);
                GameManager.instance.AddStress(-15);
                GameManager.instance.AddCountSnack(1);
                break;
            case Surprise.PIZZA:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "학장님이 피자를 쏘셨다!", "그리고 학장님의 말씀이 있었습니다 \n...\n...유익한 시간이었다!");
                GameManager.instance.AddStress(-20);
                GameManager.instance.AddCountSnack(1);
                break;
        }
        GameManager.instance.NextSchedule(1);

    }
}
