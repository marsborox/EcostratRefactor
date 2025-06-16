using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerStatNew : MonoBehaviour
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
    public int trashIncrementAmmount_____;
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


    public void Start()
    {

    }
    public void Update()
    {

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
        statTimer += TimeController.instance.elapsedDeltaTime;
        if (statTimer >= statTreshold)
        {
            //DoSound
            //display floatingText
            statTimer -= statTreshold;
            //ChangeStat(statAmmount, statIncrement);
        }
    }
    void StatAddTimer(ref float timeElapsed,int treshold,ref int ammount,int increment,Action method)
    {
        statTimer +=TimeController.instance.elapsedDeltaTime;
        if (timeElapsed >= treshold)
        {
            //DoSound
            //display floatingText
            timeElapsed -= treshold;
            //method();
        }
    }

    void TestTEst()
    {
        TEstDamn(AddStats);
    }

    void TEstDamn(System.Action action)
    {
        //action;
        action();
    }
    void ChangeTrash()
    { 
        
    }
    void ChangeTrashIncrement()
    { 
    
    }
    void ChangeFollowerIncome()
    { 
    
    }
    void ChangeIllegality()
    { 
    
    }

}
