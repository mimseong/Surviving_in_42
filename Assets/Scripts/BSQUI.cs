using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BSQUI : MonoBehaviour
{
    [SerializeField] private DialogController dialogController;
    [SerializeField] private Button nextButton;
    [SerializeField] private Image terminal;
    [SerializeField] private Image jinx;
    [SerializeField] private Image peer;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private BSQstory bsqStory;
    private int countingButton = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BSQprocess()
    {
        switch (countingButton)
        {
            case 0:
                terminal.gameObject.SetActive(true);
                bsqStory.BSQstart(dialogController, ActiveNextButton);
                break;
            case 1:
                ActiveImage();
                bsqStory.Jinx(dialogController, ActiveNextButton);
                break;
            case 2:
                bsqStory.BSQresult(dialogController, ActiveNextButton);
                jinx.gameObject.SetActive(false);
                RandomSetImage(peer, sprites);
                peer.gameObject.SetActive(true);
                break;
            case 3:
                NextScene();
                break;
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
    public void NextScene()
    {
        NextButton(false);
        SceneManager.LoadScene("ExamScene");
    }

    public void NextButton(bool value)
    {
        nextButton.gameObject.SetActive(value);
    }

    public void ActiveImage()
    {
        RandomSetImage(jinx, sprites);
        jinx.gameObject.SetActive(true);
    }


    /// <summary>
    /// 넥스트 버튼 켜는 함수
    /// </summary>
    private void ActiveNextButton()
    {
        NextButton(true);
        countingButton++;
    }

    private void RandomSetImage(Image target, Sprite[] sprites)
    {
        int index = Random.Range(0, sprites.Length);
        target.sprite = sprites[index];
    }
}
