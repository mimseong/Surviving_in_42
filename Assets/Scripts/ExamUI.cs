using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExamUI : MonoBehaviour
{
    [SerializeField] private Button nextButton;
    [SerializeField] private Image terminal;
    [SerializeField] private Image background;
    [SerializeField] private Sprite[] sprite;
    [SerializeField] private ExamStory examStory;
    [SerializeField] private DialogController dialogController;

    void Start()
    {
        ChangeBackground();
    }

    void Update()
    {
        
    }

    public void NextButton(bool value)
    {
        nextButton.gameObject.SetActive(value);
    }

    public void ActiveTerminal()
    {
        terminal.gameObject.SetActive(true);
        examStory.ExamResult(dialogController, ActiveNextButton);
    }

    private void ActiveNextButton()
    {
        NextButton(true);
    }

    public void NextScene()
    {
        NextButton(false);
        if (GameManager.instance.GetWeek() == 1)
        {
            GameManager.instance.SetEvent(Suprise.MOUSE_PAD);
            SceneManager.LoadScene("EventScene");
        }
        else if (GameManager.instance.GetWeek() == 4)
            SceneManager.LoadScene("EndingScene");
        else
            SceneManager.LoadScene("RushScene");
    }

    public void ChangeBackground()
    {
        switch (GameManager.instance.GetWeek())
        {
            case 1:
                background.sprite = sprite[0];
                break;
            case 2:
                background.sprite = sprite[1];
                break;
            case 3:
                background.sprite = sprite[2];
                break;
            case 4:
                background.sprite = sprite[3];
                break;
        }
    }
}
