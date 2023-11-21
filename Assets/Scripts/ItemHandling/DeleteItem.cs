using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class DeleteItem : MonoBehaviour
{
    private InputAction deleteInputLeft;
    private InputAction deleteInputRight;

    public GameObject leftHand;
    public GameObject rightHand;

    public InputActionAsset inputActions;

    void Start()
    {
        deleteInputLeft = inputActions.FindActionMap("XRI LeftHand").FindAction("Delete");
        deleteInputRight = inputActions.FindActionMap("XRI RightHand").FindAction("Delete");
        deleteInputLeft.Enable();
        deleteInputRight.Enable();
        deleteInputLeft.performed += DeleteItemLeft;
        deleteInputRight.performed += DeleteItemRight;
    }


    public void DeleteItemRight(InputAction.CallbackContext context)
    {
        if (rightHand.GetComponent<XRDirectInteractor>().interactablesSelected.Count == 0)
            return;

        DeleteHeldItem(rightHand.GetComponent<XRDirectInteractor>().interactablesSelected[0].transform.gameObject);
    }

    public void DeleteItemLeft(InputAction.CallbackContext context)
    {
        if (leftHand.GetComponent<XRDirectInteractor>().interactablesSelected.Count == 0)
            return;

        DeleteHeldItem(leftHand.GetComponent<XRDirectInteractor>().interactablesSelected[0].transform.gameObject);
    }

    public void DeleteHeldItem(GameObject itemHeld)
    {
        Destroy(itemHeld.transform.root.gameObject);
    }

}
