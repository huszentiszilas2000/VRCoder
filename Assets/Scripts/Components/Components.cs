using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Components : Component, IComponent
{
    [SerializeField]
    ComponentType componentType;

    ComponentConnectors componentConnectors;

    GameObject variableCorrectObject;
    GameObject secondvariableCorrectObject;
    GameObject booleanCorrectObject;
    GameObject insideCallCorrectObject;
    GameObject secondinsideCallCorrectObject;
    GameObject nextCallCorrectObject;

    public bool DebugChange = false;
    public IEnumerator RunComponent()
    {
        switch(componentType)
        {
            case ComponentType.Debug:
                StartCoroutine(DebugComponent());
                break;
            case ComponentType.If:
                StartCoroutine(IfComponent());
                break;
            case ComponentType.IfElse:
                StartCoroutine(IfElseComponent());
                break;
            case ComponentType.Loop:
                StartCoroutine(LoopComponent());
                break;
            case ComponentType.LoopUntil:
                StartCoroutine(LoopUntilComponent());
                break;
            case ComponentType.WaitForSecond:
                StartCoroutine(WaitForSecondsComponent());
                break;
            case ComponentType.SetVariable:
                StartCoroutine(SetVariableComponent());
                break;
            default:
                break;
        }
        yield return null;
    }

    void Start()
    {
        componentConnectors = GetComponent<ComponentConnectors>();
        OnChangeComponentPressed();
    }

    void Update()
    {
        if(DebugChange)
        {
            OnChangeComponentPressed();
            DebugChange = false;
        }
    }

    public void OnChangeComponentPressed()
    {
        if (componentConnectors.HasConnection() == true)
        {
            Debug.LogError("Cannot change component with connections!");
            return;
        }

        if(componentType == ComponentType.SetVariable)
        {
            componentType = 0;
            componentConnectors.ChangeComponents(componentType);
            return;
        }
        componentType += 1;
        componentConnectors.ChangeComponents(componentType);
    }

    public IEnumerator DebugComponent()
    {
        if (componentConnectors.VariableConnector.GetComponent<RopeSocket>().ropeObject == null)
        {
            Debug.LogError("Component: No variable object connected !");
            yield break;
        }

        variableCorrectObject = componentConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (variableCorrectObject == null)
        {
            Debug.LogError("Component: Variable is connected but the other side is not!");
            yield break;
        }

        Debug.Log(variableCorrectObject.GetComponentInParent<IResult>().GetResult().ToString());

        NextCall();

        yield break;
    }

    public IEnumerator IfComponent()
    {
        insideCallCorrectObject = componentConnectors.InsideCallConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (insideCallCorrectObject == null)
        {
            Debug.LogError("Missing inside call of If!");
            yield break;
        }

        booleanCorrectObject = componentConnectors.BoolConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (booleanCorrectObject == null)
        {
            Debug.LogError("Missing boolean input in If!");
            yield break;
        }

        if (booleanCorrectObject.GetComponentInParent<IResultBoolean>().GetResult() == true)
            StartCoroutine(insideCallCorrectObject.GetComponent<IComponent>().RunComponent());

        NextCall();

        yield break;
    }

    public IEnumerator IfElseComponent()
    {
        insideCallCorrectObject = componentConnectors.InsideCallConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        secondinsideCallCorrectObject = componentConnectors.SecondInsideCallConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (insideCallCorrectObject == null || secondinsideCallCorrectObject == null)
            yield break;

        if (componentConnectors.BoolConnector.GetComponentInParent<IResultBoolean>().GetResult() == true)
            StartCoroutine(insideCallCorrectObject.GetComponent<IComponent>().RunComponent());
        else
            StartCoroutine(secondinsideCallCorrectObject.GetComponent<IComponent>().RunComponent());

        NextCall();

        yield break;
    }

    public IEnumerator LoopComponent()
    {
        insideCallCorrectObject = componentConnectors.InsideCallConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (insideCallCorrectObject == null)
            yield return null;

        variableCorrectObject = componentConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (variableCorrectObject.GetComponentInParent<IResult>().GetResult() == null)
        {
            Debug.LogError("Loop: Missing connection!");
            yield return null;
        }

        if (variableCorrectObject.GetComponentInParent<IResult>().GetResult().GetType() != typeof(double))
        {
            Debug.LogError("Loop: Wrong type!");
            yield return null;
        }

        if ( (double)variableCorrectObject.GetComponentInParent<IResult>().GetResult() < 0 )
        {
            Debug.LogError("Loop: Negative is not acceptable!");
            yield return null;
        }

        //float lastTime = 0f;
        int counter = 0;
        while (counter != (int)variableCorrectObject.GetComponentInParent<IResult>().GetResult())
        {
            counter++;
            StartCoroutine(insideCallCorrectObject.GetComponent<IComponent>().RunComponent());
            yield return new WaitForEndOfFrame();
            //Gyorsítás
            /*lastTime += Time.deltaTime;
            if (lastTime > 10f)
            {
                lastTime = 0f;
                yield return new WaitForEndOfFrame();
            }*/
        }
        NextCall();

        yield return null;
    }

    public IEnumerator LoopUntilComponent()
    {
        insideCallCorrectObject = componentConnectors.InsideCallConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        booleanCorrectObject = componentConnectors.BoolConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (insideCallCorrectObject == null)
            yield return null;

        //float lastTime = 0f;
        while (booleanCorrectObject.GetComponentInParent<IResultBoolean>().GetResult() == false)
        {
            StartCoroutine(insideCallCorrectObject.GetComponent<IComponent>().RunComponent());
            yield return new WaitForEndOfFrame();
            //Gyorsítás
            /*lastTime += Time.deltaTime;
            if (lastTime > 10f)
            {
                lastTime = 0f;
                yield return new WaitForEndOfFrame();
            }*/
        }
        NextCall();

        yield return null;
    }

    public void NextCall()
    {
        nextCallCorrectObject = componentConnectors.NextCallConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (nextCallCorrectObject != null)
            StartCoroutine(nextCallCorrectObject.GetComponent<IComponent>().RunComponent());
    }

    public IEnumerator WaitForSecondsComponent()
    {
        variableCorrectObject = componentConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (variableCorrectObject.GetComponentInParent<IResult>().GetResult() == null)
        {
            Debug.LogError("Loop: Missing connection!");
            yield return null;
        }

        if (variableCorrectObject.GetComponentInParent<IResult>().GetResult().GetType() != typeof(double))
        {
            Debug.LogError("Wait For Seconds: Wrong variable type!");
            yield return null;
        }

        if ((double)variableCorrectObject.GetComponentInParent<IResult>().GetResult() < 0)
        {
            Debug.LogError("Wait For Seconds: Negative is not acceptable!");
            yield return null;
        }

        yield return new WaitForSeconds((float)variableCorrectObject.GetComponentInParent<IResult>().GetResult());

        NextCall();

        yield return null;
    }

    public IEnumerator SetVariableComponent()
    {
        variableCorrectObject = componentConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        secondvariableCorrectObject = componentConnectors.SecondVariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (componentConnectors.VariableConnector.GetComponent<RopeSocket>().ropeObject == null)
        {
            Debug.LogError("Component: No set variable object connected !");
            yield break;
        }

        if (componentConnectors.SecondVariableConnector.GetComponent<RopeSocket>().ropeObject == null)
        {
            Debug.LogError("Component: No setter object connected!");
            yield break;
        }

        if (variableCorrectObject == null)
        {
            Debug.LogError("Component: Variable is connected but the other side is not!");
            yield break;
        }

        if (secondvariableCorrectObject == null)
        {
            Debug.LogError("Component: Second variable is connected but the other side is not!");
            yield break;
        }

        if (variableCorrectObject.GetComponentInParent<VariableScript>() == null)
        {
            Debug.LogError("Component: Wrong object attached!");
            yield break;
        }

        variableCorrectObject.GetComponentInParent<VariableScript>().variableValue = secondvariableCorrectObject.GetComponentInParent<IResult>().GetResult().ToString();

        if (componentConnectors.NextCallConnector.GetComponent<RopeSocket>().ropeObject != null && componentConnectors.NextCallConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject) != null)
            StartCoroutine(componentConnectors.NextCallConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject).GetComponent<IComponent>().RunComponent());

        yield break;
    }
}

public enum ComponentType
{
    Debug,
    If,
    IfElse,
    Loop,
    LoopUntil,
    WaitForSecond,
    SetVariable
}
