using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerStatsNew : MonoBehaviour
{
    [Header("BaseStats")]
    public float statTimer;
    public int statTreshold;
    public int statAmmount;
    public int statIncrement;

    [Header("Trash")]
    public float trashTimer;
    public int trashIncrementInterval;
    public int trashAmmount;
    public int trashIncrementAmmount;

    [Header("TrashIncrement")]
    public float trashIncrementTimer;
    public int trashIncrementTimerInterval;
    //public int trashIncrementAmmount_____;
    public int trashIncrement_increment;

    [Header("IncomeFromFollowers")]
    public float followerIncomeTimer;
    public int followerIncomeTimerInterval;
    public int followerIncomeAmmount;
    public int followerAmmount;

    [Header("Illegality")]
    public float illegalityTimer;
    public int illegalityTimerInterval;
    public int illegalityAmmount;
    public int illegalityIncrementAmmount;

    GameManager gameManager;//temporary because i dont want to type this much remove when Change stats fully migrated

    public void Start()
    {
        gameManager = GameManager.instance;

        //does not work in OnEnable (initialisaiton order?
        MyEventHandler.instance.OnDonationTimer += DonationIncome;
        MyEventHandler.instance.OnTrashTimer += ChangeTrash;
        MyEventHandler.instance.OnTrashIncrement += ChangeTrashIncrement;
        MyEventHandler.instance.OnFollowerIncome += ChangeFollowerIncome;
        MyEventHandler.instance.OnIllegalityTimer += ChangeIllegality;
    }
    public void Update()
    {

    }
    private void OnEnable()
    {
        if (MyEventHandler.instance == null)
        {
            Debug.Log("Event isntance null wtf? on enable");
        }
        else
        {
            Debug.Log("Event isntance not null wtf? on enable");
        }

    }
    private void OnDisable()
    {
        MyEventHandler.instance.OnDonationTimer -= DonationIncome;
        MyEventHandler.instance.OnTrashTimer -= ChangeTrash;
        MyEventHandler.instance.OnTrashIncrement -= ChangeTrashIncrement;
        MyEventHandler.instance.OnFollowerIncome -= ChangeFollowerIncome;
        MyEventHandler.instance.OnIllegalityTimer -= ChangeIllegality;
    }
    void AddStats()
    {

    }
    void StatAddTimerV2()
    {
        //StatAddTimer(ref statTimer,statTreshold,ref statAmmount,statIncrement);
    }
    void StatAddTimer()
    {
        statTimer += MainTimer.instance.elapsedDeltaTime;
        if (statTimer >= statTreshold)
        {
            //DoSound
            //display floatingText
            statTimer -= statTreshold;
            //ChangeStat(statAmmount, statIncrement);
        }
    }
    void StatAddTimer(ref float timer,int treshold,System.Action method)
    {
        timer += MainTimer.instance.elapsedDeltaTime;
        if (timer >= treshold)
        {
            timer = -treshold;
            method();
        }
    }
    void DonationIncome()
    {
        Spawner.instance.CreateBubble();
    }
    void ChangeFollowerIncome()
    {
        gameManager.ChangeStats(PlayerStat.Money, gameManager.followers);
        //move this to UI somewhere should be in update

    }
    void ChangeIllegality()
    {
        gameManager.ChangeStats(PlayerStat.Illegality, gameManager.illegalityIncrement);
        //move this to UI somewhere should be in update

    }
    void ChangeTrash()
    {
        gameManager.ChangeStats(PlayerStat.Trash, gameManager.trashIncrementAmount);
        //move this to UI somewhere should be in update

    }
    void ChangeTrashIncrement()
    {
        gameManager.ChangeStats(PlayerStat.TrashIncrement, gameManager.trashIncrement_increment);
    }

}
