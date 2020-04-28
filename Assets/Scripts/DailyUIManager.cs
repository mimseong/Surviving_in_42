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
    [SerializeField] private Button registerButton;
    [SerializeField] private DialogController dialogController;
    [SerializeField] private Image terminal;
    [SerializeField] private DailyStory dailyStory;
    [SerializeField] private StatusManager status;

    // Start is called before the first frame update
    void Start()
    {
        status.ShowStatus();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 터미널을 켜고 daily story script에 있는 firstment 함수를 실행시키는 함수
    /// </summary>

    public void ActiveTerminal()
    {
        terminal.gameObject.SetActive(true);
        dailyStory.FirstMent(dialogController, ActiveButton);
    }

    /// <summary>
    /// 뒤로가기 버튼 활성화
    /// </summary>
    /// <param name="value"></param>
    public void BackButton(bool value)
    {
        backButton.gameObject.SetActive(value);
    }
    private void SelectButton(bool value)
    {
        studyButton.gameObject.SetActive(value);
        restButton.gameObject.SetActive(value);
        ActiveRegisterButton();
    }

    private void ActiveButton()
    {
        SelectButton(true);
    }

    /// <summary>
    /// 등록버튼 활성화하는 함수
    /// </summary>
    public void ActiveRegisterButton()
    {
        if (GameManager.instance.GetWeek() != 4)
        {
            switch (GameManager.instance.GetDay())
            {
                case Day.WED:
                    if (!GameManager.instance.GetisExam())
                    {
                        registerButton.gameObject.SetActive(true);
                        registerButton.transform.GetChild(0).GetComponent<Text>().text = "EXAM 등록";
                    }
                    break;
                case Day.THU:
                    if (!GameManager.instance.GetisRush())
                    {
                        registerButton.gameObject.SetActive(true);
                        registerButton.transform.GetChild(0).GetComponent<Text>().text = "RUSH 등록";
                    }
                    break;
            }
        }
    }

    /// <summary>
    /// 각 주차에 따라 등록결과를 저장
    /// </summary>
    public void WhenRegister()
    {
        if (GameManager.instance.GetWeek() != 4)
        {
            switch (GameManager.instance.GetDay())
            {
                case Day.WED:
                    GameManager.instance.SetisExam(true);
                    break;
                case Day.THU:
                    GameManager.instance.SetisRush(true);
                    break;
            }
            registerButton.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// 스터디 버튼을 누르면 나타나는 일
    /// </summary>
    /// <param name="value"></param>
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

    /// <summary>
    /// 휴식버튼을 누르면 나타나는 일
    /// </summary>
    /// <param name="value"></param>
    public void RestButton(bool value)
    {
        beerButton.gameObject.SetActive(value);
        sleepButton.gameObject.SetActive(value);
        goHomeButton.gameObject.SetActive(value);
        lazyButton.gameObject.SetActive(value);
        SelectButton(!value);
        BackButton(value);
    }

    /// <summary>
    /// 뒤로가기
    /// </summary>
    public void GoBack()
    {
        StudyButton(false);
        RestButton(false);
    }

    /// <summary>
    /// 버튼에 따라서 어떤 스케쥴을 진행할지 결정
    /// </summary>
    /// <param name="index"></param>
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
        if (index >= 1 && index <= 5)
            SceneManager.LoadScene("StudyScene");
        else
            SceneManager.LoadScene("RestScene");
    }
}
