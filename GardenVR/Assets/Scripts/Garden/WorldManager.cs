using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WorldManager : Singleton<WorldManager>
{
    [Header("Variables")]
    [SerializeField] public GameObject WorldParent = null;
    public float GrowthTimeScale = 1.0f;

    [Header("Placeables")]
    [SerializeField] public PlaceableData[] placeableDatas = null;

    public List<Placeable> BuiltPlaceables = new List<Placeable>();

    [Header("Fae")]
    [SerializeField] public List<GameObject> FaePrefabs = null;
    public List<FaeAI> ResidentFae = new List<FaeAI>();

    public float averageHappiness = 0.0f;

    private void Start()
    {
        IEnumerator coroutine = CheckForAISpawn();
      //  StartCoroutine(coroutine);
        //Load();
    }
    private void Update()
    {
        averageHappiness = 0.0f;
        foreach (FaeAI fae in ResidentFae)
        {
            averageHappiness += fae.Happiness;
        }

        if (ResidentFae.Count != 0)
        {
            averageHappiness = averageHappiness / float.Parse(ResidentFae.Count.ToString());
        }

        //if (Input.GetKeyDown(KeyCode.S))
        //{
        ////    Save();
        //}

        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //   // InventoryManager.Instance.ResetInventory();
        //}
    }

    IEnumerator CheckForAISpawn()
    {
        while (true)
        {
            PlaceableHome[] h = FindObjectsOfType<PlaceableHome>().Where(e => !e.inhabited && e.CurrentLifeStage == Placeable.ePlaceableLifeStage.GROWN).ToArray();
            if (h.Length > 0)
            {
                FaeAI fae = Instantiate(FaePrefabs[Random.Range(0, FaePrefabs.Count)], h[0].transform.position, h[0].transform.rotation, WorldParent.transform).GetComponent<FaeAI>();
                fae.home = h[0];
                h[0].inhabited = true;
                ResidentFae.Add(fae);
            }
            yield return new WaitForSeconds(5.0f);
        }
    }

    public PlaceableData GetRandomPlaceableData()
    {
        return placeableDatas[Random.Range(0, placeableDatas.Length)];
    }
    public PlaceableData GetRandomPlaceableData(PlaceableData.ePlaceableType type)
    {
        return placeableDatas.Where(e => e.placeableType == type).ToArray()[Random.Range(0, placeableDatas.Length)];
    }
    public PlaceableData GetPlaceableData(string PlaceableName)
    {
        PlaceableData p = placeableDatas.Where(e => e.plotName.Contains(PlaceableName)).FirstOrDefault();
        if (!p) Debug.Log("Could not find Placeable with name:" + PlaceableName);
        return p;
    }


    #region Save And Load Functions
    //public void Save()
    //{
    //    SaveData save = SaveManager.Instance.saveData;
    //    //Update values
    //    List<SaveData.PlaceablesData> savePlaces = new List<SaveData.PlaceablesData>();
    //    foreach (Placeable place in FindObjectsOfType<Placeable>())
    //    {
    //        savePlaces.Add(new SaveData.PlaceablesData(place.CurrentLifeTime, place.placeableData.plotName, place.nodeOccupied.name));
    //    }
    //    save.placeables = savePlaces.ToArray();

    //    List<SaveData.FaeData> saveFae = new List<SaveData.FaeData>();
    //    foreach (FaeAI fae in ResidentFae)
    //    {
    //        saveFae.Add(new SaveData.FaeData(fae.Happiness, (int)fae.faeType, fae.home.nodeOccupied.name));

    //    }
    //    save.faeFolk = saveFae.ToArray();

    //    List<SaveData.InventoryItem> items = new List<SaveData.InventoryItem>();
    //    foreach (KeyValuePair<PlaceableData, int> seed in InventoryManager.Instance.seeds)
    //    {
    //        items.Add(new SaveData.InventoryItem(seed.Value, seed.Key.plotName));
    //    }
    //    save.Items = items.ToArray();
    //    SaveManager.Instance.UpdateSavedData(save);
    //    SaveManager.Instance.Save();
    //    Debug.Log("Saved");
    //}

    //private void Load()
    //{
    //    SaveData save = SaveManager.Instance.saveData;

    //    if (save.placeables != null && save.placeables.Count() > 0)
    //    {
    //        foreach (SaveData.PlaceablesData place in save.placeables)
    //        {
    //            GardenNode node = GameObject.Find(place.NodeName).GetComponent<GardenNode>();
    //            if (node && GetPlaceableData(place.plotName))
    //            {
    //                Placeable p = PlotManager.Instance.CreateNewPlaceableOnNode(GetPlaceableData(place.plotName), node);
    //                p.CurrentLifeTime = place.CurrentLifeTime;
    //                BuiltPlaceables.Add(p);
    //                node.placeable = p.gameObject;

    //            }
    //        }
    //    }
    //    if (save.faeFolk.Count() > 0)
    //    {
    //        foreach (SaveData.FaeData fae in save.faeFolk)
    //        {
    //            GardenNode node = GameObject.Find(fae.HomeNode).GetComponent<GardenNode>();
    //            if (node.placeable)
    //            {
    //                PlaceableHome home = node.placeable.GetComponent<PlaceableHome>();
    //                if (home)
    //                {
    //                    GameObject faeToCreate = FaePrefabs.Where(e => e.GetComponent<FaeAI>().faeType == (FaeAI.eFaeType)fae.FaeType).FirstOrDefault();
    //                    if (faeToCreate)
    //                    {
    //                        FaeAI faeInstance = Instantiate(faeToCreate, node.transform.position, node.transform.rotation, WorldParent.transform).GetComponent<FaeAI>();
    //                        faeInstance.home = home;
    //                        faeInstance.Happiness = fae.Happiness;
    //                        home.inhabited = true;
    //                        ResidentFae.Add(faeInstance);
    //                    }
    //                }
    //            }
    //        }
    //    }

    //}

    //private void OnApplicationQuit()
    //{
    //    //   Save();
    //}
    #endregion
}
