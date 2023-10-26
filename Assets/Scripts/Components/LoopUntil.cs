using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopUntil : ComponentInside, IComponent
{
    public GameObject boolGameObject;
    public IEnumerator RunComponent()
    {
        if (insideCall == null)
            yield return null;

        //float lastTime = 0f;
        while(boolGameObject.GetComponent<IResultBoolean>().GetResult() == false )
        {
            StartCoroutine(insideCall.GetComponent<IComponent>().RunComponent());
            yield return new WaitForEndOfFrame();
            //Gyorsítás
            /*lastTime += Time.deltaTime;
            if (lastTime > 10f)
            {
                lastTime = 0f;
                yield return new WaitForEndOfFrame();
            }*/
        }
        if (nextCall != null)
            StartCoroutine(nextCall.GetComponent<IComponent>().RunComponent());

        yield return null;
    }
}
