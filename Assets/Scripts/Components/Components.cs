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

    public bool spawn = false;
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
                break;
            case ComponentType.LoopUntil:
                StartCoroutine(LoopUntilComponent());
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
        if(spawn)
        {
            OnChangeComponentPressed();
            spawn = false;
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

        if (componentConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject) == null)
        {
            Debug.LogError("Component: Variable is connected but the other side is not!");
            yield break;
        }

        Debug.Log(componentConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject).GetComponentInParent<IResult>().GetResult().ToString());

        if (componentConnectors.NextCallConnector.GetComponent<RopeSocket>().ropeObject != null && componentConnectors.NextCallConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject) != null)
            StartCoroutine(componentConnectors.NextCallConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject).GetComponent<IComponent>().RunComponent());

        yield break;
    }

    public IEnumerator IfComponent()
    {
        if (componentConnectors.InsideCallConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject) == null)
        {
            Debug.LogError("Missing inside call of If!");
            yield break;
        }

        if (componentConnectors.BoolConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject) == null)
        {
            Debug.LogError("Missing boolean input in If!");
            yield break;
        }

        if (componentConnectors.BoolConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject).GetComponent<IResultBoolean>().GetResult() == true)
            StartCoroutine(componentConnectors.InsideCallConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject).GetComponent<IComponent>().RunComponent());

        if (componentConnectors.NextCallConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject) != null)
            StartCoroutine(componentConnectors.NextCallConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject).GetComponent<IComponent>().RunComponent());

        yield break;
    }

    public IEnumerator IfElseComponent()
    {
        if (componentConnectors.InsideCallConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject) == null ||
            componentConnectors.SecondInsideCallConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject) == null)
            yield break;

        if (componentConnectors.BoolConnector.GetComponent<IResultBoolean>().GetResult() == true)
            StartCoroutine(componentConnectors.InsideCallConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject).GetComponent<IComponent>().RunComponent());
        else
            StartCoroutine(componentConnectors.SecondInsideCallConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject).GetComponent<IComponent>().RunComponent());

        if (componentConnectors.NextCallConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject) != null)
            StartCoroutine(componentConnectors.NextCallConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject).GetComponent<IComponent>().RunComponent());

        yield break;
    }

    public IEnumerator LoopUntilComponent()
    {
        if (componentConnectors.InsideCallConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject) == null)
            yield return null;

        //float lastTime = 0f;
        while (componentConnectors.BoolConnector.GetComponent<IResultBoolean>().GetResult() == false)
        {
            StartCoroutine(componentConnectors.InsideCallConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject).GetComponent<IComponent>().RunComponent());
            yield return new WaitForEndOfFrame();
            //Gyorsítás
            /*lastTime += Time.deltaTime;
            if (lastTime > 10f)
            {
                lastTime = 0f;
                yield return new WaitForEndOfFrame();
            }*/
        }
        if (componentConnectors.NextCallConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject) != null)
            StartCoroutine(componentConnectors.NextCallConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject).GetComponent<IComponent>().RunComponent());

        yield return null;
    }

    public IEnumerator SetVariableComponent()
    {
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

        if (componentConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject) == null)
        {
            Debug.LogError("Component: Variable is connected but the other side is not!");
            yield break;
        }

        if (componentConnectors.SecondVariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject) == null)
        {
            Debug.LogError("Component: Second variable is connected but the other side is not!");
            yield break;
        }

        if (componentConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject).GetComponentInParent<VariableScript>() == null)
        {
            Debug.LogError("Component: Wrong object attached!");
            yield break;
        }

        componentConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject).GetComponentInParent<VariableScript>().variableValue = componentConnectors.SecondVariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject).GetComponentInParent<IResult>().GetResult().ToString();

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
    SetVariable
}
