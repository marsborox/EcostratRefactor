using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SlidersAndValues_UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _daysLeftText;
    [SerializeField] private TextMeshProUGUI _illegalityText;
    [SerializeField] private TextMeshProUGUI _elapsedTimeText;
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private TextMeshProUGUI _followerText;
    [SerializeField] private TextMeshProUGUI _trashText;

    [SerializeField] private Slider _followerInomeSlider;
    [SerializeField] private Slider _illegalitySlider;
    [SerializeField] private Slider _trashSlider;
    [SerializeField] private Slider _daysLeftSlider;




    private GameManager _gameManager;//will eventually remove

    private void Start()
    {
        _gameManager = GameManager.instance;
    }
    private void Update()
    {
        //TrackStatProgressBars();
        SetAllSliders();
    }

    private void SetDaysLeftText()
    {
        
        //_illegalityText.text = playerStats.daysLeft;
    }
    private void SetIllegalityText()
    { 
    
    }
    private void SetElapsedTimeText() 
    {
        
    }
    void SetAllSliders()
    {
        SetSlider(ref _followerInomeSlider, MainTimer.instance.followerIncomeInterval, MainTimer.instance.followerIncomeTimer);
        SetSlider(ref _illegalitySlider, _gameManager.illegalCapacity, _gameManager.illegality);
        SetSlider(ref _trashSlider, MainTimer.instance.trashTimerInterval, MainTimer.instance.trashTimer);
        //SetSlider days left
    }
    void SetAllTexts()
    { 
    
    }
    private void SetSlider(ref Slider slider,float sliderMaxVal, float sliderVal)
    {
        slider.maxValue = sliderMaxVal;
        slider.value = sliderVal;
    }

    private void SetText(TextMeshProUGUI textField, int displayValue)
    {
        textField.text = displayValue.ToString();
    }

}
