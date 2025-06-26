using UnityEngine;

public class PlayerStatUI : MonoBehaviour
{
    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.instance;
    }
    void Update()
    {
        TrackStatProgressBars();
    }

    void TrackStatProgressBars()
    {//will move this to some UI class we dont know yet??
        gameManager.followerIncomeSlider.maxValue = gameManager.followerIncomeInterval;
        gameManager.followerIncomeSlider.value = gameManager.followerIncomeTimer;

        gameManager.illegalityReductionSlider.maxValue = gameManager.illegalReductionInterval;
        gameManager.illegalityReductionSlider.value = gameManager.illegalityTimer;

        gameManager.trashSlider.maxValue = gameManager.trashIncrementInterval;
        gameManager.trashSlider.value = gameManager.trashTimer;
        //gameManager.Upda
        Debug.Log("updating UI");
    }
}
