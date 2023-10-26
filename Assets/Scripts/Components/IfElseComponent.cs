using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfElseComponent : ComponentInside, IComponent
{
    public GameObject boolGameObject;
    public IEnumerator RunComponent()
    {
        if ( insideCall == null || insideCall2 == null )
            yield return null;

        if (boolGameObject.GetComponent<IResultBoolean>().GetResult() == true)
            StartCoroutine(insideCall.GetComponent<IComponent>().RunComponent());
        else
            StartCoroutine(insideCall2.GetComponent<IComponent>().RunComponent());

        if ( nextCall != null )
            StartCoroutine(nextCall.GetComponent<IComponent>().RunComponent());

        yield return null;
    }
}
