using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class DeleteItem : MonoBehaviour
{
    private InputAction deleteInputLeft;
    private InputAction deleteInputRight;

    public XRDirectInteractor leftHandInteractor;
    public XRDirectInteractor rightHandInteractor;

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
        if (rightHandInteractor.interactablesSelected.Count == 0)
            return;

        DeleteHeldItem(rightHandInteractor.interactablesSelected[0].transform.gameObject);
    }

    public void DeleteItemLeft(InputAction.CallbackContext context)
    {
        if (leftHandInteractor.interactablesSelected.Count == 0)
            return;

        DeleteHeldItem(leftHandInteractor.interactablesSelected[0].transform.gameObject);
    }

    public void DeleteHeldItem(GameObject itemHeld)
    {
        Destroy(itemHeld.transform.root.gameObject);
    }

}
