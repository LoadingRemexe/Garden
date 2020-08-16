using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemSlot : MonoBehaviour
{
    [SerializeField] public eLocation part = eLocation.NONE;
    public string currentPartName { get; private set; } = "";
    public Mesh currentMesh = null;

    public enum eLocation
    {
        _L_FOOT,
        _L_KNEE,
        _L_HIP,
        _L_HAND,
        _L_FOREARM,
        _L_SHOULDER,
        _CHEST,
        _WAIST,
        _HEAD,
        _R_SHOULDER,
        _R_FOREARM,
        _R_HAND,
        _R_HIP,
        _R_KNEE,
        _R_FOOT,
        NONE
    }

    public void UpdateBodyData(Mesh bodyPart)
    {
        if (bodyPart)
        {
            currentMesh = bodyPart;
            currentPartName = bodyPart.name.Substring(0, bodyPart.name.IndexOf('_'));
            GetComponent<MeshCollider>().sharedMesh = bodyPart;
            GetComponent<MeshFilter>().mesh = bodyPart;
        }
    }
}
