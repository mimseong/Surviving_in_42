using UnityEngine;

public class DailyStory : MonoBehaviour
{
    [SerializeField] private DailyUIManager uIManager = null;

    void Start()
    {
        uIManager.ActiveTerminal();
    }

    void Update()
    {
        
    }

    /// <summary>
    /// 시간대에 따라 다른 멘트가 준비되어 있습니다
    /// </summary>
    /// <param name="dialogController">대사를 출력하는 스크립트</param>
    /// <param name="fx">버튼 나오게 하는 함수</param>

    public void FirstMent(DialogController dialogController, ConvertMethod fx)
    {
        string[] morning = { "상쾌한 아침이다!", "새로운 아침이다", "오늘도 하루가 시작됐다" };
        string[] afternoon = { "점심을 먹고 나니 잠이 쏟아진다...", "점심을 먹고 나니 힘이 난다!", "정신을 차려보니 벌써 점심이다" };
        string[] night = { "한 것도 없는데 벌써 저녁이다!", "밖은 벌써 어두컴컴해졌다", "어느새 해가 저물었다" };
        string[] dawn = { "고요한 새벽이다..", "새벽에는 사람이 별로 없군", "조용해서 집중하기 좋은 새벽이다" };
        int idx = Random.Range(0, 3);

        switch (GameManager.instance.GetSchedule())
        {
            case Schedule.MORNING:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, fx, morning[idx], "무엇을 할까?");
                break;
            case Schedule.AFTERNOON:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, fx, afternoon[idx], "무엇을 할까?");
                break;
            case Schedule.NIGHT:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, fx, night[idx], "무엇을 할까?");
                break;
            case Schedule.DAWN:
                dialogController.ShowTexts(0.5f, 1.5f, 0.02f, 0.5f, fx, dawn[idx], "무엇을 할까?");
                break;
        }
    }
}
