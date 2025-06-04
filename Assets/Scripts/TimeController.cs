using System.Collections;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public static TimeController instance;

    public float elapsedDeltaTime = 0;
    public int timeSpeed=1;
    public int pauseTimeSpeedReference;
    public bool paused = true;

    private void Awake()
    {
        instance = this;//should be in stat but initialisation order... somestuff messed up

    }
    private void Start()
    {
        paused = true;//game is paused must click the button in tutorial to unpause - buzttons need to be reworked
    }
    private void Update()
    {
        elapsedDeltaTime = Time.deltaTime*timeSpeed;
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
}
