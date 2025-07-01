using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : Singleton<GameManager>
{
    public static new GameManager instance => Singleton<GameManager>.instance;
    

    [Header ("Trash")]

    //[SerializeField] public float trashIncrementInterval = 3;
    [SerializeField] private float trash = 10000;//moved

    [SerializeField] public float trashIncrementAmount = 10;//moved
    public int trashIncrement_increment = 5;//moved
    public List<GameObject> trashBubbles = new();
    private float trashCapacity = 20000;//moved

    [Header ("Followers + PopUpIncome")]

    //private float donationIncomeInterval = 5;
    public float money = 500;//moved
    public float followers = 0;
    private float donation = 0;
    public float priceModifier = 1;

    [Header("Illegality")]
    //these 2 should/might be in time already_
    public float illegalityReductionInterval = 120;
    public int illegalityIncrement = -5;//moved

    [SerializeField] public float illegality = 0;//moved
    public int illegalCapacity = 100;//moved

    [Header ("Upgrades")]
    private int negotiationLevel = 0;
    private int socialSitesLevel = 0;
    private int riotsLevel = 0;
    private int socialEventsLevel = 0;
    private int oceanCleansingLevel = 0;
    private int hackingLevel = 0;
    private int bribeLevel = 0;
    private int blackmailLevel = 0;
    private int vandalismLevel = 0;
    private int landfillsLevel = 0;
    public float hints = 0;

    [Header("Prefabs")]
    public SpecialEventDatabase specialEventDatabase;
    public Texture2D mapSprite;
    public Button bubblePrefab;
    public GameObject trashBubblePrefab;
    public Event eventPrefab;
    public EventDatabase eventDatabase;
    public FloatingText floatingTextPrefab;
    public GameObject illegalityGameOverEvent;
    
    [Header("UI References")]
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI followerText;
    public TextMeshProUGUI trashText;
    public TextMeshProUGUI illegalityText;
    public Slider gameTimerSlider;
    public Slider illegalitySlider;
    public Slider trashSlider;
    public Slider followerIncomeSlider;
    public Slider illegalityReductionSlider;
    public Canvas mapCanvas;
    public Canvas interactiveCanvas;
    public GameOverScreen gameoverScreen;
    public TextMeshProUGUI dayText;
    public TextMeshProUGUI elapsedTimeText;
    public RectTransform followersFloatingText;
    public RectTransform moneyFloatingText;
    public RectTransform timeFloatingText;
    public RectTransform illegalityFloatingText;
    public RectTransform trashFloatingText;
    public Animator upgradeBTNAnimator;
    

    private void Awake()
    {
        base.Awake();
        //instance = this;
    }
    private void Start()
    {
        Canvas.GetDefaultCanvasMaterial().enableInstancing = true;
        foreach (var item in eventDatabase.events)
        {
            StartCoroutine(StartEventTimer(item, item.repeatTimes, false));
        }
        
        StartCoroutine(SpecialEventsCoroutine());
        //oneDayInSec = daysRemaining / 365;//going timer
        UpdateUI();
    }
    
    

    
    public void AddMoney()
    {
        ChangeStats(PlayerStat.PopUpIncome, UnityEngine.Random.Range(10, 51) + donation);
    }

    public void ChangeStats(PlayerStat stat, float modifier)
    {
        FloatingText text;
        switch (stat)
        {
            case PlayerStat.Followers:
                //moved
                followers += modifier;
                if (followers < 0)
                    followers = 0;
                Spawner.instance.SpawnTextSpecific(SpawnedStatTextType.FOLLOWER,modifier);
                /*
                text = Instantiate(floatingTextPrefab, followersFloatingText);
                text.UpdateText("<sprite=3>" + ((int)modifier).ToString("+#;-#;0"), modifier > 0, true);*/
                break;

            case PlayerStat.PopUpIncome:
                //moved
                money += modifier;
                if (money < 0)
                    money = 0;
                Spawner.instance.SpawnTextSpecific(SpawnedStatTextType.MONEY,modifier);
                /*
                text = Instantiate(floatingTextPrefab, moneyFloatingText);
                text.UpdateText("<sprite=1>" + ((int)modifier).ToString("+#;-#;0"), modifier > 0, true);
                */
                foreach (var item in FindObjectsOfType<UpgradeButton>(true))
                {//this should be done on open in / update of UpgradeUI
                    if (money >= item.currentUpgradeInfo.price)
                    {
                        upgradeBTNAnimator.SetTrigger("Highlight");
                        break;
                    }
                }
                break;

            case PlayerStat.Illegality:
                illegality += modifier;
                if (illegality < 0)
                    illegality = 0;
                
                Spawner.instance.SpawnTextSpecific(SpawnedStatTextType.ILLEGALITY, modifier);
                /*
                text = Instantiate(floatingTextPrefab, illegalityFloatingText);
                text.UpdateText("<sprite=4>" + ((int)modifier).ToString("+#;-#;0"), modifier < 0, true);
                */
                SoundManager.instance.Illegality();
                break;

            case PlayerStat.Timer:
                /*daysRemaining += modifier;
                Spawner.instance.SpawnTextSpecific(SpawnedStatTextType.TIME, modifier);*/
                /*
                text = Instantiate(floatingTextPrefab, timeFloatingText);
                text.UpdateText(((int)modifier).ToString("+#;-#;0") + " seconds", modifier > 0, false);
                */
                break;

            case PlayerStat.Trash:
                //moved
                trash += modifier;
                if (modifier > 0)
                    for (int i = 0; i < modifier; i++)
                    {
                        Spawner.instance.CreateTrashBubble();
                    }
                else
                    for (int i = 0; i > modifier; i--)
                    {
                        Spawner.instance.RemoveTrashBubble();
                    }
                Spawner.instance.SpawnTextSpecific(SpawnedStatTextType.TRASH, modifier);
                /*
                text = Instantiate(floatingTextPrefab, trashFloatingText);
                text.UpdateText("<sprite=0>" + ((int)modifier).ToString("+#;-#;0"), modifier < 0, true);
                */

                if (trash < 0)
                    trash = 0;
                break;

            case PlayerStat.TrashIncrement:
                //moved
                trashIncrementAmount += modifier;
                Spawner.instance.SpawnTextSpecific(SpawnedStatTextType.TRASH, modifier);
                
                //text = Instantiate(floatingTextPrefab, trashFloatingText);
                //text.UpdateText("<sprite=2>" + ((int)modifier).ToString("+#;-#;0"), modifier < 0, true);
                
                break;
/*
            case PlayerStat.TrashIncrementInterval:
                trashIncrementInterval += modifier;
                break;
*/

            case PlayerStat.Hint:
                hints += modifier;
                if (hints < 0)
                    hints = 0;
                break;

            case PlayerStat.Donation:
                donation += modifier;
                break;
                /* //not used
            case PlayerStat.DonationIntensity:
                donationIncomeInterval += modifier;
                if (donationIncomeInterval < 0.1)
                    donationIncomeInterval = 0.1f;
                break;*/

            case PlayerStat.PriceModifier:
                priceModifier += modifier;
                break;

            case PlayerStat.TrashCapacity:
                trashCapacity += modifier;
                break;

            case PlayerStat.IlegalityCapacity:
                illegalCapacity += (int)modifier;
                break;

            case PlayerStat.IlegalityReductionInterval:
                illegalityReductionInterval += modifier;
                break;

            default:
                break;
        }
        if (illegality >= illegalCapacity)
        {
            if (!illegalityGameOverEvent.activeInHierarchy)
            {
                illegalityGameOverEvent.SetActive(true);
                StartCoroutine(MainTimer.instance.DelayedPause());
            }
        }
        if (trash >= trashCapacity)
        {
            SoundManager.instance.Defeat();
            GameOver("DOOMSDAY - The world is flooded with garbage!",
                "The seas and oceans have returned to us what we have thrown into them all these years. People swim in the garbage that has flooded the streets of human dwellings. PRO TIP: It is important to make decisions that do not increase our garbage per interval too much, because that way we will get into a too large increase of garbage per day, which we will not be able to get rid of afterwards.");
        }
        if (trash <= 0)
        {
            SoundManager.instance.Victory();
            GameOver("All Clean!",
                "You managed to clear all the trash and made our planet a clean place again, where we can live together in harmony with nature as one complete humanity! Now is the time to rest and enjoy the success of your deeds for our planet!");
        }
        //UpdateUI();//*******************************************************
    }
    public bool TestChangeStats(PlayerStat stat, float modifier)
    {
        switch (stat)
        {
            case PlayerStat.PopUpIncome:
                if (money + (modifier * priceModifier) < 0)
                    return false;
                break;
            default:
                break;
        }
        
        return true;
    }
    public IEnumerator StartEventTimer(EventDataScriptable eventData, int repeatTimes, bool isRepeating)
    {
        float time;
        if (isRepeating)
            time = eventData.repeatInterval;
        else
            time = eventData.time;
        while (time > 0)
        {
            if (!MainTimer.instance.paused)
            time -= MainTimer.instance.elapsedDeltaTime;
            //time -= Time.deltaTime * speed;
            yield return null;
        }
        Event tempEvent = Instantiate(eventPrefab, interactiveCanvas.transform);
        if (eventData.mapPosition == Vector2.zero)
            tempEvent.GetComponent<RectTransform>().anchoredPosition = Spawner.instance.GetPointOnTerrain(false);
        else
            tempEvent.GetComponent<RectTransform>().anchoredPosition = eventData.mapPosition / 4;
        tempEvent.UpdateEvent(eventData);
        if (eventData.repeatInterval > 0 && repeatTimes > 0)
            StartCoroutine(StartEventTimer(eventData, repeatTimes - 1, true));
    }

    private IEnumerator SpecialEventsCoroutine()
    {
        float timer = 0;
        while (true)
        {
            if (!MainTimer.instance.paused)
            timer += MainTimer.instance.elapsedDeltaTime;
            //timer += Time.deltaTime * speed;
            if (timer >= 400)
            {
                Event tempEvent = Instantiate(eventPrefab, interactiveCanvas.transform);
                EventDataScriptable eventData = specialEventDatabase.GetRandomEvent();
                if (eventData.mapPosition == Vector2.zero)
                    tempEvent.GetComponent<RectTransform>().anchoredPosition = Spawner.instance.GetPointOnTerrain(false);
                else
                    tempEvent.GetComponent<RectTransform>().anchoredPosition = eventData.mapPosition / 4;
                tempEvent.UpdateEvent(eventData);
                timer = 0;
            }
            yield return null;
        }
    }
    public void UpgradePerk(UpgradeInfo info)
    {
        money -= info.price * priceModifier;
        foreach (var item in info.actions)
        {
            item.Execute();
        }
        switch (info.upgradeType)
        {
            case UpgradeType.Negotiation:
                negotiationLevel++;
                SoundManager.instance.Upgrade(negotiationLevel);
                break;
            case UpgradeType.SocialSites:
                socialSitesLevel++;
                SoundManager.instance.Upgrade(socialSitesLevel);
                break;
            case UpgradeType.Riots:
                riotsLevel++;
                SoundManager.instance.Upgrade(riotsLevel);
                break;
            case UpgradeType.SocialEvents:
                socialEventsLevel++;
                SoundManager.instance.Upgrade(socialEventsLevel);
                break;
            case UpgradeType.OceanCleansing:
                oceanCleansingLevel++;
                SoundManager.instance.Upgrade(oceanCleansingLevel);
                break;
            case UpgradeType.Hacking:
                hackingLevel++;
                SoundManager.instance.Upgrade(hackingLevel);
                break;
            case UpgradeType.Bribe:
                bribeLevel++;
                SoundManager.instance.Upgrade(bribeLevel);
                break;
            case UpgradeType.Blackmail:
                blackmailLevel++;
                SoundManager.instance.Upgrade(blackmailLevel);
                break;
            case UpgradeType.Vandalism:
                vandalismLevel++;
                SoundManager.instance.Upgrade(vandalismLevel);
                break;
            case UpgradeType.Landfills:
                landfillsLevel++;
                SoundManager.instance.Upgrade(landfillsLevel);
                break;
            default:
                break;
        }
        if (oceanCleansingLevel == 5)
        {
            SoundManager.instance.Victory();
            GameOver("Planet Earth is saved!",
                "You unlocked the last level of the ultimate perk Ocean Cleansing, through which you were able to get as many people necessary to clean all the nooks and crannies of the mixture of garbage in the seas and oceans, which was the biggest problem of the human race in the fight against garbage. Now is the time to rest and enjoy the success of your deeds for our planet!");
        }
        if (vandalismLevel == 5)
        {
            SoundManager.instance.Victory();
            GameOver("Planet Earth is saved!",
                "You have such a great influence on a huge group of your supporters that even the largest manufacturing companies are prying from your hand and are ready to submit to any measures that will help reduce their part of the blame for the pollution of our planet Earth.");
        }
    }

    public bool LegalUltimatePerkUnlocked()
    {
        return negotiationLevel == 5 && socialSitesLevel == 5 && riotsLevel == 5 && socialEventsLevel == 5;
    }
    public bool IllegalUltimatePerkUnlocked()
    {
        return hackingLevel == 5 && bribeLevel == 5 && blackmailLevel == 5 && landfillsLevel == 5;
    }
    public void GameOver(string label, string description)
    {
        gameoverScreen.UpdateTexts(label, description);
        RadioSoundManager.instance.StopPlaying();
        MainTimer.instance.paused = true;
    }
    public void MainMenu()
    {
        MySceneManager.instance.MainMenu();
    }
    public void UpdateUI()
    {
        Debug.Log("updating UI._gameManager");
        moneyText.text = ((int)money).ToString();
        followerText.text = followers.ToString();
        trashText.text = trash.ToString() + "/" + trashCapacity.ToString();
        /* //moved to sliderAndVlaues
        illegalitySlider.maxValue = illegalCapacity;
        illegalitySlider.value = illegality;
        illegalityText.text = illegality + "/" + illegalCapacity;
        */
    }
}

/*[Header ("Time")]
private float oneDayInSec;
public  float daysRemaining = 1825;
public float elapsedTime = 0;*/

/*private void Update()
    {
        if (MainTimer.instance.paused)
            return;
    }
    */
//TimerDisplay();

//daysRemaining -= MainTimer.instance.elapsedDeltaTime;//going timer
//gameTimer -= Time.deltaTime* speed;
//gameTimerSlider.value = daysRemaining;//going UI
//this section goes to timeControl
//dayText.text = (int)(daysRemaining / oneDayInSec) + " days left";


//******
//CalcAllTimers();
/*private void CalcAllTimers()
{
    GenericTimerSpawner(ref donationTimer,donationIncomeInterval,MyEventHandler.instance.DonationTimerSpawnerEvent);
    GenericTimerSpawner(ref followerIncomeTimer,followerIncomeInterval, MyEventHandler.instance.FollowerIncomeTimerSpawner);
    GenericTimerSpawner(ref illegalityTimer, illegalityReductionInterval, MyEventHandler.instance.IllegalityTimerSpawner);
    GenericTimerSpawner(ref trashTimer, trashIncrementInterval,MyEventHandler.instance.TrashTimerSpawner);
    GenericTimerSpawner(ref trashIncrementTimer, trashIncrementTimerInterval, MyEventHandler.instance.TrashIncrementTimeSpawner);
}
private void GenericTimerSpawner(ref float timer, float treshold, System.Action method)
{
    timer += MainTimer.instance.elapsedDeltaTime;
    if (timer >= treshold)
    {
        timer -=treshold;
        method();
    }
}*/
/*
private void TimerDisplay()
{
    //elapsedTime += MainTimer.instance.elapsedDeltaTime;

    elapsedTimeText.text = MainTimer.instance.GetTimeStamp();

}*/

/*
private IEnumerator DelayedPause(bool value)
{
yield return new WaitForSeconds(1);
PauseGameToggle(value);
}*/
/*
public void PauseGameToggle(bool value)
{
    paused = value;
}*/
/*
public void ChangeGameSpeed(int speed)
{
    TimeController.instance.timeSpeed=speed;
    //this.speed = speed;
    SoundManager.instance.Speed(speed);
}*/
/*
private IEnumerator GameNewsCoroutine()
{
    yield return new WaitUntil(() => gameTimer < 1350);
    News.instance.AddMessage("There are 273 days remaining. If you plan to save the Earth, you better get moving!");
    yield return new WaitUntil(() => gameTimer < 900);
    News.instance.AddMessage("You have exactly half of the time remaining, exactly 182 and a half days. I don’t want to be smart, but I think you really should start making changes for the better if you haven’t realised it yet!");
    yield return new WaitUntil(() => gameTimer < 450);
    News.instance.AddMessage("There are 91 days remaining. I don’t care how you want to calculate it, the important thing is that you understand we don’t have any time to waste anymore!");
    yield return new WaitUntil(() => gameTimer < 300);
    News.instance.AddMessage("You have 60 days left, i.e. 2 months. Don't forget to check the upgrades for some more time, if needed.");
    yield return new WaitUntil(() => gameTimer < 150);
    News.instance.AddMessage("One month remaining! Get moving, otherwise it will be not only Game Over, but also forget about the future of humanity on the Earth.");
    yield return new WaitUntil(() => gameTimer < 90);
    News.instance.AddMessage("One week remaining. Garbage is flooding the cities. Doomsday is knocking on the door.");
    yield return new WaitUntil(() => gameTimer < 30);
    News.instance.AddMessage("6 days and it’s all over. Thousands of dead fish suffocated are being washed up from the seas and the oceans. Do something about it!");
    yield return new WaitUntil(() => gameTimer < 15);
    News.instance.AddMessage("Last rescue task - last 3 days. The whole world is infested with garbage, Doomsday is here!");
}
private IEnumerator IllegalityNewsCoroutine()
{
    yield return new WaitUntil(() => illegality >= 20);
    News.instance.AddMessage("Your friend Johny has been summoned for questioning. Be careful so you don’t end up the same!");
    yield return new WaitUntil(() => illegality >= 40);
    News.instance.AddMessage("You have been summoned for questioning! No worries, you are well covered, so you are not at risk of any major problems.");
    yield return new WaitUntil(() => illegality >= 60);
    News.instance.AddMessage("Black BMWs start to appear suspiciously often around your apartment. It’s starting to look like the cops are watching us.");
    yield return new WaitUntil(() => illegality >= 80);
    News.instance.AddMessage("Breaking News! The Green Inc. - helping the planet or a criminal organisation?!");
}*/

#region moveToSpawn
/*
private void CreateBubble()
{
    Button bubbleInstance = Instantiate(bubblePrefab, interactiveCanvas.transform);
    bubbleInstance.GetComponent<RectTransform>().anchoredPosition = GetPointOnTerrain(false);
}
private void CreateTrashBubble()
{
    GameObject bubbleInstance = Instantiate(trashBubblePrefab, mapCanvas.transform);
    bubbleInstance.GetComponent<RectTransform>().anchoredPosition = GetPointOnTerrain(true);
    float random = UnityEngine.Random.Range(0.8f, 1.5f);
    bubbleInstance.GetComponent<RectTransform>().localScale = new Vector3(random, random, random);
    trashBubbles.Add(bubbleInstance);
}
private void RemoveTrashBubble()
{
    if (trashBubbles.Count > 0)
    {
        GameObject obj = trashBubbles[trashBubbles.Count - 1];
        trashBubbles.Remove(obj);
        Destroy(obj);
    }
}
private Vector2 GetPointOnTerrain(bool isTrashBubble)
{
    Vector2 targetPos;
    if (isTrashBubble)
        targetPos = new Vector2(UnityEngine.Random.Range(0, 1920), UnityEngine.Random.Range(0, 1080));
    else
        targetPos = new Vector2(UnityEngine.Random.Range(0, 1920 - 164), UnityEngine.Random.Range(0, 1080 - 253));

    Color color = mapSprite.GetPixel((int)targetPos.x * 4, (int)targetPos.y * 4);
    while (color.r >= 0.202 && color.r <= 0.206 && color.g >= 0.410 && color.g <= 0.414 && color.b >= 0.578 && color.b <= 0.582)    // Sea Color: R 204 G 412 B 480
    {
        if (isTrashBubble)
            targetPos = new Vector2(UnityEngine.Random.Range(0, 1920), UnityEngine.Random.Range(0, 1080));
        else
            targetPos = new Vector2(UnityEngine.Random.Range(0, 1920 - 164), UnityEngine.Random.Range(0, 1080 - 253));
        color = mapSprite.GetPixel((int)targetPos.x * 4, (int)targetPos.y * 4);
    }
    return targetPos;
}
private Vector2 GetPointOnWater()
{
    Vector2 targetPos = new Vector2(UnityEngine.Random.Range(0, mapCanvas.pixelRect.width), UnityEngine.Random.Range(0, mapCanvas.pixelRect.height));
    Color color = mapSprite.GetPixel((int)targetPos.x * 4, (int)targetPos.y * 4);
    while (!(color.r >= 0.202 && color.r <= 0.206 && color.g >= 0.410 && color.g <= 0.414 && color.b >= 0.578 && color.b <= 0.582))
    {
        targetPos = new Vector2(UnityEngine.Random.Range(0, mapCanvas.pixelRect.width), UnityEngine.Random.Range(0, mapCanvas.pixelRect.height));
        color = mapSprite.GetPixel((int)targetPos.x * 4, (int)targetPos.y * 4);
    }
    return targetPos;
}*/
#endregion
#region WhatWasInUpdate

/*
void Update2() 
{//this was in update

    DonationTimerSpawner();
    FollowerIncomeTimerSpawner();
    IllegalityTimerSpawner();
    TrashTimerSpawner();
    TrashIncrementTimeSpawner();

}
private void DonationTimerSpawner()
{
    donationTimer += TimeController.instance.elapsedDeltaTime;
    //donationTimer += Time.deltaTime * speed;
    if (donationTimer >= donationIntensity)
    {
        donationTimer -=donationIntensity;
        Spawner.instance.CreateBubble();
    }
}
private void FollowerIncomeTimerSpawner()
{
    followerIncomeTimer += TimeController.instance.elapsedDeltaTime;
    //followerIncomeTimer += Time.deltaTime * speed;

    if (followerIncomeTimer >= followerIncomeInterval)
    {
        SoundManager.instance.Income();

        followerIncomeTimer -= followerIncomeInterval;
        ChangeStats(PlayerStat.Money, followers);
    }
    followerIncomeSlider.maxValue = followerIncomeInterval;
    followerIncomeSlider.value = followerIncomeTimer;

}

private void IllegalityTimerSpawner()
{
        illegalityTimer += TimeController.instance.elapsedDeltaTime;
        //illegalityTimer += Time.deltaTime * speed;
        if (illegalityTimer >= illegalReductionInterval)
        {
            ChangeStats(PlayerStat.Illegality, illegalityIncrement);
            illegalityTimer -= illegalReductionInterval;
        }
        illegalityReductionSlider.maxValue = illegalReductionInterval;
        illegalityReductionSlider.value = illegalityTimer;
}

private void TrashTimerSpawner()
{
    //trashTimer += Time.deltaTime * speed;
    if (trashTimer >= trashIncrementInterval)
    {
        trashTimer += trashIncrementInterval;
        ChangeStats(PlayerStat.Trash, trashIncrementAmount);
    }
    //UI
    trashSlider.maxValue = trashIncrementInterval;
    trashSlider.value = trashTimer;
}



private void TrashIncrementTimeSpawner()
{
    trashIncrementTimer += TimeController.instance.elapsedDeltaTime;
    //trashIncrementAmountIncreaseTimer += Time.deltaTime * speed;
    if (trashIncrementTimer >= trashIncrementTimerInterval)
    {
        trashIncrementTimer -= trashIncrementTimerInterval;
        ChangeStats(PlayerStat.TrashIncrement, trashIncrement_increment);
    }
}*/
#endregion