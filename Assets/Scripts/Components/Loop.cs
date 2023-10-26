using System.Collections;
using System;
using UnityEngine;

public class Loop : ComponentInside, IComponent
{
    public GameObject variableGameObject;
    public IEnumerator RunComponent()
    {
        if (insideCall == null)
            yield return null;

        System.Object varObject = VisualCompiler.ConvertValueToCorrectObject(variableGameObject.GetComponent<IResult>().GetResult().ToString());
        Type type = varObject.GetType();
        if (type != typeof(int))
            yield return null;

        int leftOver = (int)varObject;
        if (leftOver < 0)
            yield return null;

        float lastTime = 0f;
        for (int i = 0; i < leftOver; i++)
        {
            StartCoroutine(insideCall.GetComponent<IComponent>().RunComponent());
            lastTime += Time.deltaTime;
            if (lastTime > 500f)
            {
                lastTime = 0f;
                yield return new WaitForEndOfFrame();
            }
        }

        if (nextCall != null)
            StartCoroutine(nextCall.GetComponent<IComponent>().RunComponent());

        yield return null;
    }
}
