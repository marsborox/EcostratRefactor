using UnityEngine;

public class PlayerMain : Singleton<PlayerMain>
{
    public static new PlayerMain instance => Singleton<PlayerMain>.instance;

    public PlayerStatsNew playerStats;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        playerStats = GetComponent<PlayerStatsNew>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
