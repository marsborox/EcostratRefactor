using System.Collections;
using TMPro;

using UnityEngine;

public class MainTimer : Singleton<MainTimer>
{
    public static new MainTimer instance => Singleton<MainTimer>.instance;
    
    public float elapsedDeltaTime = 0;
    public int timeSpeed = 1;
    public int pauseTimeSpeedReference = 1;
    public bool paused = true;
    

    [Header("TimeMeasure")]
    [SerializeField] public float daysLeft;
    [SerializeField] public float daysLeftMax = 1825;
    [SerializeField] private float _elapsedTime = 0;
    
    [SerializeField] private float _oneDayInSec;
    //[SerializeField] private int _dayCoeficient=365;

    [Header("StatTimers")]
    [SerializeField] public float donationIncomeTimer = 0;
    [SerializeField] public float donationIncomeInterval = 5;

    [SerializeField] public float followerIncomeTimer = 0;
    [SerializeField] public float followerIncomeInterval = 60;

    [SerializeField] public float illegalityTimer = 0;
    [SerializeField] public float illegalReductionInterval = 120;

    [SerializeField] public float trashTimer = 0;
    [SerializeField] public float trashTimerInterval = 3;

    [SerializeField] public float trashIncrementTimer = 0;
    [SerializeField] public float trashIncrementTimerInterval = 60;


    protected override void Awake()
    {
        base.Awake();
        //instance = this;//should be in stat but initialisation order... somestuff messed up

    }

    private void Start()
    {
        paused = true;//game is paused must click the button in tutorial to unpause - buzttons need to be reworked
        daysLeft = daysLeftMax;
    }
    private void Update()
    {
        if (paused)
            return;
        DoBasicTimeStuff();
        CheckIfGameTooLong();
        CalcAllTimers();
    }
    public void UnpauseGame()
    {
        timeSpeed = pauseTimeSpeedReference;
        paused = false;
    }

    public void PauseGame()
    {
        pauseTimeSpeedReference=timeSpeed;
        timeSpeed = 0;
        paused = true;
    }
    public void PauseGameToggle()
    {
        if (paused)
        {
            paused = false;
        }
        else 
        { 
            paused = true; 
        }
    }
    public IEnumerator DelayedPause()
    {
        yield return new WaitForSeconds(1);
        PauseGame();
    }
    public void TimeX1()
    {
        timeSpeed = 1;
    }
    public void TimeX2() 
    {
        timeSpeed = 2;
    }
    public void TimeX3() 
    {
        timeSpeed = 3;
    }
    public string GetTimeStamp()
    {
        System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(_elapsedTime);
        return string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
    }
    private void DoBasicTimeStuff()
    {
        elapsedDeltaTime = Time.deltaTime * timeSpeed;
        daysLeft -= elapsedDeltaTime;
        _elapsedTime += elapsedDeltaTime;
    }
    private void CalcAllTimers()
    {
        GenericTimerSpawner(ref donationIncomeTimer, donationIncomeInterval, MyEventHandler.instance.DonationTimerSpawnerEvent);
        GenericTimerSpawner(ref followerIncomeTimer, followerIncomeInterval, MyEventHandler.instance.FollowerIncomeTimerSpawner);
        GenericTimerSpawner(ref illegalityTimer, illegalReductionInterval, MyEventHandler.instance.IllegalityTimerSpawner);
        GenericTimerSpawner(ref trashTimer, trashTimerInterval, MyEventHandler.instance.TrashTimerSpawner);
        GenericTimerSpawner(ref trashIncrementTimer, trashIncrementTimerInterval, MyEventHandler.instance.TrashIncrementTimeSpawner);
    }


    private void GenericTimerSpawner(ref float timer, float treshold, System.Action method)
    {
        timer += elapsedDeltaTime;
        if (timer >= treshold)
        {
            timer -= treshold;
            method();
        }
    }

    private void CheckIfGameTooLong()
    {
        if (daysLeft <= 0)
        {
            SoundManager.instance.Defeat();
            GameManager.instance.GameOver("Your time to save planet Earth has just run out.",
                "Climate changes in the world are already so critical that it is impossible to continue your saving journey of planet Earth. PRO TIP: Gotta be faster next time! (Try to buy out some of Negotiation Perks to get more time!)");
        }
    }
}
