using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ParentingItem : MonoBehaviour
{
    private InputAction ParentingInput;

    public XRDirectInteractor leftHandInteractor;
    public XRDirectInteractor rightHandInteractor;


    public GameObject gameObjectVariable;
    public GameObject parentObject;

    public InputActionAsset inputActions;

    void Start()
    {
        ParentingInput = inputActions.FindActionMap("XRI RightHand").FindAction("Parenting");
        ParentingInput.Enable();
        ParentingInput.performed += Parenting;
    }

    public void Parenting(InputAction.CallbackContext callbackContext)
    {
        if (leftHandInteractor.interactablesSelected.Count == 0 || rightHandInteractor.interactablesSelected.Count == 0)
            return;

        GameObject leftHeldObject = leftHandInteractor.interactablesSelected[0].transform.gameObject;
        GameObject rightHeldObject = rightHandInteractor.interactablesSelected[0].transform.gameObject;

        leftHandInteractor.interactionManager.CancelInteractableSelection(leftHandInteractor.interactablesSelected[0]);
        rightHandInteractor.interactionManager.CancelInteractableSelection(rightHandInteractor.interactablesSelected[0]);

        if (leftHeldObject.tag != "ParentGameObject")
        {
            GameObject parent = Instantiate(parentObject, new Vector3(leftHeldObject.transform.position.x, leftHeldObject.transform.position.y, leftHeldObject.transform.position.z), leftHeldObject.transform.rotation);
            leftHeldObject.transform.SetParent(parent.transform);
            rightHeldObject.transform.SetParent(parent.transform);
            parent.GetComponent<XRGrab>().colliders.Add(leftHeldObject.GetComponent<Collider>());
            parent.GetComponent<XRGrab>().colliders.Add(rightHeldObject.GetComponent<Collider>());
            parent.GetComponent<Rigidbody>().useGravity  = leftHeldObject.GetComponent<Rigidbody>().useGravity;
            parent.GetComponent<Rigidbody>().isKinematic = leftHeldObject.GetComponent<Rigidbody>().isKinematic;
            parent.GetComponent<XRGrab>().movementType = leftHeldObject.GetComponent<XRGrab>().movementType;
            Destroy(leftHeldObject.GetComponent<XRGrab>());
            Destroy(leftHeldObject.GetComponent<Rigidbody>());
            Destroy(rightHeldObject.GetComponent<XRGrab>());
            Destroy(rightHeldObject.GetComponent<Rigidbody>());
            parent.GetComponent<XRGrab>().interactionManager.UnregisterInteractable(parent.GetComponent<XRGrab>().GetComponent<IXRInteractable>());
            parent.GetComponent<XRGrab>().interactionManager.RegisterInteractable(parent.GetComponent<XRGrab>().GetComponent<IXRInteractable>());
            parent.name = leftHeldObject.name + "<>" + rightHeldObject.name;

            GameObject objectComponent = Instantiate(gameObjectVariable, parent.transform);
            objectComponent.transform.SetParent(null);
            objectComponent.GetComponent<GameObjectScript>().variableGameObject = parent;
            objectComponent.transform.position = new Vector3(objectComponent.transform.position.x, objectComponent.transform.position.y + 0.3f, objectComponent.transform.position.z);
        }
        else
        {
            rightHeldObject.transform.SetParent(leftHeldObject.transform);
            leftHeldObject.GetComponent<XRGrab>().colliders.Add(rightHeldObject.GetComponent<Collider>());
            Destroy(rightHeldObject.GetComponent<XRGrab>());
            Destroy(rightHeldObject.GetComponent<Rigidbody>());
            leftHeldObject.GetComponent<XRGrab>().interactionManager.UnregisterInteractable(leftHeldObject.GetComponent<XRGrab>().GetComponent<IXRInteractable>());
            leftHeldObject.GetComponent<XRGrab>().interactionManager.RegisterInteractable(leftHeldObject.GetComponent<XRGrab>().GetComponent<IXRInteractable>());
        }
    }
}
