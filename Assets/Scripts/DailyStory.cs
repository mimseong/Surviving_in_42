using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyStory : MonoBehaviour, Story
{
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
        dialogController.ShowText("상쾌한 아침이다.", 0.5f, 0.02f);
        dialogController.ShowText("이번엔 뭘할까?", 1.0f, 0.02f);
    }
}
