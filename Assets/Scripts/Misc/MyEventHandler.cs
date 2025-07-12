using UnityEngine;

public class MyEventHandler : Singleton<MyEventHandler>
{
    public static new MyEventHandler instance => Singleton<MyEventHandler>.instance;

    public delegate void StatChangeEvent();
    public event StatChangeEvent OnStatChange;
    public event StatChangeEvent OnDonationTimer;
    public event StatChangeEvent OnFollowerIncome;
    public event StatChangeEvent OnIllegalityTimer;
    public event StatChangeEvent OnTrashTimer;
    public event StatChangeEvent OnTrashIncrement;

    public delegate void StatChangeEventInput(float inputModifier);
    public event StatChangeEventInput OnFollowerChangeInput;
    public event StatChangeEventInput OnPopUpInput;
    public event StatChangeEventInput OnChangeDaysRemainingInput;
    public event StatChangeEventInput OnTrashChangeInput;
    public event StatChangeEventInput OnTrashIncrementInput;
    public event StatChangeEventInput OnChangeHintAmmountInput;
    public event StatChangeEventInput OnPriceModifierInput;
    
    private void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }


    #region Events no input

    public void DonationTimerSpawnerEvent()
    {
        OnDonationTimer?.Invoke();
        Debug.Log(" donation event Invoked");
    }
    public void FollowerIncomeTimerSpawner()
    {        
        OnFollowerIncome?.Invoke();
        Debug.Log(" follower event Invoked");
    }
    public void IllegalityTimerSpawner()
    {        
        OnIllegalityTimer?.Invoke();
        Debug.Log(" illegality event Invoked");
    }
    public void TrashTimerSpawner()
    {        
        OnTrashTimer?.Invoke();
        Debug.Log(" trash event Invoked");
    }
    public void TrashIncrementTimeSpawner()
    {        
        OnTrashIncrement?.Invoke();
        Debug.Log(" trash increment event Invoked");
    }
    #endregion

    #region Events w Inputs
    public void FollowerChangeInputEvent(float inputModifier)
    {
        OnFollowerChangeInput?.Invoke(inputModifier);
    }
    public void PopUpInputEvent(float inputModifier)
    { 
        OnPopUpInput?.Invoke(inputModifier);        
    }
    public void ChangeDaysRemainingInputEvent(float inputModifier)
    {
        OnChangeDaysRemainingInput?.Invoke(inputModifier);
    }

    public void TrashChangeInputEvent(float inputModifier)
    {
        OnTrashChangeInput?.Invoke(inputModifier);
    }
    public void TrashIncrementChangeInputEvent(float inputModifier)
    {
        OnTrashIncrementInput?.Invoke(inputModifier);
    }
    public void HintInputEvent(float inputModifier)
    {
        OnChangeHintAmmountInput?.Invoke(inputModifier);
    }
    public void PriceModifierInputEvent(float inputModifier)
    {
        OnPriceModifierInput?.Invoke(inputModifier);
    }

    #endregion

}
