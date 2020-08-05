using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionSFX : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        AudioManager.Instance.PlayDing();
    }
}
