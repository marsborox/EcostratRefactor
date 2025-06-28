using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TopAndBotBars_UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _daysLeftText;
    [SerializeField] private TextMeshProUGUI _illegalityText;
    [SerializeField] private TextMeshProUGUI _elapsedTimeText;

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
        var mainTimer = MainTimer.instance;

        SetSlider(ref _followerInomeSlider, mainTimer.followerIncomeInterval,mainTimer.followerIncomeTimer);
        SetSlider(ref _illegalitySlider, mainTimer.illegalReductionInterval, mainTimer.illegalityTimer);
        SetSlider(ref _trashSlider, mainTimer.trashTimerInterval, mainTimer.trashTimer);

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




    void TrackStatProgressBars()
    {//will move this to some UI class we dont know yet??
        _followerInomeSlider.maxValue = _gameManager.followerIncomeInterval;
        _followerInomeSlider.value = _gameManager.followerIncomeTimer;

        _illegalitySlider.maxValue = _gameManager.illegalityReductionInterval;
        _illegalitySlider.value = _gameManager.illegalityTimer;

        _trashSlider.maxValue = _gameManager.trashIncrementInterval;
        _trashSlider.value = _gameManager.trashTimer;



        //gameManager.Upda
        Debug.Log("updating UI.LeftPanel");
    }
}
