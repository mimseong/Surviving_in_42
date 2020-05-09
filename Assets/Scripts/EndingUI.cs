using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingUI : MonoBehaviour
{
    [SerializeField] private DialogController dialogController = null;
    [SerializeField] private DialogController countDialogController = null;
    [SerializeField] private EndingStory endingStory = null;
    [SerializeField] private Text textUI = null;
    [SerializeField] private Text countText = null;
    [SerializeField] private Text titleText = null;
    [SerializeField] private Text titleText2 = null;
    [SerializeField] private Text playerName = null;
    [SerializeField] private Text titleMent = null;
    [SerializeField] private Button nextButton = null;
    [SerializeField] private Button endingButton = null;
    [SerializeField] private Image backgroundImage = null;
    [SerializeField] private Image titleIcon = null;
    [SerializeField] private Sprite[] titleSprites = null;
    [SerializeField] private GameObject countName = null;
    [SerializeField] private GameObject title = null;
    [SerializeField] private Transform scroll = null;
    [SerializeField] private Transform logo = null;
    [SerializeField] private Transform[] points = null;
    private int mentIndex = 0;

    void Start()
    {
        GameManager.instance.gameObject.GetComponent<SoundManager>().EndingSound();
    }

    public void StartMent()
    {
        if (nextButton.gameObject.activeSelf)
            nextButton.gameObject.SetActive(false);
        switch (mentIndex)
        {
            case 0:
                endingStory.FirstMent(dialogController, ActiveNextButton);
                break;
            case 1:
                textUI.text = "";
                textUI.alignment = TextAnchor.MiddleCenter;
                endingStory.SecondMent(dialogController, ActiveNextButton);
                break;
            case 2:
                textUI.text = "";
                GameManager.instance.TitleResult();
                ChangeTitle();
                ActiveCountText();
                endingStory.ThirdMent(countDialogController, ActiveTitle);
                break;
        }
        mentIndex++;
    }

    public void ChangeTitle()
    {
        playerName.text = GameManager.instance.GetName();
        switch(GameManager.instance.TitleResult())
        {
            case Title.NONE:
                titleIcon.sprite = titleSprites[0];
                titleText.text = "[평범한 사람] 칭호를 얻었다";
                titleText2.text = "[평범한]";
                titleMent.text = "어떤 칭호도 얻지 못했습니다.";
                break;
            case Title.PIG:
                titleIcon.sprite = titleSprites[1];
                titleText.text = "[행복한 돼지] 칭호를 얻었다";
                titleText2.text = "[행복한 돼지]";
                titleMent.text = "왜 자꾸 살이 찌지?";
                break;
            case Title.HUNGRY:
                titleIcon.sprite = titleSprites[2];
                titleText.text = "[배고픈 소크라테스] 칭호를 얻었다";
                titleText2.text = "[배고픈 소크라테스]";
                titleMent.text = "왜 자꾸 살이 빠지지?";
                break;
            case Title.MY_WAY:
                titleIcon.sprite = titleSprites[3];
                titleText.text = "[독고다이] 칭호를 얻었다";
                titleText2.text = "[독고다이]";
                titleMent.text = "인생은 역시 마이웨이지!";
                break;
            case Title.COMMUNICATOR:
                titleIcon.sprite = titleSprites[4];
                titleText.text = "[커뮤니케이션의 달인] 칭호를 얻었다";
                titleText2.text = "[커뮤니케이션의 달인]";
                titleMent.text = "혼자하면 빨리가고! \n함께하면 멀리간다!";
                break;
            case Title.ALCOHOLIC:
                titleIcon.sprite = titleSprites[5];
                titleText.text = "[술쟁이] 칭호를 얻었다";
                titleText2.text = "[술쟁이]";
                titleMent.text = "간은 좀 괜찮으세요?";
                break;
            case Title.TRASH:
                titleIcon.sprite = titleSprites[6];
                titleText.text = "[인간 쓰레기] 칭호를 얻었다";
                titleText2.text = "[인간 쓰레기]";
                titleMent.text = "인생 그렇게 살지 마세요";
                break;
            case Title.HOMELESS:
                titleIcon.sprite = titleSprites[7];
                titleText.text = "[노숙자] 칭호를 얻었다";
                titleText2.text = "[노숙자]";
                titleMent.text = "집은 언제 가세요?";
                break;
            case Title.HOME_LOVER:
                titleIcon.sprite = titleSprites[8];
                titleText.text = "[집순이] 칭호를 얻었다";
                titleText2.text = "[집순이]";
                titleMent.text = "집에 꿀단지 모셔놨나요?";
                break;
            case Title.RICH:
                titleIcon.sprite = titleSprites[9];
                titleText.text = "[포인트 재벌] 칭호를 얻었다";
                titleText2.text = "[포인트 재벌]";
                titleMent.text = "잃는 건 한순간이지!";
                break;
            case Title.GOD_CODER:
                titleIcon.sprite = titleSprites[10];
                titleText.text = "[코딩의 신] 칭호를 얻었다";
                titleText2.text = "[코딩의 신]";
                titleMent.text = "이 기만자같으니...";
                break;
            case Title.AMOEBA:
                titleIcon.sprite = titleSprites[11];
                titleText.text = "[아메바] 칭호를 얻었다";
                titleText2.text = "[아메바]";
                titleMent.text = "나는 아무 생각이 없다";
                break;
        }
    }

    public void ActiveNextButton()
    {
        nextButton.gameObject.SetActive(true);
    }

    public void ActiveCountText()
    {
        countName.SetActive(true);
    }

    public void ActiveTitle()
    {
        countName.SetActive(false);
        title.SetActive(true);
        endingButton.gameObject.SetActive(true);
    }

    public void GoEnding()
    {
        StartCoroutine(Sequence());
    }

    private IEnumerator Sequence()
    {
        yield return new WaitForSeconds(2.0f);
        scroll.gameObject.SetActive(true);
        logo.gameObject.SetActive(true);
        yield return StartCoroutine(MoveTarget(scroll, points[0].position, 0.2f, false));
        StartCoroutine(MoveTarget(logo, points[2].position, 0.25f, false));
        yield return StartCoroutine(MoveTarget(scroll, points[1].position, 0.2f, false));
        yield return new WaitForSeconds(5.0f);
        Destroy(GameManager.instance.gameObject);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Prologue");
    }

    /// <summary>
    /// target을 endpoint로 이동시키는 함수
    /// </summary>
    /// <param name="target"> 움직일 오브젝트 </param>
    /// <param name="endPoint"> 오브젝트를 이동시킬 위치 </param>
    /// <param name="speed"> 이동 속도 </param>
    /// <param name="decelerate"> 목적지에 도달하기전 감속할지 여부 defaule true </param>
    /// <returns></returns>
    private IEnumerator MoveTarget(Transform target, Vector3 endPoint, float speed, bool decelerate = true)
    {
        Vector3 startPoint = target.position;
        float time = 0;

        if (startPoint != endPoint)
        {
            while (time < 1)
            {
                target.position = Vector3.Lerp(startPoint, endPoint, time);
                time += speed * Time.deltaTime;
                if (time > 1)
                    time = 1;
                else if (decelerate && time > 0.7f && speed > 0.2f)
                    speed -= Time.deltaTime * 4;
                yield return new WaitForSeconds(0.001f);
            }
            target.position = Vector3.Lerp(startPoint, endPoint, 1);
        }
    }
}
