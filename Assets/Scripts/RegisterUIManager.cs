using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RegisterUIManager : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    [SerializeField] private RegisteStory registeStory;
    [SerializeField] private Button nextButton;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextButton(bool value)
    {
        nextButton.gameObject.SetActive(value);
    }

    public void RegisterStory()
    {
        registeStory.Registered();
    }

    public void AppearInput()
    {
        inputField.gameObject.SetActive(true);
    }
    public void InputName()
    {
        GameManager.instance.SetName(inputField.text);
        inputField.gameObject.SetActive(false);
        RegisterStory();
        NextButton(true);
    }

    public void NextScene()
    {
        SceneManager.LoadScene("DailyScene");
    }
}
