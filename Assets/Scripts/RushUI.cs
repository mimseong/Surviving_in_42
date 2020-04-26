using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RushUI : MonoBehaviour
{
    [SerializeField] private Button nextButton;
    [SerializeField] private Image terminal;
    [SerializeField] private Image mento;
    [SerializeField] private Image timo;
    [SerializeField] private Image yasuo;
    [SerializeField] private Image unavailableTimo;
    [SerializeField] private Image unavailableYasuo;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Sprite[] mentoSprites;
    [SerializeField] private RushStory rushStory;
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

    public void NextButton(bool value)
    {
        nextButton.gameObject.SetActive(value);
    }

    public void RushProcess()
    {
        if (!GameManager.instance.GetisRush())
        {
            NextScene();
        }
        else
        {
            switch (countingButton)
            {
                case 0:
                    terminal.gameObject.SetActive(true);
                    rushStory.RushStart(dialogController, ActiveNextButton);
                    break;
                case 1:
                    ActiveImage();
                    rushStory.Timo(dialogController, ActiveNextButton);
                    break;
                case 2:
                    rushStory.Yasuo(dialogController, ActiveNextButton);
                    break;
                case 3:
                    rushStory.RushResult(dialogController, ActiveNextButton);
                    timo.gameObject.SetActive(false);
                    yasuo.gameObject.SetActive(false);
                    unavailableTimo.gameObject.SetActive(false);
                    unavailableYasuo.gameObject.SetActive(false);
                    RandomSetImage(mento, mentoSprites);
                    mento.gameObject.SetActive(true);
                    break;
                case 4:
                    NextScene();
                    break;
            }
        }
        NextButton(false);
    }

    public void ActiveTerminal()
    {
        terminal.gameObject.SetActive(true);
    }

    private void ActiveNextButton()
    {
        NextButton(true);
        countingButton++;
    }

    public void NextScene()
    {
        NextButton(false);
        SceneManager.LoadScene("DailyScene");
    }

    //랜덤이미지 넣기;
    private void RandomSetImage(Image target, Sprite[] sprites)
    {
        int index = Random.Range(0, sprites.Length);
       target.sprite = sprites[index];
    }

    public void ActiveImage()
    {
        RandomSetImage(timo, sprites);
        RandomSetImage(yasuo, sprites);
        timo.gameObject.SetActive(true);
        yasuo.gameObject.SetActive(true);
    }

    public void ActiveUnavailableTimo()
    {
        unavailableTimo.gameObject.SetActive(true);
    }

    public void ActiveUnavailableYasuo()
    {
        unavailableYasuo.gameObject.SetActive(true);
    }

    public void IsRegister()
    {
        rushStory.IsRegister(dialogController, ActiveNextButton);
    }
}
