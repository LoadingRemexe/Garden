using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableGenerator : Placeable
{
    [SerializeField] GeneratorSeed generatorSeed = null;
    [SerializeField] Transform SeedDropLocation = null;
    public float ResetGeneratorTimer = 0.0f;
    float CurrentGeneratorTimer = 0.0f;

    new void FixedUpdate()
    {
        base.FixedUpdate();
        if (CurrentLifeStage == Placeable.ePlaceableLifeStage.GROWN)
        {
            CurrentGeneratorTimer -= Time.deltaTime * world.GrowthTimeScale;
        }
        if (CurrentGeneratorTimer <= 0.0f)
        {
            CurrentGeneratorTimer = ResetGeneratorTimer;
            generatorSeed.data = WorldManager.Instance.GetRandomPlaceableData();
            Instantiate(generatorSeed, SeedDropLocation, true);
        }
    }
}
