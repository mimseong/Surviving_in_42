using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingUI : MonoBehaviour
{
    [SerializeField] private DialogController dialogController;
    [SerializeField] private EndingStory endingStory;
    [SerializeField] private Text textUI;
    [SerializeField] private Button nextButton;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image endingImage;
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
                textUI.color = new Color(0, 0, 0);
                textUI.alignment = TextAnchor.UpperCenter;
                Vector3 temp = textUI.transform.position;
                temp.y += 90;
                textUI.transform.position = temp;
                backgroundImage.color = new Color(255, 255, 255);
                endingStory.ThirdMent(dialogController, ActiveEndingImage);
                break;
        }
        mentIndex++;
    }

    public void ActiveNextButton()
    {
        nextButton.gameObject.SetActive(true);
    }

    public void ActiveEndingImage()
    {
        endingImage.gameObject.SetActive(true);
    }
}
