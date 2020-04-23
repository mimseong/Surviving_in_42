using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    [SerializeField] private Text textUI;
    private IEnumerator coruoutine = null;

    void Start()
    {

    }

    void Update()
    {

    }

    /// <summary> textUI에 text를 출력하는 함수</summary>
    /// <param name="text"> textUI에 출력되는 문자열 </param>
    /// <param name="startTerm"> text가 처음에 출력되기전에 대기하는 시간 </param>
    /// <param name="speed"> 한글자가 나타나는 속도 0.02f를 추천 </param>
    public void ShowText(string text, float startTerm, float speed)
    {
        if (coruoutine != null) StopCoroutine(coruoutine);
        coruoutine = PrintText(text, startTerm, speed);
        StartCoroutine(coruoutine);
    }

    /// <summary>
    /// textUI에 여러 text를 순서대로 출력하는 함수
    /// </summary>
    /// <param name="startTerm"> text를 처음에 출력하기전에 대기하는 시간, 첫번째 텍스트에만 적용된다. </param>
    /// <param name="eachTerm"> 각 text를 출력하기 전에 대기하는 시간, 첫번째 텍스트에는 적용되지 않는다. </param>
    /// <param name="speed"> 한글자가 나타나는 속도 0.02f를 추천 </param>
    /// <param name="texts"> textUI에 출력되는 문자열들 </param>
    public void ShowTexts(float startTerm, float eachTerm, float speed, params string[] texts)
    {
        if (coruoutine != null) StopCoroutine(coruoutine);
        coruoutine = PrintTexts(startTerm, eachTerm, speed, texts);
        StartCoroutine(coruoutine);
    }

    /// <summary>
    /// textUI에 여러 text를 순서대로 출력한후 매개변수로 넘어온 함수를 실행하는 함수
    /// </summary>
    /// <param name="startTerm"> text를 처음에 출력하기전에 대기하는 시간, 첫번째 텍스트에만 적용된다. </param>
    /// <param name="eachTerm"> 각 text를 출력하기 전에 대기하는 시간, 첫번째 텍스트에는 적용되지 않는다. </param>
    /// <param name="speed"> 한글자가 나타나는 속도 0.02f를 추천 </param>
    /// <param name="methodTerm"> func가 실행되기 전에 대기하는 시간 </param>
    /// <param name="func"> 모든 text가 출력된 후 실행되는 함수 </param>
    /// <param name="texts"> textUI에 출력되는 문자열들 </param>
    public void ShowTexts(float startTerm, float eachTerm, float speed, float methodTerm, ConvertMethod func, params string[] texts)
    {
        if (coruoutine != null) StopCoroutine(coruoutine);
        coruoutine = PrintTexts(startTerm, eachTerm, speed, methodTerm, func, texts);
        StartCoroutine(coruoutine);
    }

    private IEnumerator PrintText(string text, float startTerm, float speed)
    {
        yield return new WaitForSeconds(startTerm);
        textUI.text = "";

        foreach (char letter in text.ToCharArray())
        {
            textUI.text += letter;
            yield return new WaitForSeconds(speed);
        }
    }

    private IEnumerator PrintTexts(float startTerm, float eachTerm, float speed, params string[] texts)
    {
        yield return new WaitForSeconds(startTerm);
        for (int i = 0; i < texts.Length; i++)
        {
            if (i == 0)
                yield return StartCoroutine(PrintText(texts[i], 0, speed));
            else
                yield return StartCoroutine(PrintText(texts[i], eachTerm, speed));
        }
    }

    private IEnumerator PrintTexts(float startTerm, float eachTerm, float speed, float methodTerm, ConvertMethod func, params string[] texts)
    {
        yield return new WaitForSeconds(startTerm);
        for (int i = 0; i < texts.Length; i++)
        {
            if (i == 0)
                yield return StartCoroutine(PrintText(texts[i], 0, speed));
            else
                yield return StartCoroutine(PrintText(texts[i], eachTerm, speed));
        }
        yield return new WaitForSeconds(methodTerm);
        func();
    }
}