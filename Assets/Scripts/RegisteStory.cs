using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisteStory : MonoBehaviour
{
    [SerializeField] private RegisterUIManager registerUIManager;
    

    void Start()
    {
        registerUIManager.ActiveTerminal();
    }

    void Update()
    {
        
    }

    public void Input()
    {
        registerUIManager.AppearInput();
    }

    public void FirstMent(DialogController dialogController)
    {
        dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, Input, "라피신 첫 날이다!", "두근두근", "등록하시겠어요?");
    }

    public void Registered(DialogController dialogController)
    {
        dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "등록되었습니다!");
    }
}
