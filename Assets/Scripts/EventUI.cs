using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventUI : MonoBehaviour
{
    [SerializeField] private Image player;
    [SerializeField] private Image hand;
    [SerializeField] private Image candy;
    [SerializeField] private Image chocolate;
    [SerializeField] private Image energy;
    [SerializeField] private Image mousepad;
    [SerializeField] private Image squat;
    [SerializeField] private Image pizza;
    [SerializeField] private Image pizzaCat;
    [SerializeField] private Image background;
    [SerializeField] private Image terminal;
    [SerializeField] private Image reverseColor;
    [SerializeField] private Button nextButton;
    [SerializeField] private Sprite[] backgroundSprites;
    [SerializeField] private EventStory eventStory;
    [SerializeField] private DialogController dialogController;

    // Start is called before the first frame update
    void Start()
    {
        ActiveImage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void ActiveTerminal()
    {
        terminal.gameObject.SetActive(true);
        eventStory.DecideEvent(dialogController, GameManager.instance.GetEvent());
    }

    public void ActiveNextButton(bool value)
    {
        nextButton.gameObject.SetActive(value);
    }

    /// <summary>
    /// 이벤트에 따라 이미지를 실행시키는 함수
    /// </summary>
    public void ActiveImage()
    {
        Suprise tmp = GameManager.instance.GetEvent();
        if (tmp == Suprise.SQUAT || tmp == Suprise.REVERSE_COLOR)
        {
            switch (tmp)
            {
                case Suprise.REVERSE_COLOR:
                    background.sprite = backgroundSprites[1];
                    reverseColor.gameObject.SetActive(true);
                    player.gameObject.SetActive(true);
                    break;
                case Suprise.SQUAT:
                    background.sprite = backgroundSprites[2];
                    squat.gameObject.SetActive(true);
                    break;

            }
        }
        else
        {
            hand.gameObject.SetActive(true);
            background.sprite = backgroundSprites[0];
            switch (tmp)
            {

                case Suprise.CANDY:
                    candy.gameObject.SetActive(true);
                    break;
                case Suprise.MOUSE_PAD:
                    mousepad.gameObject.SetActive(true);
                    break;
                case Suprise.CHOCOLATE:
                    chocolate.gameObject.SetActive(true);
                    break;
                case Suprise.ENERGYBAR:
                    energy.gameObject.SetActive(true);
                    break;
                case Suprise.PIZZA:
                    hand.gameObject.SetActive(false);
                    pizzaCat.gameObject.SetActive(true);
                    pizza.gameObject.SetActive(true);
                    break;
            }
        }
            Invoke("ActiveTerminal", 1.2f);
    }

    public void NextScene()
    {
        SceneManager.LoadScene("DailyScene");
    }
}
