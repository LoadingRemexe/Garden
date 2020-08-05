using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifetimedParticle : MonoBehaviour
{
    public float lifetime = 5.0f;

    void FixedUpdate()
    {
        lifetime -= Time.deltaTime;
        if (lifetime < 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
