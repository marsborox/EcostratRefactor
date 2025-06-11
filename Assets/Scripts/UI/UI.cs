using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;



public class UI : MonoBehaviour
{

    public void InitiateButton(Button button, UnityAction method)
    {
        button.onClick.AddListener(delegate
        {
            method();
        });
        //boolUI = false;
    }

    public void InitiateButton<T>(Button button, UnityAction<T> method, T value)
    {
        button.onClick.AddListener(delegate
        {
            method(value);
        });
        //boolUI = false;
    }

    void MyAction()
    {
        Debug.Log("Hello!");
    }


    
}
