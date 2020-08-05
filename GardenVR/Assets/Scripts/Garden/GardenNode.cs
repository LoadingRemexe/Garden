using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenNode : MonoBehaviour
{
    public Placeable occupied = null;

    public bool isOccupied()
    {
        return (occupied != null);
    }
}
