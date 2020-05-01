using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Prologue : MonoBehaviour
{
    [SerializeField] private Transform movePointParent = null;
    [SerializeField] private Transform targetEndPoint = null;
    [SerializeField] private Transform mainLogo = null;
    [SerializeField] private Transform background = null;
    private Transform[] movePoints = null;

    void Start()
    {
        movePoints = new Transform[movePointParent.childCount];
        for (int i = 0; i < movePointParent.childCount; i++)
        {
            movePoints[i] = movePointParent.GetChild(i);
        }
    }

    void Update()
    {
        
    }

    /// <summary>
    /// 배경화면을 보여주고 이동하고 로고가 내려오는 시퀀스를 실행하는 함수
    /// </summary>
    public void StartSequence()
    {
        StartCoroutine(Sequence());
    }

    private IEnumerator Sequence()
    {
        this.background.position = this.movePoints[0].position;
        background.gameObject.SetActive(true);
        yield return StartCoroutine(MoveWaypoint(this.background, this.movePoints, 0.15f));
        yield return new WaitForSeconds(1.5f);
        yield return StartCoroutine(MoveTarget(this.mainLogo, this.targetEndPoint.position, 1.5f));
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("RegisterScene");
    }

    /// <summary>
    /// target을 endpoint로 이동시키는 함수
    /// </summary>
    /// <param name="target"> 움직일 오브젝트 </param>
    /// <param name="endPoint"> 오브젝트를 이동시킬 위치 </param>
    /// <param name="speed"> 이동 속도 </param>
    /// <param name="decelerate"> 목적지에 도달하기전 감속할지 여부 defaule true </param>
    /// <returns></returns>
    private IEnumerator MoveTarget(Transform target, Vector3 endPoint, float speed, bool decelerate = true)
    {
        Vector3 startPoint = target.position;
        float time = 0;

        if (startPoint != endPoint)
        {
            while (time < 1)
            {
                target.position = Vector3.Lerp(startPoint, endPoint, time);
                time += speed * Time.deltaTime;
                if (time > 1)
                    time = 1;
                else if (decelerate && time > 0.7f && speed > 0.2f)
                    speed -= Time.deltaTime * 4;
                yield return new WaitForSeconds(0.001f);
            }
            target.position = Vector3.Lerp(startPoint, endPoint, 1);
        }
    }

    /// <summary>
    /// target을 여러 경유지에 따라 이동시키는 함수
    /// </summary>
    /// <param name="target"> 움직일 오브젝트 </param>
    /// <param name="waypoint"> 경유지들 </param>
    /// <param name="speed"> 이동 속도 </param>
    /// <returns></returns>
    private IEnumerator MoveWaypoint(Transform target, Transform[] waypoint, float speed)
    {
        int index = 0;

        while (index < waypoint.Length)
        {
            yield return StartCoroutine(MoveTarget(target, waypoint[index].position, speed, false));
            index++;
        }
    }
}
