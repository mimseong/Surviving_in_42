using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyStory : MonoBehaviour
{
    [SerializeField] private DailyUIManager uIManager;
    // Start is called before the first frame update
    void Start()
    {
        uIManager.ActiveTerminal();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FirstMent(DialogController dialogController, ConvertMethod fx)
    {
        switch (GameManager.instance.GetSchedule())
        {
            case Schedule.MORNING:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, fx, "상쾌한 아침이다!", "무엇을 할까?");
                break;
            case Schedule.AFTERNOON:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, fx, "점심을 먹고 나니 잠이 쏟아진다...", "무엇을 할까?");
                break;
            case Schedule.NIGHT:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, fx, "한 것도 없는데 벌써 저녁이다!", "무엇을 할까?");
                break;
            case Schedule.DAWN:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, fx, "고요한 새벽이다..", "무엇을 할까?");
                break;
        }
    }
}
