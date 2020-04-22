using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudyUIManager : MonoBehaviour
{
    [SerializeField] private Image soloCoding;
    [SerializeField] private Image duoCoding;
    [SerializeField] private Image evaluate;
    [SerializeField] private Image evaluated;
    [SerializeField] private Image cheating;
    [SerializeField] private Sprite[] solosSprites;
    [SerializeField] private Sprite[] duoSprites;
    [SerializeField] private Sprite[] evalSprites;
    [SerializeField] private Sprite[] evedSprites;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.SetWork(Work.DUO_CODING);
        ActiveImage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveImage()
    {
        Work tmp = GameManager.instance.GetWork();
        switch (tmp)
        {
            case Work.SOLO_CODING:
                RandomSetImage(soloCoding, solosSprites);
                soloCoding.gameObject.SetActive(true);
                break;
            case Work.DUO_CODING:
                RandomSetImage(duoCoding, duoSprites);
                duoCoding.gameObject.SetActive(true);
                break;
            case Work.EVALUATE:
                RandomSetImage(evaluate, evalSprites);
                evaluate.gameObject.SetActive(true);
                break;
            case Work.EVALUATED:
                RandomSetImage(evaluated, evedSprites);
                evaluated.gameObject.SetActive(true);
                break;
            case Work.CHEATING:
                cheating.gameObject.SetActive(true);
                break;
        }
    }

    public void RandomSetImage(Image target, Sprite[] sprites)
    {
        int index = Random.Range(0, sprites.Length);
        if (index != 0)
            target.sprite = sprites[index];
    }
}
