using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlotManager : Singleton<PlotManager>
{
    [SerializeField] LayerMask groundLayer = 0;
    List<GardenNode> nodes = null;

    [SerializeField] GameObject homePlaceablePrefab = null;
    [SerializeField] GameObject decorationPlaceablePrefab = null;
    [SerializeField] GameObject generatorPlaceablePrefab = null;

    public void Start()
    {
        nodes = FindObjectsOfType<GardenNode>().ToList();
    }

    public Placeable CreateNewPlaceable(PlaceableData data, GardenNode pos)
    {
        Placeable newplace = null;
        if (data)
        {
            GameObject pref = null;
            switch (data.placeableType)
            {
                case PlaceableData.ePlaceableType.DECORATION:
                    pref = decorationPlaceablePrefab;
                    break;
                case PlaceableData.ePlaceableType.HOME:
                    pref = homePlaceablePrefab;
                    break;
                case PlaceableData.ePlaceableType.GENERATOR:
                    pref = generatorPlaceablePrefab;
                    break;
            }

            newplace = Instantiate(pref, pos.transform.position, Quaternion.Euler(0, Random.value * (360f), 0), WorldManager.Instance.WorldParent.transform).GetComponent<Placeable>();

            if (newplace)
            {
                newplace.placeableData = data;
                newplace.nodeOccupied = pos;
                pos.occupied = newplace;
            }
        }
        return newplace;
    }

}
