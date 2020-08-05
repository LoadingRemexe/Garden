using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemSlot : MonoBehaviour
{
    public BodyPartData bodyData = null;


    public void UpdateBodyData(BodyPartData bodyPart)
    {
        bodyData = bodyPart;
        if (bodyData)
        {
            GetComponent<MeshCollider>().sharedMesh = bodyData.m_Model;
            GetComponent<MeshFilter>().mesh = bodyData.m_Model;
        }
    }
}
