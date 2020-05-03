using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventStory : MonoBehaviour
{
    [SerializeField] private EventUI eventUI;
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

    public void DecideEvent(DialogController dialogController, Suprise events)
    {
        switch (events)
        {
            case Suprise.REVERSE_COLOR:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "스크린 락을 걸지 않아서 색반전 당했다!", "도비가 왔다 간 것 같다!");
                break;
            case Suprise.CANDY:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "동료에게 사탕을 받았다!", "달달하다");
                GameManager.instance.AddStress(-5);
                break;
            case Suprise.MOUSE_PAD:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "마우스 패드를 받았다!", "이제 코딩이 좀 더 잘 되겠군!");
                GameManager.instance.AddStress(10);
                GameManager.instance.SetisMousePad(true);
                break;
            case Suprise.SQUAT:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "컴퓨터 근처에 텀블러를 놔뒀다가 적발됐다! \n벌칙으로 스쿼트를 합니다", "운동을 해서 건강해진 기분!");
                GameManager.instance.AddClean(-10);
                GameManager.instance.AddStress(10);
                GameManager.instance.AddSleep(20);
                break;
            case Suprise.CHOCOLATE:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "동료로부터 초콜릿을 받았다!", "당 떨어졌는데 잘 됐다!");
                GameManager.instance.AddStress(-10);
                GameManager.instance.AddSleep(-5);
                break;
            case Suprise.ENERGYBAR:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "동료로부터 에너지바를 받았다", "개발자의 필수품이지! \n밥 먹을 시간을 줄여서 코딩을 할 수 있겠다");
                GameManager.instance.AddCodingLevel(0.5f);
                GameManager.instance.AddStress(-15);
                break;
            case Suprise.PIZZA:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, NextButton, "학장님이 피자를 쏘셨다!", "너무너무 행복해!");
                GameManager.instance.AddStress(-20);
                break;
        }
        GameManager.instance.NextSchedule(1);

    }
}
