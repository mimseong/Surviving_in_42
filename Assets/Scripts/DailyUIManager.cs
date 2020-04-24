using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DailyUIManager : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button studyButton;
    [SerializeField] private Button restButton;
    [SerializeField] private Button soloCodingButton;
    [SerializeField] private Button duoCodingButton;
    [SerializeField] private Button evaluateButton;
    [SerializeField] private Button evaluatedButton;
    [SerializeField] private Button cheatingButton;
    [SerializeField] private Button beerButton;
    [SerializeField] private Button sleepButton;
    [SerializeField] private Button goHomeButton;
    [SerializeField] private Button lazyButton;
    [SerializeField] private DialogController dialogController;
    [SerializeField] private Image terminal;
    [SerializeField] private DailyStory dailyStory;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveTerminal()
    {
        terminal.gameObject.SetActive(true);
        dailyStory.FirstMent(dialogController, ActiveButton);
    }

    public void BackButton(bool value)
    {
        backButton.gameObject.SetActive(value);
    }
    private void SelectButton(bool value)
    {
        studyButton.gameObject.SetActive(value);
        restButton.gameObject.SetActive(value);
    }

    private void ActiveButton()
    {
        SelectButton(true);
    }

    public void StudyButton(bool value)
    {
        soloCodingButton.gameObject.SetActive(value);
        duoCodingButton.gameObject.SetActive(value);
        evaluateButton.gameObject.SetActive(value);
        evaluatedButton.gameObject.SetActive(value);
        cheatingButton.gameObject.SetActive(value);
        SelectButton(!value);
        BackButton(value);
    }

    public void RestButton(bool value)
    {
        beerButton.gameObject.SetActive(value);
        sleepButton.gameObject.SetActive(value);
        goHomeButton.gameObject.SetActive(value);
        lazyButton.gameObject.SetActive(value);
        SelectButton(!value);
        BackButton(value);
    }

    public void GoBack()
    {
        StudyButton(false);
        RestButton(false);
    }

    public void DecideSelect(int index)
    {
        switch (index)
        {
            case 1:
                GameManager.instance.SetWork(Work.SOLO_CODING);
                break;
            case 2:
                GameManager.instance.SetWork(Work.DUO_CODING);
                break;
            case 3:
                GameManager.instance.SetWork(Work.EVALUATE);
                break;
            case 4:
                GameManager.instance.SetWork(Work.EVALUATED);
                break;
            case 5:
                GameManager.instance.SetWork(Work.CHEATING);
                break;
            case 6:
                GameManager.instance.SetWork(Work.DRINKING);
                break;
            case 7:
                GameManager.instance.SetWork(Work.SLEEP);
                break;
            case 8:
                GameManager.instance.SetWork(Work.GO_HOME);
                break;
            case 9:
                GameManager.instance.SetWork(Work.LAZY);
                break;
        }
        if (index >= 1 && index <= 4)
            SceneManager.LoadScene("StudyScene");
        else
            SceneManager.LoadScene("RestScene");
    }
}
