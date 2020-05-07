using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 팀원1 = 티모
/// 팀원2 = 야스오
/// </summary>

public class RushStory : MonoBehaviour
{
    private float timoCodingLv = 0;
    private float yasuoCodingLv = 0;
    private int timoMental = 0;
    private int yasuoMental = 0;
    [SerializeField] private RushUI rushUI;

    // Start is called before the first frame update
    void Start()
    {
        rushUI.IsRegister();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 각 주차에 따라 러시 결과를 나타내는 함수
    /// </summary>
    /// <param name="dialogController">대사를 출력하는 스크립트</param>
    /// <param name="nextButton">넥스트 버튼을 나타내는 함수</param>
    public void RushResult(DialogController dialogController, ConvertMethod nextButton)
    {
        float sum;
        float score = 0;
        string scoreTxt;

        sum = timoCodingLv + yasuoCodingLv + GameManager.instance.GetCodingLevel();

        switch (GameManager.instance.GetWeek())
        {
            case 1:
                score = sum / 3 / 12 * 100;
                break;
            case 2:
                score = sum / 3 / 24 * 100;
                break;
            case 3:
                score = sum / 3 / 36 * 100;
                break;
            case 4:
                score = sum / 3 / 42 * 100;
                break;
        }
        scoreTxt = "최종 점수는 \n...\n...\n" + (int)score + "점 입니다";

        if (score < 50)
        {
            //fail;
            dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, nextButton, "멘토에게 평가를 받습니다", "멘토 : 이 코드를 설명해 보시겠어요? \n 멘토(은)는 기습공격을 시전했다!\n...\n...\n...", scoreTxt, "Rush Failed !!! \n집으로 돌아갑니다");
            GameManager.instance.AddCodingLevel(2);
            GameManager.instance.AddFriendship(5);
            GameManager.instance.AddStress(20);
        }
        else
        {
            //pass;
            dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, nextButton, "멘토에게 평가를 받습니다", "멘토 : 이 코드를 설명해 보시겠어요?\n멘토(은)는 기습공격을 시전했다!\n...\n...\n...", scoreTxt, "러시를 무사히 마치고 집으로 돌아갑니다");
            GameManager.instance.AddFortytwoLevel(1);
            GameManager.instance.AddCodingLevel(3);
            GameManager.instance.AddFriendship(10);
            GameManager.instance.AddStress(5);
        }
        GameManager.instance.AddStress(-50);
        GameManager.instance.SetClean(100);
        GameManager.instance.SetSleep(0);
        GameManager.instance.NextDay(1);
        GameManager.instance.AddCountGoHome(1);
        GameManager.instance.NextDaySchedule(Schedule.MORNING);
    }

    /// <summary>
    /// 러시 시작하는 함수
    /// </summary>
    /// <param name="dialogController">대사를 출력하는 스크립트</param>
    /// <param name="nextButton">넥스트 버튼을 나타내는 함수</param>
    public void RushStart(DialogController dialogController, ConvertMethod nextButton)
    {
        dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, nextButton, "러시를 시작합니다!", "랜덤으로 팀원이 배정되었습니다");
    }

    /// <summary>
    /// 팀원1을 소개하는 함수입니다. 티모 멘탈을 랜덤으로 정해서 멘탈이 구리면 집으로 튀게 만듭니다.
    /// </summary>
    /// <param name="dialogController">대사를 출력하는 스크립트</param>
    /// <param name="nextButton">넥스트 버튼을 나타내는 함수</param>
    public void Timo(DialogController dialogController, ConvertMethod nextButton)
    {
        string[] texts = new string[4];
        string[] names = { "티모", "케이틀린", "럭스" };
        int idx = Random.Range(0, 3);

        timoCodingLv = RandomCodingLv();
        timoMental = Random.Range(25, 101);
        texts[0] = "안녕하세요 " + names[idx] + "입니다 \n잘 부탁드려요!";
        texts[1] = names[idx] + "의 코딩레벨 == " + (int)timoCodingLv + "\n" + names[idx] + "의 멘탈 == " + timoMental;
        texts[2] = names[idx] + ": 도저히 못하겠어 난 집에 갈래!";
        texts[3] = "앗\n" + names[idx] + "가 멘탈이 안좋아 집으로 가버렸습니다!";
        dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, nextButton, texts[0], texts[1]);
        
        if (timoMental < Random.Range(0, 101))
        {
            //timoRun;
            dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, nextButton, texts);
            timoCodingLv = 0;
            Invoke("NoTimo", 5.0f);
        }
    }

    /// <summary>
    /// 팀원2를 소개하는 함수입니다. 야스오 멘탈이 랜덤으로 정해지고 그에 따라 랜덤확률로 집으로 튑니다
    /// </summary>
    /// <param name="dialogController"></param>
    /// <param name="nextButton"></param>
    public void Yasuo(DialogController dialogController, ConvertMethod nextButton)
    {
        string[] texts = new string[4];
        string[] names = { "가렌", "야스오", "갈리오" };
        int idx = Random.Range(0, 3);

        yasuoCodingLv = RandomCodingLv();
        yasuoMental = Random.Range(25, 101);
        texts[0] = "안녕하세요 " + names[idx] + "입니다 \n잘 부탁드려요!";
        texts[1] = names[idx] + "의 코딩레벨 == " + (int)yasuoCodingLv + "\n" + names[idx] + "의 멘탈 == " + yasuoMental;
        texts[2] = names[idx] + "는 어디서 뭘 하고 있는거지?";
        texts[3] = "앗! \n" + names[idx] + "가 멘탈이 깨져서 집으로 가버렸습니다!";
        dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, nextButton, texts[0] , texts[1]);

        if (yasuoMental < Random.Range(0, 101))
        {
            //yasuoRun;
            dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, nextButton, texts);
            yasuoCodingLv = 0;
            Invoke("NoYasuo", 5.5f);
        }
    }

    /// <summary>
    /// 러시 등록 여부에 따라 러시 스케쥴을 실행할지 말지 결정하는 함수입니다.
    /// </summary>
    /// <param name="dialogController">대사를 출력하는 스크립트</param>
    /// <param name="nextButton">넥스트 버튼을 나타내는 함수</param>
    public void IsRegister(DialogController dialogController, ConvertMethod nextButton)
    {
        if (!GameManager.instance.GetisRush())
        {
            rushUI.ActiveTerminal();
            dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, nextButton, "러시를 등록하지 않았습니다");
        }
        else
        {
            GameManager.instance.SetWork(Work.NONE);
            rushUI.RushProcess();
        }
    }

    /// <summary>
    /// 티모가 도망갔을 때 이미지를 나타내는 함수
    /// </summary>
    private void NoTimo()
    {
        rushUI.ActiveUnavailableTimo();
    }

    /// <summary>
    /// 야스오가 도망갔을 때 이미지를 나타내는 함수
    /// </summary>
    private void NoYasuo()
    {
        rushUI.ActiveUnavailableYasuo();
    }

    /// <summary>
    /// 각 주차에 따른 코딩 레벨 랜덤으로 정해주는 함수
    /// </summary>
    /// <returns>랜덤 코딩레벨</returns>
    public float RandomCodingLv()
    {
        float codingLv = 0;

        switch (GameManager.instance.GetWeek())
        {
            case 1:
                codingLv = Random.Range(0.0f, 13.0f);
                break;
            case 2:
                codingLv = Random.Range(5.0f, 25.0f);
                break;
            case 3:
                codingLv = Random.Range(10.0f, 37.0f);
                break;
            case 4:
                codingLv = Random.Range(15.0f, 43.0f);
                break;
        }
        return (codingLv);
    }
}
