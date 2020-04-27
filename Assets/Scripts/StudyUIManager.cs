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

    private void ActiveTerminal()
    {
        terminal.gameObject.SetActive(true);
        studyStory.DecideStudy(dialogController, GameManager.instance.GetWork());
    }

    public void NextButton(bool value)
    {
        nextButton.gameObject.SetActive(value);
    }

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
                if (GameManager.instance.GetWeek() != 1)
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

    private void RandomSetImage(Image target, Sprite[] sprites)
    {
        int index = Random.Range(0, sprites.Length);
        if (sprites.Length != 0)
            target.sprite = sprites[index];
    }

    public void CheatingSuccess()
    {
        cheatingSuccess.gameObject.SetActive(true);
    }

    public void CheatingFailed()
    {
        RandomSetImage(cheatingFailed, cheatSprites);
        cheatingFailed.gameObject.SetActive(true);
    }

    public void RudePeer()
    {
        evaluate.gameObject.SetActive(true);
        evaluate.sprite = evalRude;
    }

    public void NextScene()
    {
        NextButton(false);
        SceneManager.LoadScene("DailyScene");
    }

    public void Elevator()
    {
        background.sprite = backgroundSprites[1];
        background.gameObject.SetActive(true);
        elevator.gameObject.SetActive(true);
    }
}
