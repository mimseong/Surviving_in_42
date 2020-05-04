using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip opening;
    [SerializeField] private AudioClip firstWeek;
    [SerializeField] private AudioClip secondWeek;
    [SerializeField] private AudioClip thirdWeek;
    [SerializeField] private AudioClip ending;
    private int storeWeek = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = opening;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

    public void EndingSound()
    {
        audioSource.clip = ending;
        audioSource.Play();
    }

}
