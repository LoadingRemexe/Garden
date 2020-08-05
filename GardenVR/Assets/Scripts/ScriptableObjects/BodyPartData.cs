using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Golem Body Part Data",menuName = "ScriptableObjectGolemPart")]
public class BodyPartData : ScriptableObject
{
    public string m_PartName = "";
    public string m_Desc = "";
    public bool m_available = false;
    public Mesh m_Model = null;
    public Material m_Material = null;
    public eSet m_set = eSet.NONE;
    public eLocation m_Location = eLocation.NONE;

    #region ENUMS
    public enum eSet
    {
        NONE,
        IRON,
        RUBY,
        STONE
    }

    public enum eLocation
    {
        NONE,
        LEFT_FOOT,
        LEFT_CALF,
        LEFT_THIGH,
        LEFT_HAND,
        LEFT_FOREARM,
        LEFT_UPPERARM,
        UPPERBODY,
        LOWERBODY,
        HEAD,
        RIGHT_UPPERARM,
        RIGHT_FOREARM,
        RIGHT_HAND,
        RIGHT_THIGH,
        RIGHT_CALF,
        RIGHT_FOOT
    }
    #endregion
}
