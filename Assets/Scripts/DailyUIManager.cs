using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
}
