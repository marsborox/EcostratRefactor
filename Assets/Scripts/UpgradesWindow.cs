using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesWindow : Singleton<UpgradesWindow>
{
    public static new UpgradesWindow instance => Singleton<UpgradesWindow>.instance;
    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        
        //instance = this;
        gameObject.SetActive(false);
    }
    public void ShowUpgradesWindow()
    {
        gameObject.SetActive(true);
        UpdateButtons();
    }
    public void UpdateButtons()
    {
        foreach (var item in GetComponentsInChildren<UpgradeButton>())
        {
            item.UpdateButton();
        }
    }
}
