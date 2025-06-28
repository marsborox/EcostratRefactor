using UnityEngine;
using UnityEngine.UI;


public class SpeedButtons_UI : MonoBehaviour,I_InitiateButton
{
    [SerializeField] Toggle _toggleX1;
    [SerializeField] Toggle _toggleX2;
    [SerializeField] Toggle _toggleX3;

    [SerializeField] GameManager _gameManager;
    [SerializeField] MainTimer _timeController;
    void Start()
    {
        ((I_InitiateButton)this).InitiateToggle(_toggleX1, MainTimer.instance.TimeX1);
        ((I_InitiateButton)this).InitiateToggle(_toggleX2, MainTimer.instance.TimeX2);
        ((I_InitiateButton)this).InitiateToggle(_toggleX3, MainTimer.instance.TimeX3);
        /*
        _toggleX2.isOn = true;

        Color color = _toggleX2.colors.selectedColor;
        _toggleX2.targetGraphic.CrossFadeColor(color, 0f, true, false);
        */
        /*_toggleX2.Select();
        EventSystem.current.SetSelectedGameObject(_toggleX1.gameObject);*/
    }
}
