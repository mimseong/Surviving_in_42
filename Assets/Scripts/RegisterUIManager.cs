using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RegisterUIManager : MonoBehaviour
{
    [SerializeField] private Image terminal;
    [SerializeField] private InputField inputField;
    [SerializeField] private Button nextButton;
    [SerializeField] private RegisteStory registeStory;
    [SerializeField] private DialogController dialogController;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 터미널 이미지 활성화 및 Register 장면에 맞는 멘트 출력 함수 호출
    /// </summary>
    public void ActiveTerminal()
    {
        terminal.gameObject.SetActive(true);
        registeStory.FirstMent(dialogController);
    }

    public void NextButton(bool value)
    {
        nextButton.gameObject.SetActive(value);
    }

    public void RegisterStory()
    {
        registeStory.Registered(dialogController);
    }

    public void AppearInput()
    {
        inputField.gameObject.SetActive(true);
    }

    public void InputName()
    {
        if (inputField.text.Length <= 0)
            dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "이름을 입력해주세요!");
        else if (inputField.text.Length > 5)
        {
            dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "이름을 5자 이내로 입력해주세요!");
            inputField.text = "";
        }
        else
        {
            GameManager.instance.SetName(inputField.text);
            inputField.gameObject.SetActive(false);
            RegisterStory();
            NextButton(true);
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene("DailyScene");
    }
}
