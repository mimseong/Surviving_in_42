using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestUIManager : MonoBehaviour
{
    [SerializeField] private Image beer;
    [SerializeField] private Image sleep1;
    [SerializeField] private Image sleep2;
    [SerializeField] private Image sleep3;
    [SerializeField] private Image goHome;
    [SerializeField] private Image lazy;
    [SerializeField] private Image background;
    [SerializeField] private Button nextButton;
    [SerializeField] private Image terminal;
    [SerializeField] private RestStory restStory;
    [SerializeField] private DialogController dialogController;
    [SerializeField] private Sprite[] drinking;
    [SerializeField] private Sprite[] goHomeSprites;
    [SerializeField] private Sprite[] backgroundSprites;
    

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

    public void NextButton(bool value)
    {
        nextButton.gameObject.SetActive(value);
    }

    public void ActiveImage()
    {
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

    public void NextScene()
    {
        NextButton(false);
        SceneManager.LoadScene("DailyScene");
    }
}
