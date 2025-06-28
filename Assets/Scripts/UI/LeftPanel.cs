using UnityEngine;

public class LeftPanel : UI
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }
    void Update()
    {
        TrackStatProgressBars();
    }

    private void TrackStatProgressBars()
    {//will move this to some UI class we dont know yet??
        gameManager.followerIncomeSlider.maxValue = gameManager.followerIncomeInterval;
        gameManager.followerIncomeSlider.value = gameManager.followerIncomeTimer;

        gameManager.illegalityReductionSlider.maxValue = gameManager.illegalityReductionInterval;
        gameManager.illegalityReductionSlider.value = gameManager.illegalityTimer;

        gameManager.trashSlider.maxValue = gameManager.trashIncrementInterval;
        gameManager.trashSlider.value = gameManager.trashTimer;

        //gameManager.Upda
        Debug.Log("updating UI.LeftPanel");
    }
}
