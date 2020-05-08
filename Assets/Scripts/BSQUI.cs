using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BSQUI : MonoBehaviour
{
    [SerializeField] private DialogController dialogController = null;
    [SerializeField] private Button nextButton = null;
    [SerializeField] private Image terminal = null;
    [SerializeField] private Image jinx = null;
    [SerializeField] private Image peer = null;
    [SerializeField] private Sprite[] sprites = null;
    [SerializeField] private BSQstory bsqStory = null;
    private int countingButton = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 버튼을 누름에 따라 bsq스토리가 진행됨
    /// </summary>
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

    /// <summary>
    /// 다음씬으로 넘어간다
    /// </summary>
    public void NextScene()
    {
        NextButton(false);
        SceneManager.LoadScene("ExamScene");
    }

    /// <summary>
    /// 넥스트 버튼 활성화 함수
    /// </summary>
    /// <param name="value"></param>
    public void NextButton(bool value)
    {
        nextButton.gameObject.SetActive(value);
    }

    /// <summary>
    /// 팀원 이미지 활성화
    /// </summary>
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
