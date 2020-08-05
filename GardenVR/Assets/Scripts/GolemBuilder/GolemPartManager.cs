using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GolemPartManager : MonoBehaviour
{
    //[SerializeField] LayerMask GolemNodeLayer = 0;
    //[SerializeField] List<BodyPartData> Database = new List<BodyPartData>();

    List<GolemSlot> MeshList = new List<GolemSlot>();

    //BodyPartData.eLocation m_Location = BodyPartData.eLocation.NONE;
    //GolemSlot m_selectedPart = null;

    // Start is called before the first frame update
    void Start()
    {
        MeshList = FindObjectsOfType<GolemSlot>().ToList();
        Load();
        UpdateMesh();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = m_StoredCamera.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hitInfo;
        //    if (Physics.Raycast(ray, out hitInfo, 2000f, GolemNodeLayer))
        //    {
        //        Debug.Log(hitInfo.collider.name);
        //        if (hitInfo.collider.gameObject.GetComponent<GolemSlot>())
        //        {
        //            m_selectedPart = hitInfo.collider.gameObject.GetComponent<GolemSlot>();
        //            m_Location = m_selectedPart.bodyData.m_Location;

        //            //ChangeMenu();
        //        }
        //    }
        //}
    }

    public void ChangeBodyPart(BodyPartData part)
    {
        GolemSlot slot = MeshList.Where(m => m.bodyData.m_Location == part.m_Location).FirstOrDefault();
        if (part && slot)
        {
            slot.UpdateBodyData(part);
            SaveGolem();
        }

    }

    public void UpdateMesh()
    {
        BodyPartData inBodyPart = null;
        for (int i = 0; i < MeshList.Count; i++)
        {
            inBodyPart = MeshList[i].bodyData;
            if (inBodyPart)
            {
                MeshList[i].UpdateBodyData(inBodyPart);
            }
        }
    }

    public void Load()
    {
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
