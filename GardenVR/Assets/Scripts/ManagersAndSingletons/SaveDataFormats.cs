using UnityEngine;


[System.Serializable]
public class SaveData
{
    public int PachinkoPlays;
    public GolemSave golemSave;
    public FaeData[] faeFolk;
    public PlaceablesData[] placeables;
    public InventoryItem[] Items;
    public SaveData()
    {
        placeables = new PlaceablesData[0];
        faeFolk = new FaeData[0];
        golemSave = new GolemSave();
        Items = new InventoryItem[0];
        PachinkoPlays = 3;
    }

    [System.Serializable]
    public class SerializableVec3
    {
        public float x;
        public float y;
        public float z;
        public SerializableVec3()
        {
            x = 0;
            y = 0;
            z = 0;
        }
        public SerializableVec3(Vector3 pos)
        {
            x = pos.x;
            y = pos.y;
            z = pos.z;
        }
        public Vector3 ToVector()
        {
            return new Vector3(x, y, z);
        }
    }

    [System.Serializable]
    public class InventoryItem
    {
        public int numItems;
        public string itemName;

        public InventoryItem(int _NumItems, string _itemName)
        {
            numItems = _NumItems;
            itemName = _itemName;
        }
    }

    [System.Serializable]
    public class FaeData
    {
        public int FaeType;
        public float Happiness;
        public string HomeNode;

        public FaeData(float _Happiness, int _FaeType, string _HomeNode)
        {
            Happiness = _Happiness;
            FaeType = _FaeType;
            HomeNode = _HomeNode;
        }
    }

    [System.Serializable]
    public class PlaceablesData
    {
        public float CurrentLifeTime;
        public string plotName;
        public string NodeName;

        public PlaceablesData(float _CurrentLifeTime, string _PlotName, string _NodeName)
        {
            CurrentLifeTime = _CurrentLifeTime;
            plotName = _PlotName;
            NodeName = _NodeName;
        }
    }


    [System.Serializable]
    public class GolemSave
    {
        public GolemPair[] pairs;
        public GolemSave()
        {
            pairs = new GolemPair[0];
        }
        public GolemSave(GolemPair[] _pairs)
        {
            pairs = _pairs;
        }
    }

    [System.Serializable]
    public class GolemPair
    {
        public int eSet;
        public int eLocation;
        public GolemPair(int set, int location)
        {
            eSet = set;
            eLocation = location;
        }
    }
}

