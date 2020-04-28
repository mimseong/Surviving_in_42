using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private float codingLevel = 0;
    private float fortytwoLevel = 0;
    private int clean = 100;
    private int friendship = 0;
    private int stress = 0;
    private int sleep = 0;
    private int week = 1;
    private string name;
    private Day day = Day.MON;
    private Schedule schedule = Schedule.MORNING;
    private Work work;
    private bool isEvaluate = false;
    private bool isExam = false;
    private bool isRush = false;

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
        SetFriendship(80);
        SetCodingLevel(20);
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

    public void AddCodingLevel(float codingLevel)
    {
        this.codingLevel += codingLevel;
        if (this.codingLevel > 42)
            this.codingLevel = 42;
        else if (this.codingLevel < 0)
            this.codingLevel = 0;
    }

    public void SetFortytwoLevel(float fortytwoLevel)
    {
        this.fortytwoLevel = fortytwoLevel;
    }

    public float GetFortytwoLevel()
    {
        return (this.fortytwoLevel);
    }

    public void AddFortytwoLevel(float fortytwoLevel)
    {
        this.fortytwoLevel += fortytwoLevel;
        if (this.fortytwoLevel > 12)
            this.fortytwoLevel = 12;
        else if (this.fortytwoLevel < 0)
            this.fortytwoLevel = 0;
    }

    public void SetClean(int clean)
    {
        this.clean = clean;
    }

    public int GetClean()
    {
        return (this.clean);
    }

    public void AddClean(int clean)
    {
        this.clean += clean;
        if (this.clean > 100)
            this.clean = 100;
        else if (this.clean < 0)
            this.clean = 0;
    }

    public void SetFriendship(int friendship)
    {
        this.friendship = friendship;
    }

    public int GetFriendship()
    {
        return (this.friendship);
    }

    public void AddFriendship(int friendship)
    {
        this.friendship = friendship;
        if (this.friendship > 100)
            this.friendship = 100;
        else if (this.friendship < 0)
            this.friendship = 0;
    }

    public void SetStress(int stress)
    {
        this.stress = stress;
    }

    public int GetStress()
    {
        return (this.stress);
    }

    public void AddStress(int stress)
    {
        this.stress = stress;
        if (this.stress > 100)
            this.stress = 100;
        else if (this.stress < 0)
            this.stress = 0;

    }

    public void SetSleep(int sleep)
    {
        this.sleep = sleep;
    }

    public int GetSleep()
    {
        return (this.sleep);
    }

    public void AddSleep(int sleep)
    {
        this.sleep = sleep;
        if(this.sleep > 100)
            this.sleep = 100;
        else if (this.sleep < 0)
            this.sleep = 0;
    }

    public void SetName(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return (this.name);
    }

    public void SetWork(Work work)
    {
        this.work = work;
    }

    public Work GetWork()
    {
        return (this.work);
    }

    public void SetSchedule(Schedule schedule)
    {
        this.schedule = schedule;
    }

    public Schedule GetSchedule()
    {
        return (this.schedule);
    }

    public void SetIsEvaluate(bool value)
    {
        this.isEvaluate = value;
    }

    public bool GetIsEvaluate()
    {
        return (isEvaluate);
    }

    public void SetisExam(bool value)
    {
        this.isExam = value;
    }

    public bool GetisExam()
    {
        return (isExam);
    }

    public void SetisRush(bool value)
    {
        this.isRush = value;
    }

    public bool GetisRush()
    {
        return (isRush);
    }

    public void SetWeek(int amount)
    {
        this.week = amount;
    }

    public int GetWeek()
    {
        return (this.week);
    }

    public void NextWeek(int amount)
    {
        this.week += amount;
    }

    public void SetDay(Day day)
    {
        this.day = day;
    }

    public Day GetDay()
    {
        return (this.day);
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
    /// 다음날 어떤 시간대에서부터 시작할지를 정해주는 함수
    /// </summary>
    /// <param name="schedule">시간대를 정하는 변수</param>

    public void NextDaySchedule(Schedule schedule)
    {
        NextDay(1);
        this.schedule = schedule;
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
