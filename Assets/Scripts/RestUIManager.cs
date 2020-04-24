using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestUIManager : MonoBehaviour
{
    [SerializeField] private Image beer;
    [SerializeField] private Image sleep;
    [SerializeField] private Image goHome;
    [SerializeField] private Image lazy;
    [SerializeField] private Button nextButton;
    [SerializeField] private Image terminal;
    [SerializeField] private RestStory restStory;
    [SerializeField] private DialogController dialogController;
    [SerializeField] private Sprite[] drinking;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.SetWork(Work.LAZY);
        ActiveImage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActiveTerminal()
    {
        terminal.gameObject.SetActive(true);
        restStory.DecideRest(dialogController, GameManager.instance.GetWork());
    }

    public void NextButton(bool value)
    {
        nextButton.gameObject.SetActive(value);
    }

    private void ActiveImage()
    {
        Work tmp = GameManager.instance.GetWork();
        switch (tmp)
        {
            case Work.DRINKING:
                RandomSetImage(beer, drinking);
                beer.gameObject.SetActive(true);
                break;
            case Work.SLEEP:
                sleep.gameObject.SetActive(true);
                break;
            case Work.GO_HOME:
                goHome.gameObject.SetActive(true);
                break;
            case Work.LAZY:
                break;
        }
        if (tmp == Work.DRINKING || tmp == Work.SLEEP || tmp == Work.GO_HOME || tmp == Work.LAZY)
            Invoke("ActiveTerminal", 1.2f);
    }

    private void RandomSetImage(Image target, Sprite[] sprites)
    {
        int index = Random.Range(0, sprites.Length);
        if (index != 0)
            target.sprite = sprites[index];
    }
}
