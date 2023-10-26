using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfComponent : ComponentInside, IComponent
{
    public GameObject boolGameObject;
    public IEnumerator RunComponent()
    {
        if (insideCall == null)
            yield return null;

        if ( boolGameObject.GetComponent<IResultBoolean>().GetResult() == true )
            StartCoroutine(insideCall.GetComponent<IComponent>().RunComponent());

        if (nextCall != null)
            StartCoroutine(nextCall.GetComponent<IComponent>().RunComponent());

        yield return null;
    }
}
