using UnityEngine;
using UnityEngine.UI;


public class Tutorial_UI : MonoBehaviour, I_InitiateButton
{
    [SerializeField] Button _BeginBTN_Yes;
    [SerializeField] Button _BeginBTN_No;
    [SerializeField] Button _Tut1BTN;
    [SerializeField] Button _Tut2BTN;
    [SerializeField] Button _Tut3BTN;
    [SerializeField] Button _Tut4BTN;
    [SerializeField] Button _Tut5BTN;
    [SerializeField] Button _Tut6BTN;
    [SerializeField] Button _Tut7BTN;
    [SerializeField] Button _Tut8BTN;
    [SerializeField] Button _Tut9BTN;
    [SerializeField] Button _Tut10BTN;
    [SerializeField] Button _Tut11BTN;

    [SerializeField] GameObject _BeginTutorial;
    [SerializeField] GameObject _Tut1;
    [SerializeField] GameObject _Tut2;
    [SerializeField] GameObject _Tut3;
    [SerializeField] GameObject _Tut4;
    [SerializeField] GameObject _Tut5;
    [SerializeField] GameObject _Tut6;
    [SerializeField] GameObject _Tut7;
    [SerializeField] GameObject _Tut8;
    [SerializeField] GameObject _Tut9;
    [SerializeField] GameObject _Tut10;
    [SerializeField] GameObject _Tut11;

    void Start()
    {
        ((I_InitiateButton)this).InitiateButton(_BeginBTN_No, CloseTutorial,_BeginTutorial);
        ((I_InitiateButton)this).InitiateButton(_BeginBTN_Yes, NextTutorialWindow,_BeginTutorial,_Tut1);
        ((I_InitiateButton)this).InitiateButton(_Tut1BTN, NextTutorialWindow, _Tut1, _Tut2);
        ((I_InitiateButton)this).InitiateButton(_Tut2BTN, NextTutorialWindow, _Tut2, _Tut3);
        ((I_InitiateButton)this).InitiateButton(_Tut3BTN, NextTutorialWindow, _Tut3, _Tut4);
        ((I_InitiateButton)this).InitiateButton(_Tut4BTN, NextTutorialWindow, _Tut4, _Tut5);
        ((I_InitiateButton)this).InitiateButton(_Tut5BTN, NextTutorialWindow, _Tut5, _Tut6);
        ((I_InitiateButton)this).InitiateButton(_Tut6BTN, NextTutorialWindow, _Tut6, _Tut7);
        ((I_InitiateButton)this).InitiateButton(_Tut7BTN, NextTutorialWindow, _Tut7, _Tut8);
        ((I_InitiateButton)this).InitiateButton(_Tut8BTN, NextTutorialWindow, _Tut8, _Tut9);
        ((I_InitiateButton)this).InitiateButton(_Tut9BTN, NextTutorialWindow, _Tut9, _Tut10);
        ((I_InitiateButton)this).InitiateButton(_Tut10BTN, NextTutorialWindow, _Tut10, _Tut11);
        ((I_InitiateButton)this).InitiateButton(_Tut11BTN, CloseTutorial, _Tut11);
    }
    void NextTutorialWindow(GameObject closeUI, GameObject openUI) 
    {
        closeUI.SetActive(false);
        openUI.SetActive(true);
    }
    void CloseTutorial(GameObject closeUI)
    {
        closeUI.SetActive(false);
        MainTimer.instance.UnpauseGame();
    }
}