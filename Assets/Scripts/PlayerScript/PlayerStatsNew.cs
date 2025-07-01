using UnityEngine;
using System;
using UnityEngine.UI;
using System.Threading.Tasks;

public class PlayerStatsNew : MonoBehaviour
{

    [Header("Trash")]
    [SerializeField] private int _initialTrash = 10000;
    public int trashAmmount;//set in start
    public int trashIncrementAmmount=10;
    public int trashCapacity = 20000;

    [Header("TrashIncrement")]
        //public int trashIncrementAmmount_____;
    public int trashIncrement_increment =5;

    [Header("IncomeFromFollowers")]
    //public int followerIncomeAmmount;
    public int followerAmmount;
    [Header("Money")]

    public int initialMoney = 500;
    public int moneyCurrent;//set in start
    [SerializeField] private int _incomeFromPopUps;

    [Header("Illegality")]
    public int illegalityAmmount;
    [SerializeField] private int _illegalityIncrementAmmount = -5;
    public int illegalityMax = 100;
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



    private void StatAddTimer(ref float timer,int treshold,System.Action method)
    {
        timer += MainTimer.instance.elapsedDeltaTime;
        if (timer >= treshold)
        {
            timer = -treshold;
            method();
        }
    }
    private void DonationIncome()
    {
        Spawner.instance.CreateBubble();
    }
    private void ChangePopUpIncome()
    {
        moneyCurrent += _incomeFromPopUps;
        if (moneyCurrent < 0)
            moneyCurrent = 0;
        Spawner.instance.SpawnTextSpecific(SpawnedStatTextType.MONEY, _incomeFromPopUps);

        foreach (var item in FindObjectsOfType<UpgradeButton>(true))
        {//this should be done on open in / update of UpgradeUI
            if (moneyCurrent >= item.currentUpgradeInfo.price)
            {
                GameManager.instance.upgradeBTNAnimator.SetTrigger("Highlight");
                break;
            }
        }
    }
    private void ChangeFollowerAmmount(int incrementOfFollowers)
    {
        followerAmmount += incrementOfFollowers;
        if (followerAmmount < 0)
            followerAmmount = 0;
        Spawner.instance.SpawnTextSpecific(SpawnedStatTextType.FOLLOWER, incrementOfFollowers);
    }
    private void ChangeFollowerIncome()
    {

        moneyCurrent += followerAmmount;
        if (moneyCurrent < 0)
            moneyCurrent = 0;
        Spawner.instance.SpawnTextSpecific(SpawnedStatTextType.MONEY, _incomeFromPopUps);

        foreach (var item in FindObjectsOfType<UpgradeButton>(true))
        {//this should be done on open in / update of UpgradeUI
            if (moneyCurrent >= item.currentUpgradeInfo.price)
            {
                GameManager.instance.upgradeBTNAnimator.SetTrigger("Highlight");
                break;
            }
        }
        gameManager.ChangeStats(PlayerStat.PopUpIncome, gameManager.followers);
        
    }
    void ChangeIllegality()
    {
        illegalityAmmount += _illegalityIncrementAmmount;
        if (illegalityAmmount < 0)
            illegalityAmmount = 0;

        Spawner.instance.SpawnTextSpecific(SpawnedStatTextType.ILLEGALITY, _illegalityIncrementAmmount);
        SoundManager.instance.Illegality();
        gameManager.ChangeStats(PlayerStat.Illegality, gameManager.illegalityIncrement);
        
    }
    void ChangeTrash()
    {
        trashAmmount += trashIncrementAmmount;
        if (trashIncrementAmmount > 0)
            for (int i = 0; i < trashIncrementAmmount; i++)
            {
                Spawner.instance.CreateTrashBubble();
            }
        else
            for (int i = 0; i > trashIncrementAmmount; i--)
            {
                Spawner.instance.RemoveTrashBubble();
            }
        Spawner.instance.SpawnTextSpecific(SpawnedStatTextType.TRASH, trashIncrementAmmount);
        if (trashAmmount < 0)
            trashAmmount = 0;

        gameManager.ChangeStats(PlayerStat.Trash, gameManager.trashIncrementAmount);
    }
    void ChangeTrashIncrement()
    {
        trashIncrementAmmount += trashIncrement_increment;
        //is this necessary?
        Spawner.instance.SpawnTextSpecific(SpawnedStatTextType.TRASH, trashIncrement_increment);
        gameManager.ChangeStats(PlayerStat.TrashIncrement, gameManager.trashIncrement_increment);
    }

    void ChangeStat(ref int stat, int modifier)
    {
        stat += modifier;
    }
}
