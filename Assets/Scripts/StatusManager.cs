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
    [SerializeField] private Text stressTxt;
    [SerializeField] private Text friendshipTxt;
    [SerializeField] private Text cleanTxt;
    [SerializeField] private Text sleepTxt;


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
        stressGauge.fillAmount = (float)GameManager.instance.GetStress() / 100f;
        friendshipGauge.fillAmount = (float)GameManager.instance.GetFriendship() / 100f;
        cleanGauge.fillAmount = (float)GameManager.instance.GetClean() / 100;
        sleepGauge.fillAmount = (float)GameManager.instance.GetSleep() / 100;
        stressTxt.text = "스트레스 " + GameManager.instance.GetStress();
        friendshipTxt.text = "인싸력 " + GameManager.instance.GetFriendship();
        cleanTxt.text = "청결도 " + GameManager.instance.GetClean();
        sleepTxt.text = "졸림 " + GameManager.instance.GetSleep();
    }
}
