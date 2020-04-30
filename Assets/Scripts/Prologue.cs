using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Prologue : MonoBehaviour
{
    [SerializeField] private Transform targetEndPoint = null;
    [SerializeField] private Transform target = null;
    [SerializeField] private Image background = null;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void StartSequence()
    {
        StartCoroutine(Sequence());
    }

    private IEnumerator Sequence()
    {
        background.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        yield return StartCoroutine(MoveTarget(target, targetEndPoint.position, 1.5f));
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("RegisterScene");
    }

    private IEnumerator MoveTarget(Transform target, Vector3 endPoint, float speed)
    {
        Vector3 startPoint = target.position;
        float time = 0;

        while (time < 1)
        {
            target.position = Vector3.Lerp(startPoint, endPoint, time);
            time += speed * Time.deltaTime;
            if (time > 1)
                time = 1;
            else if (time > 0.7f && speed > 0.2f)
                speed -= Time.deltaTime * 4;
            yield return new WaitForSeconds(0.001f);
        }
        target.position = Vector3.Lerp(startPoint, endPoint, 1);
    }
}
