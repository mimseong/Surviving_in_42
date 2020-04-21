using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private float codingLevel;
    private float fortytwoLevel;
    private int clean;
    private int friendship;
    private int stress;
    private int sleep;
    private Schedule schedule;
    private int week;
    private Day day;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void SetCodingLevel(float codingLevel)
    {
        this.codingLevel = codingLevel;
    }

    public float GetCodingLevel()
    {
        return (this.codingLevel);
    }

    public void SetFortytwoLevel(float fortytwoLevel)
    {
        this.fortytwoLevel = fortytwoLevel;
    }

    public float GetFortytwoLevel()
    {
        return (this.fortytwoLevel);
    }

    public void SetClean(int clean)
    {
        this.clean = clean;
    }

    public int GetClean()
    {
        return (this.clean);
    }

    public void SetFriendship(int friendship)
    {
        this.friendship = friendship;
    }

    public int GetFriendship()
    {
        return (this.friendship);
    }

    public void SetStress(int stress)
    {
        this.stress = stress;
    }

    public int GetStress()
    {
        return (this.stress);
    }

    public void SetSleep(int sleep)
    {
        this.sleep = sleep;
    }

    public int GetSleep()
    {
        return (this.sleep);
    }

    public void SetSchedule(Schedule schedule)
    {
        this.schedule = schedule;
    }

    public Schedule GetSchedule()
    {
        return (this.schedule);
    }

    public void NextWeek(int amount)
    {
        this.week += amount;
    }
    public void NextDay(int amount)
    {
        this.day += amount;
        while ((int)this.day > 6)
        {
            this.day -= 7;
            NextWeek(1);
        }
    }
    /// <summary>
    /// 스케쥴을 증가시키는 함수. 밤이 지나면 다음 날이 된다.
    /// </summary>
    /// <param name="amount"> 이 변수의 값만큼 스케쥴이 증가한다. </param>
    public void NextSchedule(int amount)
    {
        this.schedule += amount;
        while ((int)this.schedule > 3)
        {
            NextDay(1);
            this.schedule -= 4;
        }
    }
}
