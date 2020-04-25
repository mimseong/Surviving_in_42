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

    private void Input()
    {
        registerUIManager.AppearInput();
    }

    /// <summary>
    /// 등록 장면에서 첫번째로 나오는 멘트
    /// </summary>
    /// <param name="dialogController"> 멘트 출력 스크립트 </param>
    public void FirstMent(DialogController dialogController)
    {
        dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, Input, "라피신 첫 날이다!", "두근두근", "등록하시겠어요?");
    }

    public void Registered(DialogController dialogController)
    {
        dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "등록되었습니다!");
    }
}
