using UnityEngine;
using System;


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
    public int illegalityAmmount = 0;
    [SerializeField] private int _illegalityIncrementAmmount = -5;
    public int illegalityMax = 100;
    GameManager gameManager;//temporary because i dont want to type this much remove when Change stats fully migrated

    [Header("SecondaryStats")]

    [SerializeField] public int _hints = 0;
    [SerializeField] public int _donation = 0;//not sure if used
    [SerializeField] public float _priceModifier = 0;//might be int
    public void Start()
    {
        gameManager = GameManager.instance;


        SubscribeMethods();
        InitialTrashSpawn();
        moneyCurrent = initialMoney;

    }
    public void Update()
    {
        CheckIfGGameOver();
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
        UnsubscribeMethods();


    }


    private void SubscribeMethods()
    {

        //does not work in OnEnable (initialisaiton order?
        MyEventHandler.instance.OnDonationTimer += DonationIncome;
        MyEventHandler.instance.OnTrashTimer += ChangeTrash;
        MyEventHandler.instance.OnTrashIncrement += ChangeTrashIncrement;
        MyEventHandler.instance.OnFollowerIncome += ChangeFollowerIncome;
        MyEventHandler.instance.OnIllegalityTimer += ChangeIllegality;

        MyEventHandler.instance.OnFollowerChangeInput += ChangeFollowerAmmount;
        MyEventHandler.instance.OnPopUpInput += PopUpIncome;
        MyEventHandler.instance.OnTrashChangeInput += ChangeTrashInput;
        MyEventHandler.instance.OnTrashIncrementInput += ChangeTrashIncrementInput;
        MyEventHandler.instance.OnChangeHintAmmountInput += ChangeHint;

    }

    private void UnsubscribeMethods()
    {
        MyEventHandler.instance.OnDonationTimer -= DonationIncome;
        MyEventHandler.instance.OnTrashTimer -= ChangeTrash;
        MyEventHandler.instance.OnTrashIncrement -= ChangeTrashIncrement;
        MyEventHandler.instance.OnFollowerIncome -= ChangeFollowerIncome;
        MyEventHandler.instance.OnIllegalityTimer -= ChangeIllegality;

        MyEventHandler.instance.OnFollowerChangeInput -= ChangeFollowerAmmount;
        MyEventHandler.instance.OnPopUpInput -= PopUpIncome;
        MyEventHandler.instance.OnTrashChangeInput -= ChangeTrashInput;
        MyEventHandler.instance.OnTrashIncrementInput -= ChangeTrashIncrementInput;
        MyEventHandler.instance.OnChangeHintAmmountInput -= ChangeHint;

    }
    private void CheckIfGGameOver()
    {
        if (illegalityAmmount >= illegalityMax)
        {
            if (!gameManager.illegalityGameOverEvent.activeInHierarchy)
            {
                gameManager.illegalityGameOverEvent.SetActive(true);
                StartCoroutine(MainTimer.instance.DelayedPause());
            }
        }
        if (trashAmmount >= trashCapacity)
        {
            SoundManager.instance.Defeat();
            gameManager.GameOver("DOOMSDAY - The world is flooded with garbage!",
                "The seas and oceans have returned to us what we have thrown into them all these years. People swim in the garbage that has flooded the streets of human dwellings. PRO TIP: It is important to make decisions that do not increase our garbage per interval too much, because that way we will get into a too large increase of garbage per day, which we will not be able to get rid of afterwards.");
        }
        if (trashAmmount <= 0)
        {
            SoundManager.instance.Victory();
            gameManager.GameOver("All Clean!",
                "You managed to clear all the trash and made our planet a clean place again, where we can live together in harmony with nature as one complete humanity! Now is the time to rest and enjoy the success of your deeds for our planet!");
        }
    }
    private void InitialTrashSpawn()
    {
        for (int i = 0; i < _initialTrash; i++)
        {
            Spawner.instance.CreateTrashBubble();
            trashAmmount++;
        }
    }
    private void StatAddTimer(ref float timer,int treshold,System.Action method)
    {
        timer += MainTimer.instance.elapsedDeltaTime;
        if (timer >= treshold)
        {
            timer =- treshold;
            method();
        }
    }
    #region mainStats
    private void DonationIncome()
    {
        Spawner.instance.CreateBubble();
    }
    public void PopUpIncome()
    {//control this might be wrong
        moneyCurrent += UnityEngine.Random.Range(10, 51) + _incomeFromPopUps;
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
    private void ChangeIllegality()
    {
        illegalityAmmount += _illegalityIncrementAmmount;
        if (illegalityAmmount < 0)
            illegalityAmmount = 0;

        Spawner.instance.SpawnTextSpecific(SpawnedStatTextType.ILLEGALITY, _illegalityIncrementAmmount);
        SoundManager.instance.Illegality();
        //gameManager.ChangeStats(PlayerStat.Illegality, gameManager.illegalityIncrement);
        
    }
    private void ChangeTrash()
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
    private void ChangeTrashIncrement()
    {
        trashIncrementAmmount += trashIncrement_increment;
        //is this necessary?
        Spawner.instance.SpawnTextSpecific(SpawnedStatTextType.TRASH, trashIncrement_increment);
        gameManager.ChangeStats(PlayerStat.TrashIncrement, gameManager.trashIncrement_increment);
    }
    #endregion

    #region StatsWInput
    private void ChangeFollowerAmmount(float increment)
    {
        followerAmmount += (int)increment;
        if (followerAmmount < 0)
            followerAmmount = 0;
        Spawner.instance.SpawnTextSpecific(SpawnedStatTextType.FOLLOWER, increment);
    }
    private void PopUpIncome(float increment)
    {//control this might be wrong
        moneyCurrent += UnityEngine.Random.Range(10, 51) + (int)increment;
        if (moneyCurrent < 0)
            moneyCurrent = 0;
        Spawner.instance.SpawnTextSpecific(SpawnedStatTextType.MONEY, increment);

        foreach (var item in FindObjectsOfType<UpgradeButton>(true))
        {//this should be done on open in / update of UpgradeUI
            if (moneyCurrent >= item.currentUpgradeInfo.price)
            {
                GameManager.instance.upgradeBTNAnimator.SetTrigger("Highlight");
                break;
            }
        }
    }
    private void ChangeTrashInput(float increment)
    {

        trashAmmount += (int)increment;
        if ((int)increment > 0)
            for (int i = 0; i < (int)increment; i++)
            {
                Spawner.instance.CreateTrashBubble();
            }
        else
            for (int i = 0; i > (int)increment; i--)
            {
                Spawner.instance.RemoveTrashBubble();
            }
        Spawner.instance.SpawnTextSpecific(SpawnedStatTextType.TRASH, (int)increment);
        if (trashAmmount < 0)
            trashAmmount = 0;

        //gameManager.ChangeStats(PlayerStat.Trash, gameManager.trashIncrementAmount);
    }
    private void ChangeTrashIncrementInput(float increment)
    {
        trashIncrementAmmount += (int)increment;
        //is this necessary?
        Spawner.instance.SpawnTextSpecific(SpawnedStatTextType.TRASH, (int)increment);
        gameManager.ChangeStats(PlayerStat.TrashIncrement, (int)increment);
    }
    private void ChangeHint(float increment)
    {
        _hints += (int)increment;
        if (_hints < 0)
            _hints = 0;
    }
    private void ChangeDonation(float increment)
    {//not sure if used
        _donation += (int)increment;
    }
    private void ChangePriceModifier(float increment)
    { 
        _priceModifier += increment;
    }
    private void ChangeTrashCapatiy(float increment)
    {
        trashCapacity += (int)increment;
    }
    private void ChangeIllegalityMax(float increment)
    {//most prob not used
        illegalityMax += (int)increment;
    }

    void ChangeStat(ref int stat, float modifier)
    {
        stat += (int)modifier;
    }

    #endregion

}
