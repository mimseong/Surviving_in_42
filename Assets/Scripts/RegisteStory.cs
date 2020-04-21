using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisteStory : MonoBehaviour, Story
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
        dialogController.ShowText("드디어 라피신이 시작되었다.", 0.5f, 0.02f);
        dialogController.ShowText("등록 과정 멘트 ...", 1.0f, 0.02f);
        dialogController.ShowText("이제 올라가서 원하는 자리 사용하시면 됩니다!", 1.0f, 0.02f);
    }
}
