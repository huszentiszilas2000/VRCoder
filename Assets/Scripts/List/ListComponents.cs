using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListComponents : MonoBehaviour, IComponent, IResult
{
    [SerializeField]
    ListComponentType listComponentType;
    public string value1;
    public string value2;
    public Type typeOf;

    GameObject listCorrectObject;
    GameObject variableCorrectObject;
    ListComponentConnectors listComponentConnectors;

    public bool DebugChange = false;

    public IEnumerator RunComponent()
    {
        switch (listComponentType)
        {
            case ListComponentType.Add:
                break;
            case ListComponentType.Delete:
                break;
            case ListComponentType.DeleteAll:
                break;
            case ListComponentType.Replace:
                break;
            case ListComponentType.Insert:
                break;
            default:
                break;
        }

        yield return null;
    }

    public System.Object GetResult()
    {
        switch (listComponentType)
        {
            case ListComponentType.Item:
                return GetItem();
            case ListComponentType.ItemPlace:
                return GetItemPlace();
            case ListComponentType.Length:
                return GetLength();
            default:
                return false;
        }
    }

    public System.Object GetItem()
    {
        listCorrectObject = listComponentConnectors.ListConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (listCorrectObject == null)
        {
            Debug.Log("List Component: List is missing");
            return null;
        }

        variableCorrectObject = listComponentConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (variableCorrectObject == null )
        {
            Debug.Log("List Component: Variable is missing");
            return null;
        }

        if (listCorrectObject.GetComponentInParent<ListScript>() == null)
        {
            Debug.Log("List Component: Wrong type attached");
            return null;
        }

        if (variableCorrectObject.GetComponentInParent<IResult>() == null)
        {
            Debug.Log("List Component: No value is in Variable");
            return null;
        }

        return listCorrectObject.GetComponentInParent<ListScript>().GetItem(variableCorrectObject.GetComponentInParent<IResult>().ToString());
    }

    public System.Object GetItemPlace()
    {
        listCorrectObject = listComponentConnectors.ListConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (listCorrectObject == null)
        {
            Debug.Log("List Component: List is missing");
            return null;
        }

        variableCorrectObject = listComponentConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (variableCorrectObject == null)
        {
            Debug.Log("List Component: Variable is missing");
            return null;
        }

        if (listCorrectObject.GetComponentInParent<ListScript>() == null)
        {
            Debug.Log("List Component: Wrong type attached");
            return null;
        }

        if (variableCorrectObject.GetComponentInParent<IResult>() == null)
        {
            Debug.Log("List Component: No value is in Variable");
            return null;
        }

        return listCorrectObject.GetComponentInParent<ListScript>().GetItemPlace(variableCorrectObject.GetComponentInParent<IResult>().ToString());
    }
    public System.Object GetLength()
    {
        listCorrectObject = listComponentConnectors.ListConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (listCorrectObject == null)
        {
            Debug.Log("List Component: List is missing");
            return null;
        }

        if (listCorrectObject.GetComponentInParent<ListScript>() == null)
        {
            Debug.Log("List Component: Wrong type attached");
            return null;
        }

        return listCorrectObject.GetComponentInParent<ListScript>().GetLength();
    }

    void Start()
    {
        listComponentConnectors = GetComponent<ListComponentConnectors>();
        OnChangeListComponentPressed();
    }

    void Update()
    {
        if (DebugChange)
        {
            OnChangeListComponentPressed();
            DebugChange = false;
        }
    }

    public void OnChangeListComponentPressed()
    {
        if (listComponentConnectors.HasConnection() == true)
        {
            Debug.LogError("Cannot change component with connections!");
            return;
        }

        if (listComponentType == ListComponentType.Length)
        {
            listComponentType = 0;
            listComponentConnectors.ChangeListComponent(listComponentType);
            return;
        }
        listComponentType += 1;
        listComponentConnectors.ChangeListComponent(listComponentType);
    }
}

public enum ListComponentType
{
    Add,
    Delete,
    DeleteAll,
    Insert,
    Replace,
    Item,
    ItemPlace,
    Length
}
