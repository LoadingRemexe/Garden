using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

//C:\Users\Rowan Remy\AppData\LocalLow
//https://www.youtube.com/watch?v=BPu3oXma97Y
public class SaveManager : Singleton<SaveManager>
{
    public SaveData saveData;
    string dataFile = "506c6179657244617461.dat"; //"PlayerData" in hex

    private new void Awake()
    {
        base.Awake();
        Load();
    }
    private void Start()
    {
        Load();
    }

    #region Save Functions

    public void Save()
    {
        try
        {
            string filePath = Application.persistentDataPath + "/" + dataFile;
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            bf.Serialize(file, saveData);
            file.Close();
        }
        catch (Exception e)
        {
            Debug.Log("Error in Saving:" + e.Message);
        }
    }

    public void UpdateSavedData(SaveData newSave)
    {
        try
        {
            saveData = newSave;
        }
        catch (Exception e)
        {
            Debug.Log("Error in Updating save:" + e.Message);
        }
    }

    public void ResetSaveData()
    {
        saveData = new SaveData();
        try
        {
            string filePath = Application.persistentDataPath + "/" + dataFile;
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
            bf.Serialize(file, saveData);
            file.Close();
        }
        catch (Exception e)
        {
            Debug.Log("Error in Reset Saving:" + e.Message);
        }
    }

    public void Load()
    {
        string filePath = Application.persistentDataPath + "/" + dataFile;
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(filePath))
        {
            try
            {
                FileStream file = File.Open(filePath, FileMode.Open);
                SaveData loaded = (SaveData)bf.Deserialize(file);
                saveData = loaded;
                file.Close();

                if (saveData == null)
                {
                    Debug.Log("Reset Null Save On Load");
                    saveData = new SaveData();
                }
            }
            catch (Exception e)
            {
                Debug.Log("Error in Loading:" + e.Message);
                ResetSaveData();
            }
        }
        else
        {
            ResetSaveData();
            Debug.Log("Reset Save On Load");
        }
    }

    #endregion
}
