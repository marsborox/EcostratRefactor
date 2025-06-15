using UnityEngine;

public class PlayerStatNew : MonoBehaviour
{
    public float statTimer;
    public float statTimeElapsed;
    public int statTreshold;
    public int statAmmount;
    public int statIncrement;

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
        StatAddTimer(ref statTimeElapsed,statTreshold,ref statAmmount,statIncrement);
    }
    void StatAddTimer(ref float timeElapsed,int treshold,ref int ammount,int increment)
    {
        statTimeElapsed +=TimeController.instance.elapsedDeltaTime;
        if (timeElapsed >= treshold)
        {
            //DoSound
            //display floatingText
            timeElapsed -= treshold;
            ChangeStat(ammount, increment);
        }
    }
    public virtual void ChangeStat(int i1, int i2) 
    { 
        
    }
}
