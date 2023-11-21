using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class CopyingItem : MonoBehaviour
{
    private InputAction CopyingInput;

    public GameObject leftHand;
    public GameObject rightHand;


    public GameObject gameObjectVariable;

    public InputActionAsset inputActions;

    void Start()
    {
        CopyingInput = inputActions.FindActionMap("XRI RightHand").FindAction("Parenting");
        CopyingInput.Enable();
        CopyingInput.performed += Copying;
    }

    void Copying(InputAction.CallbackContext callbackContext)
    {
        if (leftHand.GetComponent<XRDirectInteractor>().interactablesSelected.Count != 0 && rightHand.GetComponent<XRDirectInteractor>().interactablesSelected.Count != 0)
            return;

        if (leftHand.GetComponent<XRDirectInteractor>().interactablesSelected.Count == 0 && rightHand.GetComponent<XRDirectInteractor>().interactablesSelected.Count == 0)
            return;

        GameObject toCopy;
        if (leftHand.GetComponent<XRDirectInteractor>().interactablesSelected.Count != 0)
        {
            toCopy = leftHand.GetComponent<XRDirectInteractor>().interactablesSelected[0].transform.gameObject;
            leftHand.GetComponent<XRDirectInteractor>().interactionManager.CancelInteractableSelection(leftHand.GetComponent<XRDirectInteractor>().interactablesSelected[0]);
        }
        else
        {
            toCopy = rightHand.GetComponent<XRDirectInteractor>().interactablesSelected[0].transform.gameObject;
            rightHand.GetComponent<XRDirectInteractor>().interactionManager.CancelInteractableSelection(rightHand.GetComponent<XRDirectInteractor>().interactablesSelected[0]);
        }
        GameObject copied = Instantiate(toCopy, new Vector3(toCopy.transform.position.x + 1f, toCopy.transform.position.y, toCopy.transform.position.z), toCopy.transform.rotation);

        GameObject objectComponent = Instantiate(gameObjectVariable, copied.transform.position, copied.transform.rotation);
        objectComponent.GetComponent<GameObjectScript>().variableGameObject = copied;
        objectComponent.transform.position = new Vector3(objectComponent.transform.position.x, objectComponent.transform.position.y + 0.5f, objectComponent.transform.position.z);
    }
}
