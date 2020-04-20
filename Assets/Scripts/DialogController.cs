using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    [SerializeField] private Text textUI;
    private IEnumerator coruoutine;

    void Start()
    {
        
    }

    void Update()
    {

    }

    /// <summary> textUI에 text를 출력하는 함수</summary>
    /// <param name="startTerm"> text가 처음에 출력되기전에 대기하는 시간 </param>
    /// <param name="speed"> 한글자가 나타나는 속도 0.02f를 추천 </param>
    public void ShowText(string text, float startTerm, float speed)
    {
        if (coruoutine != null) StopCoroutine(coruoutine);
        coruoutine = PrintText(text, startTerm, speed);
        StartCoroutine(coruoutine);
    }

    private IEnumerator PrintText(string text, float startTerm, float speed)
    {
        textUI.text = "";
        yield return new WaitForSeconds(startTerm);

        foreach (char letter in text.ToCharArray())
        {
            textUI.text += letter;
            yield return new WaitForSeconds(speed);
        }
    }
}
