using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyStory : MonoBehaviour, Story
{
    [SerializeField] private DailyUIManager uIManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FirstMent(DialogController dialogController)
    {
        //if (GameManager.instance.GetSchedule() == Schedule.MORNING)
        dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "상쾌한 아침이다!", "이번엔 뭘 할까?");
        Invoke("SelectButton", 3.0f);

    }

    private void SelectButton()
    {
        uIManager.SelectButton(true);
    }
}
