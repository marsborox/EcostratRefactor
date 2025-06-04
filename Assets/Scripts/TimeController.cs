using UnityEngine;

public class TimeController : MonoBehaviour
{
    public void TimeX0()
    { 
        Time.timeScale = 0f;
    }
    public void TimeX1()
    {
        Time.timeScale = 1f;
    }
    public void TimeX2() 
    {
        Time.timeScale = 2f;
    }
    public void TimeX3() 
    {
        Time.timeScale = 3f;
    }
}
