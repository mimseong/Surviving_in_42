using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisteStory : MonoBehaviour, Story
{
    [SerializeField] private RegisterUIManager registerUIManager;
    [SerializeField] private DialogController dialogController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Input()
    {
        registerUIManager.AppearInput();
    }

    public void FirstMent(DialogController dialogController)
    {
        dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "라피신 첫 날이다!", "두근두근", "등록하시겠어요?");
        Invoke("Input", 5.0f);
    }

    public void Registered()
    {
        dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "등록되었습니다!");
    }
}
