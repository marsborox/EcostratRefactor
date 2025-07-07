using System;

public class PlayerMain : Singleton<PlayerMain>
{
    public static new PlayerMain instance => Singleton<PlayerMain>.instance;

    public PlayerStatsNew playerStats;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        base.Awake();
        playerStats = GetComponent<PlayerStatsNew>();
    }

}
