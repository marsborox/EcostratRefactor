using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class News : Singleton<News>
{
    public TextMeshProUGUI textContent;
    public ScrollRect scrollRect;

    public static new News instance => Singleton<News>.instance;
    protected override void Awake()
    {
        base.Awake();
        //instance = this;
    }
    private void Start()
    {
        StartCoroutine(GameNewsCoroutine());
        StartCoroutine(IllegalityNewsCoroutine());
    }
    public void AddMessage(string message)
    {
        RadioSoundManager.instance.PlayRadioSound();
        textContent.text += "\n\n[" + GameManager.instance.GetTimeStamp() + "] " + message;
        Canvas.ForceUpdateCanvases();

        GetComponentInChildren<VerticalLayoutGroup>().CalculateLayoutInputVertical();
        GetComponentInChildren<ContentSizeFitter>().SetLayoutVertical();

        scrollRect.verticalNormalizedPosition = 0;
    }
    private IEnumerator GameNewsCoroutine()
    {
        yield return new WaitUntil(() => GameManager.instance.daysGameTimer< 1350);
    AddMessage("There are 273 days remaining. If you plan to save the Earth, you better get moving!");
        yield return new WaitUntil(() => GameManager.instance.daysGameTimer < 900);
    AddMessage("You have exactly half of the time remaining, exactly 182 and a half days. I don’t want to be smart, but I think you really should start making changes for the better if you haven’t realised it yet!");
        yield return new WaitUntil(() => GameManager.instance.daysGameTimer < 450);
    AddMessage("There are 91 days remaining. I don’t care how you want to calculate it, the important thing is that you understand we don’t have any time to waste anymore!");
        yield return new WaitUntil(() => GameManager.instance.daysGameTimer < 300);
    AddMessage("You have 60 days left, i.e. 2 months. Don't forget to check the upgrades for some more time, if needed.");
        yield return new WaitUntil(() => GameManager.instance.daysGameTimer < 150);
    AddMessage("One month remaining! Get moving, otherwise it will be not only Game Over, but also forget about the future of humanity on the Earth.");
        yield return new WaitUntil(() => GameManager.instance.daysGameTimer < 90);
    AddMessage("One week remaining. Garbage is flooding the cities. Doomsday is knocking on the door.");
        yield return new WaitUntil(() => GameManager.instance.daysGameTimer < 30);
    AddMessage("6 days and it’s all over. Thousands of dead fish suffocated are being washed up from the seas and the oceans. Do something about it!");
        yield return new WaitUntil(() => GameManager.instance.daysGameTimer < 15);
    AddMessage("Last rescue task - last 3 days. The whole world is infested with garbage, Doomsday is here!");
    }
    private IEnumerator IllegalityNewsCoroutine()
    {
        yield return new WaitUntil(() => GameManager.instance.illegality >= 20);
        News.instance.AddMessage("Your friend Johny has been summoned for questioning. Be careful so you don’t end up the same!");
        yield return new WaitUntil(() => GameManager.instance.illegality >= 40);
        News.instance.AddMessage("You have been summoned for questioning! No worries, you are well covered, so you are not at risk of any major problems.");
        yield return new WaitUntil(() => GameManager.instance.illegality >= 60);
        News.instance.AddMessage("Black BMWs start to appear suspiciously often around your apartment. It’s starting to look like the cops are watching us.");
        yield return new WaitUntil(() => GameManager.instance.illegality >= 80);
        News.instance.AddMessage("Breaking News! The Green Inc. - helping the planet or a criminal organisation?!");
    }
}
