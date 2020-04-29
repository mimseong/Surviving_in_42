using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour
{
    [SerializeField] private Image stressGauge;
    [SerializeField] private Image friendshipGauge;
    [SerializeField] private Image cleanGauge;
    [SerializeField] private Image sleepGauge;
    [SerializeField] private Image codingLvGauge;
    [SerializeField] private Image fortytwoGauge;
    [SerializeField] private Text stressTxt;
    [SerializeField] private Text friendshipTxt;
    [SerializeField] private Text cleanTxt;
    [SerializeField] private Text sleepTxt;
    [SerializeField] private Text codingLvTxt;
    [SerializeField] private Text fortytwoTxt;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowStatus()
    {
        StartCoroutine(AnimateStatus(codingLvGauge, GameManager.instance.GetPrecodingLevel(), GameManager.instance.GetCodingLevel(), 42f));
        StartCoroutine(AnimateStatus(fortytwoGauge, GameManager.instance.GetPrefortytwoLevel(), GameManager.instance.GetFortytwoLevel(), 12f));
        StartCoroutine(AnimateStatus(stressGauge, (float)GameManager.instance.GetPrestress(), (float)GameManager.instance.GetStress(), 100f));
        StartCoroutine(AnimateStatus(friendshipGauge, (float)GameManager.instance.GetPreFriendship(), (float)GameManager.instance.GetFriendship(), 100f));
        StartCoroutine(AnimateStatus(cleanGauge, (float)GameManager.instance.GetPreclean(), (float)GameManager.instance.GetClean(), 100f));
        StartCoroutine(AnimateStatus(sleepGauge, (float)GameManager.instance.GetPresleep(), (float)GameManager.instance.GetSleep(), 100f));

        codingLvTxt.text = "코딩 레벨 " + GameManager.instance.GetCodingLevel();
        fortytwoTxt.text = "42 레벨 " + GameManager.instance.GetFortytwoLevel();
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
}
