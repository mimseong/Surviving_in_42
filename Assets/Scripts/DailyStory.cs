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
        //if (GameManager.instance.GetSchedule() == Schedule.MORNING)
        dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, fx, "상쾌한 아침이다!", "무엇을 할까?");
    }
}
