using UnityEngine;
using UnityEngine.UI;


public class MainMenu_UI : MonoBehaviour, I_InitiateButton
{
    [SerializeField] Button _playButton;
    [SerializeField] Button _quitButton;
    
    void Start()
    {
        ((I_InitiateButton)this).InitiateButton(_playButton, Play);
        ((I_InitiateButton)this).InitiateButton(_playButton, Quit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Play()
    { 
        MySceneManager.instance.StartGame(); 
    }
    void Quit()
    {
        MySceneManager.instance.Quit();
    }
}
