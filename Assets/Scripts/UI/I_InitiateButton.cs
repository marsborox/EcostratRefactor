using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public interface I_InitiateButton
{
    public void InitiateButton(Button button, UnityAction method)
    {
        button.onClick.AddListener(delegate
        {
            method();
            SoundManager.instance.Click();
        });
        //boolUI = false;
    }/*
    public void InitiateButton(Button button, UnityAction method, UnityAction method2)
    {
        button.onClick.AddListener(delegate
        {
            method();
            method2();
            SoundManager.instance.Click();
        });
        //boolUI = false;
    }*/
    public void InitiateButton<T>(Button button, UnityAction<T> method, T value)
    {
        button.onClick.AddListener(delegate
        {
            method(value);
            SoundManager.instance.Click();
        });
        //boolUI = false;
    }
    public void InitiateToggle(Toggle toggle, UnityAction method)
    {
        toggle.onValueChanged.AddListener(delegate
        {
            method();
            SoundManager.instance.Click();
        });
        //boolUI = false;
    }
    public void InitiateToggle<T>(Toggle toggle, UnityAction<T> method, T value)
    {
        toggle.onValueChanged.AddListener(delegate
        {
            method(value);
            SoundManager.instance.Click();
        });
        //boolUI = false;
    }
}
