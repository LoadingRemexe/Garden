using UnityEngine;

public class PachinkoPickup : MonoBehaviour
{
    PachinkoGame gameOwner;
    private void Start()
    {
        gameOwner = FindObjectOfType<PachinkoGame>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        gameOwner.AddPickup();
        Destroy(gameObject);
    }
}
