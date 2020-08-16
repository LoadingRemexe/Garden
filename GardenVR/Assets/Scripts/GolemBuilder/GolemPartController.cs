using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GolemPartController : MonoBehaviour
{
    [SerializeField] public List<string> meshPrefixes = new List<string>(); // Taken from file names
    [SerializeField] List<Mesh> MeshList = new List<Mesh>();

    List<GolemSlot> GolemSlots = new List<GolemSlot>(); // Parts on model
    Dictionary<GolemSlot.eLocation, string> AssignedMeshes = new Dictionary<GolemSlot.eLocation, string>(); //Dictionary of assigned meshes by location and material prefix

    void Start()
    {
        GolemSlots = GetComponentsInChildren<GolemSlot>().ToList();
        Load();
    }

    public void ChangeBodyPart(GolemSlot.eLocation part, string meshNamePrefix)
    {
        GolemSlot slot = GolemSlots.Where(m => m.part == part).FirstOrDefault();
        Mesh mesh = MeshList.Where(m => m.name.Contains(meshNamePrefix) && m.name.ToUpper().Contains(part.ToString())).FirstOrDefault();
        
        if (slot && mesh)
        {
            slot.UpdateBodyData(mesh);
            SaveGolem();
        }
    }

    public void Load()
    {
        foreach (GolemSlot g in GolemSlots)
        {
            Mesh mesh = MeshList.Where(m => m.name.Contains(g.currentPartName) && m.name.ToUpper().Contains(g.part.ToString())).FirstOrDefault();
            if (mesh)
            {
                g.UpdateBodyData(mesh);
            }
        }

        //SaveManager.GolemSave savedGolem = SaveManager.Instance.saveData.golemSave;
        //if (SaveManager.Instance.saveData != null)
        //{
        //    foreach (SaveManager.GolemSave.GolemPair pair in savedGolem.pairs)
        //    {
        //        for (int i = 0; i < m_MeshList.Count; i++)
        //        {
        //            if (m_MeshList[i].GetComponent<BodyPart>().m_Location == (BodyPart.eLocation)pair.eLocation)
        //            {
        //                IEnumerable<BodyPart> partQuery =
        //                    from part in m_comprehensive
        //                    where part.m_Location == (BodyPart.eLocation)pair.eLocation && part.m_set == (BodyPart.eSet)pair.eSet
        //                    select part;
        //                m_MeshList[i].UpdateBodyData(partQuery.ToList().FirstOrDefault());
        //            }
        //        }
        //    }
        //}
    }

    public void SaveGolem()
    {
        //    SaveManager.SaveData save = new SaveManager.SaveData();
        //    save = SaveManager.Instance.saveData;
        //    List<SaveManager.GolemSave.GolemPair> saveGolem = new List<SaveManager.GolemSave.GolemPair>();
        //    foreach (GolemSlot slot in m_MeshList)
        //    {
        //        SaveManager.GolemSave.GolemPair savePair = new SaveManager.GolemSave.GolemPair((int)slot.m_set, (int)slot.m_Location);
        //        saveGolem.Add(savePair);
        //    }
        //    save.golemSave.pairs = saveGolem.ToArray();
        //    SaveManager.Instance.UpdateSavedData(save);
        //    SaveManager.Instance.UpdateSavedData(save);
        //    SaveManager.Instance.Save();
        //}
    }
}
