using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Placeable Data", menuName = "ScriptableObjectPlaceable")]
public class PlaceableData : ScriptableObject
{
    public string plotName;
    public Sprite icon;
    public Mesh seedModel;
    public Mesh buddingModel;
    public Mesh adolescentModel;
    public Mesh grownModel;
    public Mesh decayingModel;
    public float lifetime;
    public ePlaceableType placeableType;

    public enum ePlaceableType
    {
        DECORATION,
        HOME,
        GENERATOR
    }
}