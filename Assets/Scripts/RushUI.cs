using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RushUI : MonoBehaviour
{
    [SerializeField] private Button nextButton = null;
    [SerializeField] private Image terminal = null;
    [SerializeField] private Image mento = null;
    [SerializeField] private Image timo = null;
    [SerializeField] private Image yasuo = null;
    [SerializeField] private Image unavailableTimo = null;
    [SerializeField] private Image unavailableYasuo = null;
    [SerializeField] private Sprite[] sprites = null;
    [SerializeField] private Sprite[] mentoSprites = null;
    [SerializeField] private RushStory rushStory = null;
    [SerializeField] private DialogController dialogController = null;
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

    /// <summary>
    /// 러시 등록 여부에 따라, 버튼을 누를 때마다 러시가 진행되도록 하는 함수입니다
    /// </summary>
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

    /// <summary>
    /// 터미널을 켜는 함수
    /// </summary>
    public void ActiveTerminal()
    {
        terminal.gameObject.SetActive(true);
    }


    /// <summary>
    /// 넥스트 버튼 켜는 함수
    /// </summary>
    private void ActiveNextButton()
    {
        NextButton(true);
        countingButton++;
    }


    /// <summary>
    /// 데일리 씬으로 넘어가는 함수
    /// </summary>
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

    /// <summary>
    /// 티모와 야스오 이미지를 넣는 함수
    /// </summary>
    public void ActiveImage()
    {
        RandomSetImage(timo, sprites);
        RandomSetImage(yasuo, sprites);
        timo.gameObject.SetActive(true);
        yasuo.gameObject.SetActive(true);
    }


    /// <summary>
    /// 티모 도망간 이미지 나타내는 함수
    /// </summary>
    public void ActiveUnavailableTimo()
    {
        unavailableTimo.gameObject.SetActive(true);
    }

    /// <summary>
    /// 야스오 도망간 이미지 나타내는 함수
    /// </summary>
    public void ActiveUnavailableYasuo()
    {
        unavailableYasuo.gameObject.SetActive(true);
    }

    public void IsRegister()
    {
        rushStory.IsRegister(dialogController, ActiveNextButton);
    }
}
