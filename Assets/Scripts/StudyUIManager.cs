using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StudyUIManager : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private Image soloCoding;
    [SerializeField] private Image duoCoding;
    [SerializeField] private Image elevator;
    [SerializeField] private Image evaluate;
    [SerializeField] private Image evaluated;
    [SerializeField] private Image cheatingSuccess;
    [SerializeField] private Image cheatingFailed;
    [SerializeField] private GameObject cheating;
    [SerializeField] private Sprite[] backgroundSprites;
    [SerializeField] private Sprite[] cheatSprites;
    [SerializeField] private Sprite[] solosSprites;
    [SerializeField] private Sprite[] duoSprites;
    [SerializeField] private Sprite[] evalSprites;
    [SerializeField] private Sprite[] evedSprites;
    [SerializeField] private Sprite evalRude;
    [SerializeField] private Image terminal;
    [SerializeField] private Button nextButton;
    [SerializeField] private StudyStory studyStory;
    [SerializeField] private DialogController dialogController;
    private int countingButton = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 터미널 활성화하는 함수입니다. 터미널이 켜지면서 스터디 스토리가 진행됩니다
    /// </summary>
    private void ActiveTerminal()
    {
        terminal.gameObject.SetActive(true);
        studyStory.DecideStudy(dialogController, GameManager.instance.GetWork());
    }

    /// <summary>
    /// 버튼 활성화하는 함수
    /// </summary>
    /// <param name="value">value 값에 따라 활성화 비활성화 결정</param>
    public void NextButton(bool value)
    {
        nextButton.gameObject.SetActive(value);
    }

    /// <summary>
    /// 스케쥴에 따라 이미지를 활성화하는 함수
    /// </summary>
    public void ActiveImage()
    {
        Work tmp = GameManager.instance.GetWork();
        switch (tmp)
        {
            case Work.SOLO_CODING:
                RandomSetImage(soloCoding, solosSprites);
                soloCoding.gameObject.SetActive(true);
                break;
            case Work.DUO_CODING:
                RandomSetImage(duoCoding, duoSprites);
                duoCoding.gameObject.SetActive(true);
                break;
            case Work.EVALUATE:
                if (!(GameManager.instance.GetWeek() == 1 && (GameManager.instance.GetDay() == Day.TUE || GameManager.instance.GetDay() == Day.WED)))
                {
                    RandomSetImage(evaluate, evalSprites);
                    evaluate.gameObject.SetActive(true);
                }
                break;
            case Work.EVALUATED:
                RandomSetImage(evaluated, evedSprites);
                evaluated.gameObject.SetActive(true);
                break;
            case Work.CHEATING:
                cheating.gameObject.SetActive(true);
                break;
        }
        if (tmp == Work.SOLO_CODING || tmp == Work.DUO_CODING || tmp == Work.EVALUATE || tmp == Work.EVALUATED || tmp == Work.CHEATING)
            Invoke("ActiveTerminal", 1.2f);
    }


    /// <summary>
    /// 이미지를 랜덤으로 정해주는 함수
    /// </summary>
    /// <param name="target">이미지</param>
    /// <param name="sprites">랜덤이미지</param>
    private void RandomSetImage(Image target, Sprite[] sprites)
    {
        int index = Random.Range(0, sprites.Length);
        if (sprites.Length != 0)
            target.sprite = sprites[index];
    }

    /// <summary>
    /// 치팅 성공 시 나타나는 이미지 함수
    /// </summary>
    public void CheatingSuccess()
    {
        cheatingSuccess.gameObject.SetActive(true);
    }

    /// <summary>
    /// 치팅 실패 시 나타나는 이미지 함수
    /// </summary>
    public void CheatingFailed()
    {
        RandomSetImage(cheatingFailed, cheatSprites);
        cheatingFailed.gameObject.SetActive(true);
    }

    /// <summary>
    /// 무례한 동료를 만났을 시 나타나는 이미지 함수
    /// </summary>
    public void RudePeer()
    {
        evaluate.gameObject.SetActive(true);
        evaluate.sprite = evalRude;
    }

    /// <summary>
    /// 다음 씬으로 넘어가는 함수
    /// </summary>
    public void NextScene()
    {
        NextButton(false);
        SceneManager.LoadScene("DailyScene");
    }

    /// <summary>
    /// 엘레베이터 고장을 나타내는 함수
    /// </summary>
    public void Elevator()
    {
        background.sprite = backgroundSprites[1];
        background.gameObject.SetActive(true);
        elevator.gameObject.SetActive(true);
    }
}
