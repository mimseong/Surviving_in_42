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
    [SerializeField] private Image backgroundImage = null;
    [SerializeField] private Image titleIcon = null;
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
                ActiveCountText();
                endingStory.ThirdMent(countDialogController, ActiveTitle);
                break;
        }
        mentIndex++;
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
        StartCoroutine(Sequence());
    }

    private IEnumerator Sequence()
    {
        yield return new WaitForSeconds(2.0f);
        scroll.gameObject.SetActive(true);
        logo.gameObject.SetActive(true);
        yield return StartCoroutine(MoveTarget(scroll, points[0].position, 0.1f, false));
        StartCoroutine(MoveTarget(logo, points[2].position, 0.15f, false));
        yield return StartCoroutine(MoveTarget(scroll, points[1].position, 0.1f, false));
        yield return new WaitForSeconds(5.0f);
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
