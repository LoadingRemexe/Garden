using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventoryManager : Singleton<PlayerInventoryManager>
{
    public int PachinkoPlays = 0;
    public Dictionary<PlaceableData, int> seeds = new Dictionary<PlaceableData, int>();
   // List<BodyPartData> PlayerInventory = new List<BodyPartData>();

    public void Start()
    {
        LoadInventory();
       
    }

    private void LoadInventory()
    {
        List<SaveData.InventoryItem> items = SaveManager.Instance.saveData.Items.ToList();

        if (items != null && items.Count() > 0)
        {
            foreach (PlaceableData placeable in WorldManager.Instance.placeableDatas)
            {
                SaveData.InventoryItem i = items.Where(e => e.itemName == placeable.plotName).First();
                if (i != null)
                {
                    seeds.Add(placeable, i.numItems);
                }
                else
                {
                    seeds.Add(placeable, 0);
                }
            }
        }
    }

    public void ResetInventory()
    {
        seeds.Clear();
        foreach (PlaceableData placeable in WorldManager.Instance.placeableDatas)
        {
            seeds.Add(placeable, 3);
        }
      //  PlayerInventory.Clear();
        PachinkoPlays = 3;
    }

    public void AddUnlockedPlot(PlaceableData newPlot)
    {
        seeds[newPlot]++;
    }


    public void RemoveSeed(PlaceableData newPlot)
    {
        seeds[newPlot]--;
    }

}
