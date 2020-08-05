using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class GolemAI : MonoBehaviour
{
    [Header("Model")]
    public Animator anim;

    [Header("Agent")]
    public NavMeshAgent nma;
    float sightDistance = 3.0f;
    float waitTimer = 1.0f;
    float waitMax = 5.0f;
    bool stopAtDestination = false;

    [Header("Data")]
    public GolemSlot[] slots;
    public BodyPartData[] parts;

    void Start()
    {
        slots = FindObjectsOfType<GolemSlot>();
        LoadParts();
    }

    void LoadParts()
    {
        SaveData.GolemPair[] pairs = SaveManager.Instance.saveData.golemSave.pairs;
        if (pairs != null && pairs.Count() > 0)
        {
            foreach (SaveData.GolemPair pair in pairs)
            {
                BodyPartData part = parts.Where(p => p.m_Location == (BodyPartData.eLocation)pair.eLocation).FirstOrDefault();
                GolemSlot slot = slots.Where(s => s.bodyData.m_Location == (BodyPartData.eLocation)pair.eLocation).FirstOrDefault();
                if (part && slot)
                {
                    slot.UpdateBodyData(part);
                }
            }
        } else
        {
            foreach (GolemSlot slot in slots)
            {
                BodyPartData part = parts.Where(p => p.m_Location == slot.bodyData.m_Location && p.m_set == BodyPartData.eSet.STONE).FirstOrDefault();
                if (part && slot)
                {
                    slot.UpdateBodyData(part);
                }
            }
        }
    }

    void Update()
    {
        Wander();
        if (anim) anim.SetFloat("Speed", nma.velocity.magnitude);
    }

    #region Movement
    public void Wander()
    {
        if (nma.remainingDistance < nma.stoppingDistance)
        {
            if (!stopAtDestination)
            {
                waitTimer -= Time.deltaTime;
                if (waitTimer < 0.0f)
                {
                    waitTimer = Random.value * waitMax;
                    SetNewDestination();
                }
            }
        }
    }

    public void MoveToLocation(Vector3 destination, bool StopThere)
    {
        nma.SetDestination(destination);
        stopAtDestination = StopThere;
    }

    public void SetNewDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * sightDistance;
        randomDirection += transform.position;
        nma.SetDestination(randomDirection);
    }
    #endregion
}
