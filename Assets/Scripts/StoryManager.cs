using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    [SerializeField] private DialogController dialogController;
    private Story nowStory;

    void Start()
    {
        nowStory = GameObject.Find("Story").GetComponent<Story>();
        //dialogController.ShowText("HAHA!", 1.0f, 0.02f);
        nowStory.FirstMent(dialogController);
    }

    public void PushButton()
    {
        Debug.Log("why not");
        dialogController.ShowText("스트레스 +50", 0.5f, 0.02f);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
