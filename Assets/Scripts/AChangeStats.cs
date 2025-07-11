using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Stat Change")]
public class AChangeStats : PlayerAction
{
    public PlayerStat stat;
    public float modifier;
    /*public override void Execute()
    {
        if (modifier < 0 && stat == PlayerStat.PopUpIncome)
            GameManager.instance.ChangeStats(stat, modifier * GameManager.instance.priceModifier);
        else
            GameManager.instance.ChangeStats(stat, modifier);
    }*/

    public override void SecondaryExecute()
    {
        GameManager.instance.ChangeStats(stat, -modifier);
    }

    public override bool TestExecute()
    {
        return GameManager.instance.TestChangeStats(stat, modifier);
    }
    public override void Execute()
    {
        switch (stat)
        {
            case PlayerStat.Followers:
                {
                    MyEventHandler.instance.FollowerChangeInputEvent(modifier);
                }
                break;
            case PlayerStat.PopUpIncome:
                {
                    MyEventHandler.instance.PopUpInputEvent(modifier);
                }
                break;
            case PlayerStat.Illegality:
                { 
                    //nothing
                }
                break;
            case PlayerStat.Timer: break;
            case PlayerStat.Trash:
                {
                    MyEventHandler.instance.TrashChangeInputEvent(modifier);
                }
                break;
            case PlayerStat.TrashIncrement:
                {
                    MyEventHandler.instance.TrashIncrementChangeInputEvent(modifier);
                }
                break;
            case PlayerStat.Hint:
                {
                    MyEventHandler.instance.HintInputEvent(modifier);
                }
                break;
            case PlayerStat.Donation: break;
            case PlayerStat.PriceModifier:
                {
                    MyEventHandler.instance.PriceModifierInputEvent(modifier);
                }
                break;
            case PlayerStat.TrashCapacity: break;
            case PlayerStat.IllegalityCapacity: break;
            case PlayerStat.IlegalityReductionInterval: break;
            default: break;
        }
    }
}
