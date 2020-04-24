using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudyUIManager : MonoBehaviour
{
    [SerializeField] private Image soloCoding;
    [SerializeField] private Image duoCoding;
    [SerializeField] private Image evaluate;
    [SerializeField] private Image evaluated;
    [SerializeField] private Image cheating;
    [SerializeField] private Sprite[] solosSprites;
    [SerializeField] private Sprite[] duoSprites;
    [SerializeField] private Sprite[] evalSprites;
    [SerializeField] private Sprite[] evedSprites;
    [SerializeField] private Image terminal;
    [SerializeField] private Button nextButton;
    [SerializeField] private StudyStory studyStory;
    [SerializeField] private DialogController dialogController;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.SetWork(Work.DUO_CODING);
        ActiveImage();
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

    private void NextButton(bool value)
    {
        nextButton.gameObject.SetActive(value);
    }

    private void ActiveImage()
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
                RandomSetImage(evaluate, evalSprites);
                evaluate.gameObject.SetActive(true);
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
        if (index != 0)
            target.sprite = sprites[index];
    }
}
