using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class CopyingItem : MonoBehaviour
{
    private InputAction CopyingInput;
    public InputActionAsset inputActions;

    public XRDirectInteractor leftHandInteractor;
    public XRDirectInteractor rightHandInteractor;

    public GameObject gameObjectVariable;

    void Start()
    {
        CopyingInput = inputActions.FindActionMap("XRI RightHand").FindAction("Parenting");
        CopyingInput.Enable();
        CopyingInput.performed += Copying;
    }

    void Copying(InputAction.CallbackContext callbackContext)
    {
        if (leftHandInteractor.interactablesSelected.Count != 0 && rightHandInteractor.interactablesSelected.Count != 0)
            return;

        if (leftHandInteractor.interactablesSelected.Count == 0 && rightHandInteractor.interactablesSelected.Count == 0)
            return;

        GameObject toCopy;
        if (leftHandInteractor.interactablesSelected.Count != 0)
        {
            toCopy = leftHandInteractor.interactablesSelected[0].transform.gameObject;
            leftHandInteractor.interactionManager.CancelInteractableSelection(leftHandInteractor.interactablesSelected[0]);
        }
        else
        {
            toCopy = rightHandInteractor.interactablesSelected[0].transform.gameObject;
            rightHandInteractor.interactionManager.CancelInteractableSelection(rightHandInteractor.interactablesSelected[0]);
        }
        if (toCopy.tag == "GameComponentNoCopy")
            return;

        GameObject copied = Instantiate(toCopy, new Vector3(toCopy.transform.position.x + 0.5f, toCopy.transform.position.y, toCopy.transform.position.z), toCopy.transform.rotation);

        if (copied.tag != "GameComponent")
        {
            GameObject objectComponent = Instantiate(gameObjectVariable, copied.transform.position, copied.transform.rotation);
            objectComponent.GetComponent<GameObjectScript>().variableGameObject = copied;
            objectComponent.transform.position = new Vector3(objectComponent.transform.position.x, objectComponent.transform.position.y + 0.5f, objectComponent.transform.position.z);

        }
    }
}
