using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestUIManager : MonoBehaviour
{
    [SerializeField] private Image beer = null;
    [SerializeField] private Image sleep1 = null;
    [SerializeField] private Image sleep2 = null;
    [SerializeField] private Image sleep3 = null;
    [SerializeField] private Image goHome = null;
    [SerializeField] private Image lazy = null;
    [SerializeField] private Image background = null;
    [SerializeField] private Button nextButton = null;
    [SerializeField] private Image terminal = null;
    [SerializeField] private RestStory restStory = null;
    [SerializeField] private DialogController dialogController = null;
    [SerializeField] private Sprite[] drinking = null;
    [SerializeField] private Sprite[] goHomeSprites = null;
    [SerializeField] private Sprite[] backgroundSprites = null;
    [SerializeField] private Sprite[] lazySprites = null;


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
        restStory.DecideRest(dialogController, GameManager.instance.GetWork());
    }

    /// <summary>
    /// 다음 버튼을 활성화시키는 함수
    /// </summary>
    /// <param name="value"></param>
    public void NextButton(bool value)
    {
        nextButton.gameObject.SetActive(value);
    }

    /// <summary>
    /// 스케쥴에 따라 이미지 활성화시키는 함수
    /// </summary>
    public void ActiveImage()
    {
        int idx = Random.Range(0, lazySprites.Length);

        Work tmp = GameManager.instance.GetWork();
        switch (tmp)
        {
            case Work.DRINKING:
                background.sprite = backgroundSprites[0];
                RandomSetImage(beer, drinking);
                beer.gameObject.SetActive(true);
                break;
            case Work.SLEEP:
                RandomSleepBG(background, backgroundSprites);
                break;
            case Work.GO_HOME:
                if (GameManager.instance.GetSchedule() == Schedule.NIGHT)
                {
                    background.sprite = backgroundSprites[2];
                    goHome.sprite = goHomeSprites[1];
                }
                else
                {
                    background.sprite = backgroundSprites[1];
                    goHome.sprite = goHomeSprites[0];
                }
                goHome.gameObject.SetActive(true);
                break;
            case Work.LAZY:
                lazy.gameObject.SetActive(true);
                lazy.sprite = lazySprites[idx];
                background.sprite = backgroundSprites[5];
                break;
        }
        if (tmp == Work.DRINKING || tmp == Work.SLEEP || tmp == Work.GO_HOME || tmp == Work.LAZY)
            Invoke("ActiveTerminal", 1.2f);
    }

    private void RandomSetImage(Image target, Sprite[] sprites)
    {
        int index = Random.Range(0, sprites.Length);
        if (sprites.Length != 0)
            target.sprite = sprites[index];
    }

    private void RandomSleepBG(Image target, Sprite[] sprites)
    {
        int index = Random.Range(3, 5);
        if (sprites.Length != 0)
            target.sprite = sprites[index];
        if (index == 3)
            sleep3.gameObject.SetActive(true);
        else if (index == 4)
        {
            index = Random.Range(0, 2);
            if (index == 0)
                sleep1.gameObject.SetActive(true);
            else
                sleep2.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// 다음 씬으로 넘어가는 함수
    /// </summary>
    public void NextScene()
    {
        NextButton(false);
        SceneManager.LoadScene("DailyScene");
    }
}
