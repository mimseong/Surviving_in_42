using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingStory : MonoBehaviour
{
    [SerializeField] private EndingUI endingUI;

    void Start()
    {
        endingUI.StartMent();
    }

    public void FirstMent(DialogController dialogController, ConvertMethod func)
    {
        string text;

        text = "드디어 최종시험이 끝났다!\n\n4주간의 과정이 모두 끝이났다.\n\n힘든 일도 많았고 즐거운 일도 많았지\n\n좋은 경험이었던 것 같다..";
        dialogController.ShowTexts(0.5f, 1.5f, 0.1f, 0.5f, func, text);
    }

    public void SecondMent(DialogController dialogController, ConvertMethod func)
    {
        string[] texts = new string[3];

        texts[0] = "띠링~";
        texts[1] = "42서울 결과 메일이 온 것 같다!";
        texts[2] = "42 SEOUL / 본 과정 교육생 최종 선발 결과";
        dialogController.ShowTexts(0.5f, 1.5f, 0.08f, 0.5f, func, texts);
    }

    public void ThirdMent(DialogController dialogController, ConvertMethod func)
    {
        string text;

        text = "42는 눈에 보이는 요소로만 여러분을 평가하지 않습니다.\n\n 그래도 결과가 궁금하시다고요?\n\n직접 경험하십시오";
        dialogController.ShowTexts(0.5f, 1.5f, 0.05f, 0.5f, func, text);
    }
}
