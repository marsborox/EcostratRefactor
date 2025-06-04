using UnityEngine;
using UnityEngine.UI;

public class SpeedButtons_UI : MonoBehaviour,I_InitiateButton
{
    [SerializeField] Toggle _toggleX1;
    [SerializeField] Toggle _toggleX2;
    [SerializeField] Toggle _toggleX3;

    [SerializeField] GameManager _gameManager;
    void Start()
    {

        ((I_InitiateButton)this).InitiateToggle(_toggleX1,_gameManager.ChangeGameSpeed,1);
        ((I_InitiateButton)this).InitiateToggle(_toggleX2, _gameManager.ChangeGameSpeed, 2);
        ((I_InitiateButton)this).InitiateToggle(_toggleX3, _gameManager.ChangeGameSpeed, 3);
        _toggleX1.targetGraphic.color = _toggleX1.colors.selectedColor;
        _toggleX1.isOn = true;
    }
}
