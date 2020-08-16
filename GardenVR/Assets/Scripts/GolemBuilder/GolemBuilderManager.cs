using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GolemBuilderManager : Singleton<GolemBuilderManager>
{
    Camera mainCamera;
    [SerializeField] GolemPartController golem = null;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    public void Trigger(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GolemSlot selected = null;
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (!UIHelper.Instance.IsPointerOverUIElement())
            {
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                   
                        Debug.Log(hit.collider.name);
                        if (hit.collider.gameObject.GetComponent<GolemSlot>())
                        {
                            selected = hit.collider.gameObject.GetComponent<GolemSlot>();
                            Debug.Log("Clicked On " + selected.part.ToString());
                            GolemBuilderUIManager.Instance.UpdateMenu(selected);
                        }
                    
                }
                else
                {
                    Debug.Log("Clicked On None");
                    GolemBuilderUIManager.Instance.DeselectPart();
                }
            }
        }
    }

    public void UpdatePart(GolemSlot currentpart, string meshNamePrefix)
    {
        golem.ChangeBodyPart(currentpart.part, meshNamePrefix);
    }
}
