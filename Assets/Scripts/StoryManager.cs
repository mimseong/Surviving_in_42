using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    [SerializeField] private DialogController dialogController;
    // Start is called before the first frame update
    void Start()
    {
        dialogController.ShowText("HAHA!", 1.0f, 0.02f);
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
