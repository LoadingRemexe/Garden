using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Placeable : MonoBehaviour
{
    #region Variables
    [SerializeField] public MeshFilter meshFilter;
    [SerializeField] public MeshCollider meshCollider;

    public GardenNode nodeOccupied = null;
    public PlaceableData placeableData;
    public float CurrentLifeTime = 15.0f;
    public ePlaceableLifeStage CurrentLifeStage = ePlaceableLifeStage.SEED;

    public enum ePlaceableLifeStage
    {
        SEED,
        BUDDING,
        ADOLESCENT,
        GROWN,
        DECAYING
    }

    protected WorldManager world;
    #endregion

    protected void Start()
    {
        world = WorldManager.Instance;
        if (CurrentLifeTime == -1.0f)
        {
            CurrentLifeTime = placeableData.lifetime;
        }
    }

    protected void FixedUpdate()
    {
        DecrimentLifetime();
    }

    public void DestroyPlaceable()
    {
        Destroy(gameObject);
    }

    #region Model Management

    protected void DecrimentLifetime()
    {
        CurrentLifeTime -= Time.deltaTime * world.GrowthTimeScale;
        if (CurrentLifeTime < 0.0f) // no life left
        {
            DestroyPlaceable();
        }
        else if (CurrentLifeTime < placeableData.lifetime * 0.1f) //down 90% - 100% of its life
        {
            CurrentLifeStage = ePlaceableLifeStage.DECAYING;
        }
        else if (CurrentLifeTime < placeableData.lifetime * 0.6f) //down 40% - 89$ of its life
        {
            CurrentLifeStage = ePlaceableLifeStage.GROWN;
        }
        else if (CurrentLifeTime < placeableData.lifetime * 0.8f) //down 20% - 39% of its life
        {
            CurrentLifeStage = ePlaceableLifeStage.ADOLESCENT;
        }
        else if (CurrentLifeTime < placeableData.lifetime * 0.9f) //down 10% - 19% of its life
        {
            CurrentLifeStage = ePlaceableLifeStage.BUDDING;
        }
        else //Down 0% - 9% of its life
        {
            CurrentLifeStage = ePlaceableLifeStage.SEED;
        }
        UpdateModel();
    }

    public void UpdateModel()
    {
        switch (CurrentLifeStage)
        {
            case ePlaceableLifeStage.SEED:
                meshFilter.mesh = placeableData.seedModel;
                meshCollider.sharedMesh = placeableData.seedModel;
                break;
            case ePlaceableLifeStage.BUDDING:
                meshFilter.mesh = placeableData.buddingModel;
                meshCollider.sharedMesh = placeableData.buddingModel;
                break;
            case ePlaceableLifeStage.ADOLESCENT:
                meshFilter.mesh = placeableData.adolescentModel;
                meshCollider.sharedMesh = placeableData.adolescentModel;
                break;
            case ePlaceableLifeStage.GROWN:
                meshFilter.mesh = placeableData.grownModel;
                meshCollider.sharedMesh = placeableData.grownModel;
                break;
            case ePlaceableLifeStage.DECAYING:
                meshFilter.mesh = placeableData.decayingModel;
                meshCollider.sharedMesh = placeableData.decayingModel;
                break;
        }
    }

    public void UpdateModel(ePlaceableLifeStage stage)
    {
        switch (stage)
        {
            case ePlaceableLifeStage.SEED:
                meshFilter.mesh = placeableData.seedModel;
                break;
            case ePlaceableLifeStage.BUDDING:
                meshFilter.mesh = placeableData.buddingModel;
                break;
            case ePlaceableLifeStage.ADOLESCENT:
                meshFilter.mesh = placeableData.adolescentModel;
                break;
            case ePlaceableLifeStage.GROWN:
                meshFilter.mesh = placeableData.grownModel;
                break;
            case ePlaceableLifeStage.DECAYING:
                meshFilter.mesh = placeableData.decayingModel;
                break;
        }
    }

    #endregion


}
