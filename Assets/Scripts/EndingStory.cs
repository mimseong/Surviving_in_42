using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingStory : MonoBehaviour
{
    [SerializeField] private EndingUI endingUI = null;

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
        string[] texts = new string[2];

        texts[0] = "띠링~";
        texts[1] = "결과 메일이 온 것 같다!";
        dialogController.ShowTexts(0.5f, 1.5f, 0.08f, 0.5f, func, texts);
    }

    public void ThirdMent(DialogController dialogController, ConvertMethod func)
    {
        string text;

        text = GameManager.instance.GetCountSoloCoding().ToString() + "\n";
        text += GameManager.instance.GetCountDuoCoding().ToString() + "\n";
        text += GameManager.instance.GetCountGoHome().ToString() + "\n";
        text += GameManager.instance.GetCountCheating().ToString() + "\n";
        text += GameManager.instance.GetCountDrinking().ToString() + "\n";
        text += GameManager.instance.GetCountSnack().ToString() + "\n";
        text += GameManager.instance.GetEvalPoint().ToString() + "\n";
        text += GameManager.instance.GetCountLazy().ToString() + "\n";
        text += GameManager.instance.GetCodingLevel().ToString() +"\n";
        text += ((int)GameManager.instance.GetFortytwoLevel()).ToString();
        dialogController.ShowTexts(0.5f, 1.0f, 0.1f, 3f, func, text);
    }
}
