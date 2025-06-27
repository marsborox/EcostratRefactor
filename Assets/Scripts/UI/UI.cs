using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public void InitiateButton(Button button, System.Action method)
    {
        button.onClick.AddListener(delegate
        {
            method();
        });
        //boolUI = false;
    }

    public void InitiateButton<T>(Button button, System.Action<T> method, T value)
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
