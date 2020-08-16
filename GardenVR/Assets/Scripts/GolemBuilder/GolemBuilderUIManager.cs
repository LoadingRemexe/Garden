using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class GolemBuilderUIManager : Singleton<GolemBuilderUIManager>
{
    [SerializeField] TextMeshProUGUI currentMeshPrefixDislay = null;
    [SerializeField] GameObject SelectedDisplay = null;

    GolemSlot selectedPart = null;
    private List<string> partsavaliablebyprefix = null;
    private int indexOfPartbyPrefix = 0;
    private void Start()
    {
        SelectedDisplay.SetActive(false);
    }

    public void UpdateMenu(GolemSlot selectedPart)
    {
        partsavaliablebyprefix = new List<string> { "ChiseledGrey", "ChiseledLight", "Ruby" }; // change this to get from inventory;
        // Load avaliable peices for that location

        indexOfPartbyPrefix = partsavaliablebyprefix.IndexOf(selectedPart.currentPartName);
        UpdateSelectedText();
        SelectedDisplay.SetActive(true);
    }

    public void DeselectPart()
    {
        SelectedDisplay.SetActive(false);
        selectedPart = null;
        partsavaliablebyprefix = null;
        indexOfPartbyPrefix = 0;
    }


    public void LeftArrow()
    {
        indexOfPartbyPrefix--;
        if (indexOfPartbyPrefix < 0)
        {
            indexOfPartbyPrefix = partsavaliablebyprefix.Count - 1;
            SelectNewPart();
        }
    }

    public void RightArrow()
    {
        indexOfPartbyPrefix++;
        if (indexOfPartbyPrefix == partsavaliablebyprefix.Count)
        {
            indexOfPartbyPrefix = 0;
            SelectNewPart();
        }
    }

    public void SelectNewPart()
    {
        UpdateSelectedText();
        GolemBuilderManager.Instance.UpdatePart(selectedPart, partsavaliablebyprefix[indexOfPartbyPrefix]);
    }

    public void UpdateSelectedText()
    {
        currentMeshPrefixDislay.text = partsavaliablebyprefix[indexOfPartbyPrefix];
    }

}
