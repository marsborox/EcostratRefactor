using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

public class SpeedButtons_UI : MonoBehaviour,I_InitiateButton
{
    [SerializeField] Toggle _toggleX1;
    [SerializeField] Toggle _toggleX2;
    [SerializeField] Toggle _toggleX3;

    [SerializeField] GameManager _gameManager;
    [SerializeField] TimeController _timeController;
    void Start()
    {
        ((I_InitiateButton)this).InitiateToggle(_toggleX1, TimeController.instance.TimeX1);
        ((I_InitiateButton)this).InitiateToggle(_toggleX2, TimeController.instance.TimeX2);
        ((I_InitiateButton)this).InitiateToggle(_toggleX3, TimeController.instance.TimeX3);
        /*
        _toggleX2.isOn = true;

        Color color = _toggleX2.colors.selectedColor;
        _toggleX2.targetGraphic.CrossFadeColor(color, 0f, true, false);
        */
        /*_toggleX2.Select();
        EventSystem.current.SetSelectedGameObject(_toggleX1.gameObject);*/
    }
}
