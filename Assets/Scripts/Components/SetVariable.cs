using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetVariable : Component, IComponent
{
    public GameObject setVariableObject;
    public GameObject setterVariableObject;
    public IEnumerator RunComponent()
    {
        if (setVariableObject == null)
        {
            Debug.LogError("No set variable object connected !");
            yield return null;
        }

        if (setterVariableObject == null)
        {
            Debug.LogError("No setter object connected !");
            yield return null;
        }

        if (setVariableObject.GetComponent<VariableScript>() == null)
        {
            Debug.LogError("Wrong object attached!");
            yield return null;
        }

        setVariableObject.GetComponent<VariableScript>().variableValue = setterVariableObject.GetComponent<IResult>().GetResult().ToString();
        
        if (nextCall != null)
            StartCoroutine(nextCall.GetComponent<IComponent>().RunComponent());

        //yield return null;
    }

}
