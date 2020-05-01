using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisteStory : MonoBehaviour
{
    [SerializeField] private RegisterUIManager registerUIManager;
    

    void Start()
    {
        Invoke("ActiveTerminal", 1.2f);
    }

    void Update()
    {
        
    }

    public void ActiveTerminal()
    {
        registerUIManager.ActiveTerminal();
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
        dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, Input, "두근두근.. \n라피신 첫 날이다!", "등록하시겠어요?");
    }

    public void Registered(DialogController dialogController)
    {
        if (GameManager.instance.GetName().ToLower() == "dobby" || GameManager.instance.GetName().ToLower() == "doby" || GameManager.instance.GetName() == "도비")
            dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "DOBBY IS FREE!!!");
        else
            dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "등록되었습니다!");
    }
}
