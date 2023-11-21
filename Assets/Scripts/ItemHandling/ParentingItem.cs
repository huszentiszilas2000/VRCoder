using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ParentingItem : MonoBehaviour
{
    private InputAction ParentingInput;

    public GameObject leftHand;
    public GameObject rightHand;


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
        if (leftHand.GetComponent<XRDirectInteractor>().interactablesSelected.Count == 0 || rightHand.GetComponent<XRDirectInteractor>().interactablesSelected.Count == 0)
            return;

        GameObject leftHeldObject = leftHand.GetComponent<XRDirectInteractor>().interactablesSelected[0].transform.gameObject;
        GameObject rightHeldObject = rightHand.GetComponent<XRDirectInteractor>().interactablesSelected[0].transform.gameObject;

        leftHand.GetComponent<XRDirectInteractor>().interactionManager.CancelInteractableSelection(leftHand.GetComponent<XRDirectInteractor>().interactablesSelected[0]);
        rightHand.GetComponent<XRDirectInteractor>().interactionManager.CancelInteractableSelection(rightHand.GetComponent<XRDirectInteractor>().interactablesSelected[0]);

        if (leftHeldObject.transform.root.gameObject == leftHeldObject)
        {
            GameObject parent = Instantiate(parentObject, new Vector3(leftHeldObject.transform.position.x, leftHeldObject.transform.position.y, leftHeldObject.transform.position.z), Quaternion.identity);
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

        }
    }
}
