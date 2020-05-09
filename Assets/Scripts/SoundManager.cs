using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource = null;
    [SerializeField] private AudioClip opening = null;
    [SerializeField] private AudioClip firstWeek = null;
    [SerializeField] private AudioClip secondWeek = null;
    [SerializeField] private AudioClip thirdWeek = null;
    [SerializeField] private AudioClip ending = null;
    private int storeWeek = 0;

    void Start()
    {
        audioSource.clip = opening;
        audioSource.Play();
    }

    void Update()
    {
        
    }

    /// <summary>
    /// 각 주차에 따라 bgm을 삽입하는 함수
    /// </summary>
    /// <param name="week">getweek함수를 params로 받을 것임</param>
    public void ActiveSound(int week)
    {
        switch (week)
        {
            case 1:
                audioSource.clip = firstWeek;
                break;
            case 2:
                audioSource.clip = secondWeek;
                break;
            case 3:
                audioSource.clip = thirdWeek;
                break;
        }
        if (storeWeek != week)
        {
            storeWeek = week;
            audioSource.Play();
        }
    }

    /// <summary>
    /// 엔딩씬에서 bgm 재생하는 함수
    /// </summary>
    public void EndingSound()
    {
        audioSource.clip = ending;
        audioSource.Play();
    }

}
