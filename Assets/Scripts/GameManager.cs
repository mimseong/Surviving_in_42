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
    private int evalpoint = 2;
    private float precodingLevel = 0;
    private float prefortytwoLevel = 0;
    private int preclean = 100;
    private int prefriendship = 0;
    private int prestress = 0;
    private int presleep = 0;
    private string name;
    private Day day = Day.MON;
    private Schedule schedule = Schedule.MORNING;
    private Work work;
    private Condition condition = Condition.NORMAL;
    private Surprise events;
    private bool isExam = false;
    private bool isRush = false;
    private bool isMousePad = false;

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

    public Condition GetCondition()
    {
        return (this.condition);
    }

    public void SetCodingLevel(float codingLevel)
    {
        this.codingLevel = codingLevel;
    }

    public void SetPreCodingLv(float precodingLevel)
    {
        this.precodingLevel = precodingLevel;
    }

    public float GetCodingLevel()
    {
        return (this.codingLevel);
    }

    public float GetPrecodingLevel()
    {
        return (this.precodingLevel);
    }

    public void AddCodingLevel(float codingLevel)
    {
        this.precodingLevel = this.codingLevel;
        if (GetisMousePad() == true)
            this.codingLevel += codingLevel * 0.1f;
        if (condition == Condition.FEVER)
            this.codingLevel += codingLevel * 1.5f;
        else if (condition == Condition.SLEEPY)
            this.codingLevel += codingLevel * 0.5f;
        else
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

    public void SetPreFortytwoLevel(float prefortytwoLevel)
    {
        this.prefortytwoLevel = prefortytwoLevel;
    }

    public float GetFortytwoLevel()
    {
        return (this.fortytwoLevel);
    }

    public float GetPrefortytwoLevel()
    {
        return (this.prefortytwoLevel);
    }

    public void AddFortytwoLevel(float fortytwoLevel)
    {
        this.prefortytwoLevel = this.fortytwoLevel;
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

    public void SetPreclean(int preclean)
    {
        this.preclean = clean;
    }

    public int GetClean()
    {
        return (this.clean);
    }

    public int GetPreclean()
    {
        return (this.preclean);
    }

    public void AddClean(int clean)
    {
        this.preclean = this.clean;
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

    public void SetPrefriendship(int prefriendship)
    {
        this.prefriendship = prefriendship;
    }

    public int GetFriendship()
    {
        return (this.friendship);
    }

    public int GetPreFriendship()
    {
        return (this.prefriendship);
    }

    public void AddFriendship(int friendship)
    {
        this.prefriendship = this.friendship;
        if (this.condition == Condition.DIRTY)
            this.friendship -= friendship;
        else
            this.friendship += friendship;
        if (this.friendship > 100)
            this.friendship = 100;
        else if (this.friendship < 0)
            this.friendship = 0;
    }

    public void SetStress(int stress)
    {
        this.stress = stress;
    }

    public void SetPrestress(int prestress)
    {
        this.prestress = prestress;
    }

    public int GetStress()
    {
        return (this.stress);
    }

    public int GetPrestress()
    {
        return (this.prestress);
    }

    /// <summary>
    /// 상태에 따라 스트레스 수치를 조정합니다
    /// </summary>
    /// <param name="stress"></param>
    public void AddStress(int stress)
    {
        this.prestress = this.stress;
        if (stress > 0)
        {
            if (condition == Condition.FEVER)
                this.stress += stress / 2;
            else if (condition == Condition.HANGOVER)
                this.stress += (int)Mathf.Ceil((float)stress * 1.1f);
            else if (condition == Condition.TIRED)
                this.stress += stress * 2;
            else
                this.stress += stress;
        }
        else
            this.stress += stress;
        if (this.stress > 100)
            this.stress = 100;
        else if (this.stress < 0)
            this.stress = 0;
    }

    public void SetSleep(int sleep)
    {
        this.sleep = sleep;
    }

    public void SetPresleep(int presleep)
    {
        this.presleep = presleep;
    }

    public int GetSleep()
    {
        return (this.sleep);
    }

    public int GetPresleep()
    {
        return (this.presleep);
    }

    /// <summary>
    /// 상태에 따라 수치 변경
    /// </summary>
    /// <param name="sleep"></param>
    public void AddSleep(int sleep)
    {
        this.presleep = this.sleep;
        if (sleep > 0)
        {
            if (condition == Condition.FEVER)
                this.sleep += sleep / 2;
            else if (condition == Condition.HANGOVER)
                this.sleep += (int)Mathf.Ceil((float)sleep * 1.1f);
            else if (condition == Condition.TIRED)
                this.sleep += sleep * 2;
            else
                this.sleep += sleep;
        }
        else
            this.sleep += sleep;
        if(this.sleep > 100)
            this.sleep = 100;
        else if (this.sleep < 0)
            this.sleep = 0;
    }

    /// <summary>
    /// 수치에 따라 상태를 결정하는 함수
    /// </summary>
    public void DecideCondition()
    {
        this.condition = Condition.NORMAL;
        if (this.clean < 50)
            this.condition = Condition.DIRTY;
        if (this.sleep > 50)
            this.condition = Condition.SLEEPY;
        if (this.stress + this.sleep >= 120)
            this.condition = Condition.TIRED;
        if (this.work == Work.DRINKING)
            this.condition = Condition.HANGOVER;
        if (90 < Random.Range(0, 101))
            this.condition = Condition.FEVER;
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

    public void SetEvalPoint(int point)
    {
        this.evalpoint = point;
    }

    public void AddEvalPoint(int point)
    {
        this.evalpoint += point;
        if (this.evalpoint < 0)
            this.evalpoint = 0;
    }

    public int GetEvalPoint()
    {
        return (this.evalpoint);
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

    public void SetEvent(Surprise events)
    {
        this.events = events;
    }
    
    public Surprise GetEvent()
    {
        return (this.events);
    }

    public void SetisMousePad(bool value)
    {
        this.isMousePad = value;
    }

    public bool GetisMousePad()
    {
        return (this.isMousePad);
    }
}
