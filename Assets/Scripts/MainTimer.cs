using System.Collections;
using TMPro;

using UnityEngine;

public class MainTimer : Singleton<MainTimer>
{
    public static new MainTimer instance => Singleton<MainTimer>.instance;

    public float elapsedDeltaTime = 0;
    public int timeSpeed=1;
    public int pauseTimeSpeedReference=1;
    public bool paused = true;


    [Header ("Time")]

    [SerializeField] private float _daysRemaining = 1825;
    [SerializeField] private float _elapsedTime = 0;
    [SerializeField] TextMeshProUGUI elapsedTimeText;


    [Header ("StatTimers")]
    [SerializeField] private float _donationIncomeTimer = 0;
    [SerializeField] private float _donationIncomeInterval = 5;

    [SerializeField] private float _followerIncomeTimer = 0;
    [SerializeField] private float _followerIncomeInterval = 60;

    [SerializeField] private float _illegalityTimer = 0;
    [SerializeField] private float _illegalReductionInterval = 120;

    [SerializeField] private float _trashTimer = 0;
    [SerializeField] private float _trashTimerInterval = 3;

    [SerializeField] private float _trashIncrementTimer = 0;
    [SerializeField] private float _trashIncrementTimerInterval = 60;

    protected override void Awake()
    {
        base.Awake();
        //instance = this;//should be in stat but initialisation order... somestuff messed up

    }

    private void Start()
    {
        paused = true;//game is paused must click the button in tutorial to unpause - buzttons need to be reworked
    }
    private void Update()
    {
        if (paused)
            return;
        elapsedDeltaTime = Time.deltaTime*timeSpeed;
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
        System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(GameManager.instance.elapsedTime);
        return string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
    }
    private void CalcAllTimers()
    {
        GenericTimerSpawner(ref _donationIncomeTimer, _donationIncomeInterval, MyEventHandler.instance.DonationTimerSpawnerEvent);
        GenericTimerSpawner(ref _followerIncomeTimer, _followerIncomeInterval, MyEventHandler.instance.FollowerIncomeTimerSpawner);
        GenericTimerSpawner(ref _illegalityTimer, _illegalReductionInterval, MyEventHandler.instance.IllegalityTimerSpawner);
        GenericTimerSpawner(ref _trashTimer, _trashTimerInterval, MyEventHandler.instance.TrashTimerSpawner);
        GenericTimerSpawner(ref _trashIncrementTimer, _trashIncrementTimerInterval, MyEventHandler.instance.TrashIncrementTimeSpawner);
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
    
}
