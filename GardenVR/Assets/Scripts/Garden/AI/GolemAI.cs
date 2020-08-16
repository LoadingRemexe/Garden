using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class GolemAI : MonoBehaviour
{
    [Header("Model")]
    public Animator anim;
    GolemPartController partcontroller;

    [Header("Agent")]
    public NavMeshAgent nma;
    float sightDistance = 3.0f;
    float waitTimer = 1.0f;
    float waitMax = 5.0f;
    bool stopAtDestination = false;

    void Start()
    {
        partcontroller = GetComponent<GolemPartController>();
        partcontroller.Load();
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
