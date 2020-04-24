using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestStory : MonoBehaviour
{
    [SerializeField] private RestUIManager restUIManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecideRest(DialogController dialogController, Work work)
    {
        GameManager.instance.SetWork(work);
        switch (work)
        {
            case Work.DRINKING:
                Beer(dialogController);
                break;
            case Work.SLEEP:
                Sleep(dialogController);
                break;
            case Work.GO_HOME:
                GoHome(dialogController);
                break;
            case Work.LAZY:
                Lazy(dialogController);
                break;
        }
    }

    private void Beer(DialogController dialogController)
    {
        dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "동료들과 함께 술을 마셨다", "언제까지 어깨춤을 추게 할거야~", "동료와의 관계 += 5", "만취해서 집에 갑니다");
    }

    private void Sleep(DialogController dialogController)
    {
        dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "소파에서 조금 자기로 합니다", "...\n..\n...", "졸림 -= 30 \n스트레스 -= 10");
    }

    private void GoHome(DialogController dialogController)
    {
        dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "이만 집에 가는 게 좋겠다", "집에서 씻고 청결도가 회복됩니다", "집에서 자고 졸림이 해소됩니다", "졸림 = 0 \n청결 = MAX \n스트레스 -= 50");
    }

    private void Lazy(DialogController dialogController)
    {
        int situation = Random.Range(0, 5);
        switch (situation)
        {
            case 0:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "도비와 함께 춤을!", "도비와 사진 찍고 놀았다");
                break;
            case 1:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "동료들과 수다를 떨었다", "동료A : 할게 너무 많아서 힘들어 \n동료B : 그거 나는 다 맞았는데 \n동료들 : ...", "...\n...\n...");
                break;
            case 2:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "유튜브 알고리즘을 따라 게임방송까지 흘러갔다", "내가 이걸 왜 보고 있지", "...\n...\n...", "재밌어서 계속 보게 된다");
                break;
            case 3:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "멍하니 검은 창을 바라보았다", "...\n...\n...", "아무것도 안했는데 시간이 왜이리 잘가지?");
                break;
            case 4:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "동료들과 노닥거렸다", "동료A : 기침은 Calloc Calloc! \n동료들 : 하하하! 너무 웃겨! \n동료B : 또 시작이군", "...\n...\n...");
                break;
        }
    }
}
