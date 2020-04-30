using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour
{
    [SerializeField] private Image stressGauge;
    [SerializeField] private Image friendshipGauge;
    [SerializeField] private Image cleanGauge;
    [SerializeField] private Image sleepGauge;
    [SerializeField] private Image codingLvGauge;
    [SerializeField] private Image fortytwoGauge;
    [SerializeField] private Image player;
    [SerializeField] private Image curfew;
    [SerializeField] private Image background;
    [SerializeField] private Text stressTxt;
    [SerializeField] private Text friendshipTxt;
    [SerializeField] private Text cleanTxt;
    [SerializeField] private Text sleepTxt;
    [SerializeField] private Text codingLvTxt;
    [SerializeField] private Text fortytwoTxt;
    [SerializeField] private Text playerCondition;
    [SerializeField] private Text curfewTxt;
    [SerializeField] private Sprite[] playerSprites;
    [SerializeField] private Sprite[] curfewSprite;
    [SerializeField] private Button goCurfew;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.DecideCondition();
        PlayerCondition();
        Curfew();
    }

    // Update is called once per frame
    void Update()
    {

    }


    /// <summary>
    /// 스탯을 보여주는 함수
    /// </summary>
    public void ShowStatus()
    {
        StartCoroutine(AnimateStatus(codingLvGauge, GameManager.instance.GetPrecodingLevel(), GameManager.instance.GetCodingLevel(), 42f));
        StartCoroutine(AnimateStatus(fortytwoGauge, GameManager.instance.GetPrefortytwoLevel(), GameManager.instance.GetFortytwoLevel(), 12f));
        StartCoroutine(AnimateStatus(stressGauge, (float)GameManager.instance.GetPrestress(), (float)GameManager.instance.GetStress(), 100f));
        StartCoroutine(AnimateStatus(friendshipGauge, (float)GameManager.instance.GetPreFriendship(), (float)GameManager.instance.GetFriendship(), 100f));
        StartCoroutine(AnimateStatus(cleanGauge, (float)GameManager.instance.GetPreclean(), (float)GameManager.instance.GetClean(), 100f));
        StartCoroutine(AnimateStatus(sleepGauge, (float)GameManager.instance.GetPresleep(), (float)GameManager.instance.GetSleep(), 100f));

        codingLvTxt.text = "코딩 레벨 " + GameManager.instance.GetCodingLevel();
        fortytwoTxt.text = "42 레벨 " + GameManager.instance.GetFortytwoLevel().ToString("0.0");
        stressTxt.text = "스트레스 " + GameManager.instance.GetStress();
        friendshipTxt.text = "인싸력 " + GameManager.instance.GetFriendship();
        cleanTxt.text = "청결도 " + GameManager.instance.GetClean();
        sleepTxt.text = "졸림 " + GameManager.instance.GetSleep();

        GameManager.instance.SetPreCodingLv(GameManager.instance.GetCodingLevel());
        GameManager.instance.SetPreFortytwoLevel(GameManager.instance.GetFortytwoLevel());
        GameManager.instance.SetPrestress(GameManager.instance.GetStress());
        GameManager.instance.SetPrefriendship(GameManager.instance.GetFriendship());
        GameManager.instance.SetPreclean(GameManager.instance.GetClean());
        GameManager.instance.SetPresleep(GameManager.instance.GetSleep());
    }

    /// <summary>
    /// 상태 변화를 애니메이션으로 보여주는 함수, gap == 변화량
    /// </summary>
    /// <param name="image"> 이미지 </param>
    /// <param name="prestatus"> 이전 수치 </param>
    /// <param name="status"> 현재 수치 </param>
    /// <param name="div"> 나눌 숫자 </param>
    /// <returns></returns>
    private IEnumerator AnimateStatus(Image image, float prestatus, float status, float div)
    {
        float gap = status - prestatus;
        float delta = gap * Time.deltaTime;

        image.fillAmount = prestatus / div;
        yield return new WaitForSeconds(1.0f);
        if (gap > 0)
        {
            while (prestatus < status)
            {
                prestatus += delta;
                yield return new WaitForSeconds(0.02f);
                image.fillAmount += delta / div;
            }
        }
        else
        {
            while (status < prestatus)
            {
                prestatus += delta;
                yield return new WaitForSeconds(0.02f);
                image.fillAmount += delta / div;
            }
        }
    }

    private void PlayerCondition()
    {
        switch (GameManager.instance.GetCondition())
        {
            case Condition.NORMAL:
                playerCondition.text = ">>> 상태 좋음! <<<";
                player.sprite = playerSprites[0];
                break;
            case Condition.DIRTY:
                playerCondition.text = ">>> 더러워서 동료들이 싫어합니다! <<<";
                player.sprite = playerSprites[1];
                break;
            case Condition.SLEEPY:
                playerCondition.text = ">>> 졸려서 집중이 안됩니다! <<<";
                player.sprite = playerSprites[2];
                break;
            case Condition.HANGOVER:
                playerCondition.text = ">>> 앗! 전날 술을 마셔서 상태가..! <<<";
                player.sprite = playerSprites[3];
                break;
            case Condition.TIRED:
                playerCondition.text = ">>> 피로가 누적돼서 효율이 떨어집니다... <<<";
                player.sprite = playerSprites[4];
                break;
            case Condition.FEVER:
                playerCondition.text = ">>> 갑자기 오늘은 코딩이 너무 잘 되는데? <<<";
                player.sprite = playerSprites[5];
                break;
        }
    }

    private void Curfew()
    {
        if (GameManager.instance.GetStress() == 100 || GameManager.instance.GetClean() == 0 || GameManager.instance.GetSleep() == 100)
        {
            player.gameObject.SetActive(false);
            curfew.gameObject.SetActive(true);
            if (GameManager.instance.GetStress() == 100)
            {
                curfewTxt.text = "스트레스가 심해져서 집에 갑니다";
                background.sprite = curfewSprite[0];
            }
            else if (GameManager.instance.GetSleep() == 100)
            {
                curfewTxt.text = "너무 졸려서 집에 갑니다";
                background.sprite = curfewSprite[1];
            }
            else if (GameManager.instance.GetClean() == 0)
            {
                curfewTxt.text = "너무 더러워서 집에 갑니다";
                background.sprite = curfewSprite[2];
            }
            goCurfew.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// 버튼을 누르면 집에 가는 씬으로 전환됩니다.
    /// </summary>
    public void WhenPushCurfew()
    {
        GameManager.instance.SetWork(Work.GO_HOME);
        SceneManager.LoadScene("RestScene");
    }
}
