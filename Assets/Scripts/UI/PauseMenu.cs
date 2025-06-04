using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject window;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleWindow();
        }
    }
    public void ToggleWindow()
    {
        window.SetActive(!window.activeSelf);
        TimeController.instance.PauseGameToggle();
    }
    public void Quit()
    {
        Application.Quit();
    }
}
