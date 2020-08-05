using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableDecoration : Placeable
{
    public float FullHappinessBonus;
    public float CurrentHappinessBonus;

    new void FixedUpdate()
    {
        base.FixedUpdate();
        switch (CurrentLifeStage)
        {
            case ePlaceableLifeStage.SEED:
                CurrentHappinessBonus = FullHappinessBonus * 0.15f;
                break;
            case ePlaceableLifeStage.BUDDING:
                CurrentHappinessBonus = FullHappinessBonus * 0.5f;
                break;
            case ePlaceableLifeStage.ADOLESCENT:
                CurrentHappinessBonus = FullHappinessBonus * 0.8f;
                break;
            case ePlaceableLifeStage.GROWN:
                CurrentHappinessBonus = FullHappinessBonus * 1.0f;
                break;
            case ePlaceableLifeStage.DECAYING:
                CurrentHappinessBonus = FullHappinessBonus * -0.15f;
                break;
        }
    }
}
