using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorSeed : MonoBehaviour
{
    float waitTimer = 5.0f;
    public PlaceableData data;
    float speed = 0.0f;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        waitTimer -= Time.deltaTime;
        if (waitTimer <= 0.0f)
        {
            rb.useGravity = false;
            speed += Time.deltaTime;
            transform.position += Vector3.up * speed * Time.deltaTime;

            if (transform.position.y > 5.0f)
            {
              //  InventoryManager.Instance.AddUnlockedPlot(data);
                Destroy(gameObject);
            }
        }
        
    }
}
