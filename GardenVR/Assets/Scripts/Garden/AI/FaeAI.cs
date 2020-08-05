using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FaeAI : MonoBehaviour
{
    public enum eFaeType
    {
        FAIRY,
        BROWNIE,
        GNOME,
        PIXIE,
        WISP,
        GOBLIN
    }

    #region Variables
    [Header("Model")]
    public List<SkinnedMeshRenderer> clothing;
    public Animator anim;

    [Header("Agent")]
    public NavMeshAgent nma;
    public LayerMask navmeshAgentLayer;
    float sightDistance = 1.0f;
    float waitTimer = 1.0f;
    float waitMax = 5.0f;

    [Header("Needs")]
    public eFaeType faeType;
    public bool DaytimeOnly = true;
    public PlaceableHome home = null;
    //For simplicity, these will all be a scale of 0-100
    public float Happiness = 100.0f;
    #endregion

    void Start()
    {
        clothing[Random.Range(0, clothing.Count)].enabled = true;
    }

    void Update()
    {
       // if ((DaytimeOnly && DayAndNightControl.Instance.currentTime > 0.4) || (!DaytimeOnly && DayAndNightControl.Instance.currentTime < 0.6f))
        {
            Wander();
       // } else
       // {
           // ReturnHome();
        }

        if (anim) anim.SetFloat("Speed", nma.velocity.magnitude);

        if (!home) Happiness -= Time.deltaTime;
        if (Happiness < 0.0f) LeaveGarden();
    }

    #region Movement
    public void Wander()
    {
        if (nma.remainingDistance < nma.stoppingDistance)
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer < 0.0f)
            {
                waitTimer = Random.value * waitMax;
                SetNewDestination();
            }
        }
    }

    public void SetNewDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * sightDistance;
        randomDirection += transform.position;
        nma.SetDestination(randomDirection);
    }

    public void ReturnHome()
    {
        if (home)
        {
            nma.SetDestination(home.transform.position);
        } else
        {
            Wander();
        }
    }

    #endregion

    #region AI
    public void LeaveGarden()
    {
        WorldManager.Instance.ResidentFae.Remove(this);
    }

    #endregion
}
