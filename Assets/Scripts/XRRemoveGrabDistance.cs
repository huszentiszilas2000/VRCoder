using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRRemoveGrabDistance : MonoBehaviour
{
    public XRDirectInteractor xRDirectInteractor;
    public float distanceDetach = 0.2f;

    void Start()
    {
        xRDirectInteractor = GetComponent<XRDirectInteractor>();
    }

    void Update()
    {
        if (xRDirectInteractor.interactablesSelected.Count > 0)
        {
            if (Vector3.Distance(this.transform.position, xRDirectInteractor.interactablesSelected[0].transform.position) > distanceDetach)
            {
                xRDirectInteractor.interactionManager.CancelInteractableSelection(xRDirectInteractor.interactablesSelected[0]);
            }
        }
    }
}
