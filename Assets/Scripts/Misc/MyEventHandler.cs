using System.Data;

using UnityEngine;

public class MyEventHandler : Singleton<MyEventHandler>
{
    public static new MyEventHandler instance => Singleton<MyEventHandler>.instance;

    public delegate void StatChangeEvent();
    public event StatChangeEvent OnStatChange;
    public event StatChangeEvent OnDonationTimer;
    public event StatChangeEvent OnFollowerIncome;
    public event StatChangeEvent OnIllegalityTimer;
    public event StatChangeEvent OnTrashTimer;
    public event StatChangeEvent OnTrashIncrement;

    public int numberrrr; 
    private void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DonationTimerSpawnerEvent()
    {
        OnDonationTimer?.Invoke();
    }
    public void FollowerIncomeTimerSpawner()
    {
        OnFollowerIncome?.Invoke();
    }
    public void IllegalityTimerSpawner()
    {
        OnIllegalityTimer?.Invoke();
    }
    public void TrashTimerSpawner()
    {
        OnTrashTimer?.Invoke();
    }
    public void TrashIncrementTimeSpawner()
    {
        OnTrashIncrement?.Invoke();
    }
}
