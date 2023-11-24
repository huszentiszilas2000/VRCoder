using System;
using System.Collections;
using UnityEngine;

public class ListComponents : MonoBehaviour, IComponent, IResult
{
    [SerializeField]
    ListComponentType listComponentType;
    public string value1;
    public string value2;
    public Type typeOf;

    GameObject listCorrectObject;
    GameObject nextCallCorrectObject;
    GameObject variableCorrectObject;
    GameObject secondvariableCorrectObject;
    ListComponentConnectors listComponentConnectors;

    public bool DebugChange = false;

    public IEnumerator RunComponent()
    {
        switch (listComponentType)
        {
            case ListComponentType.Add:
                StartCoroutine(AddToList());
                break;
            case ListComponentType.Delete:
                StartCoroutine(DeleteFromList());
                break;
            case ListComponentType.DeleteAll:
                StartCoroutine(DeleteAllFromList());
                break;
            case ListComponentType.Replace:
                StartCoroutine(ReplaceInList());
                break;
            case ListComponentType.Insert:
                StartCoroutine(InsertIntoList());
                break;
            default:
                break;
        }

        yield return null;
    }

    public IEnumerator AddToList()
    {
        listCorrectObject = listComponentConnectors.ListConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (listCorrectObject == null)
        {
            Debug.Log("List Component: List is missing");
            yield break;
        }

        variableCorrectObject = listComponentConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (variableCorrectObject == null)
        {
            Debug.Log("List Component: Variable is missing");
            yield break;
        }

        if (listCorrectObject.GetComponentInParent<ListScript>() == null)
        {
            Debug.Log("List Component: Wrong type attached");
            yield break;
        }

        if (variableCorrectObject.GetComponentInParent<IResult>() == null)
        {
            Debug.Log("List Component: No value is in Variable");
            yield break;
        }

        listCorrectObject.GetComponentInParent<ListScript>().variables.Add(variableCorrectObject.GetComponentInParent<IResult>().GetResult());

        NextCall("Add To List");

        yield return null;
    }

    public IEnumerator DeleteFromList()
    {
        listCorrectObject = listComponentConnectors.ListConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (listCorrectObject == null)
        {
            Debug.Log("List Component: List is missing");
            yield break;
        }

        variableCorrectObject = listComponentConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (variableCorrectObject == null)
        {
            Debug.Log("List Component: Variable is missing");
            yield break;
        }

        if (listCorrectObject.GetComponentInParent<ListScript>() == null)
        {
            Debug.Log("List Component: Wrong type attached");
            yield break;
        }

        if (variableCorrectObject.GetComponentInParent<IResult>() == null)
        {
            Debug.Log("List Component: No value is in Variable");
            yield break;
        }

        if (variableCorrectObject.GetComponentInParent<IResult>().GetResult().GetType() != typeof(double))
        {
            Debug.LogError("List Component: Wrong type!");
            yield break;
        }

        if ((double)variableCorrectObject.GetComponentInParent<IResult>().GetResult() < 0)
        {
            Debug.LogError("List Component: Negative is not acceptable!");
            yield break;
        }

        listCorrectObject.GetComponentInParent<ListScript>().variables.RemoveAt((int)variableCorrectObject.GetComponentInParent<IResult>().GetResult());

        NextCall("Delete");

        yield return null;
    }

    public IEnumerator DeleteAllFromList()
    {
        listCorrectObject = listComponentConnectors.ListConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (listCorrectObject == null)
        {
            Debug.Log("List Component: List is missing");
            yield break;
        }

        if (listCorrectObject.GetComponentInParent<ListScript>() == null)
        {
            Debug.Log("List Component: Wrong type attached");
            yield break;
        }

        listCorrectObject.GetComponentInParent<ListScript>().variables.RemoveRange(0, listCorrectObject.GetComponentInParent<ListScript>().variables.Count);

        NextCall("Delete All");

        yield return null;
    }

    public IEnumerator ReplaceInList()
    {
        listCorrectObject = listComponentConnectors.ListConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (listCorrectObject == null)
        {
            Debug.Log("List Component: List is missing");
            yield break;
        }

        if (listCorrectObject.GetComponentInParent<ListScript>() == null)
        {
            Debug.Log("List Component: Wrong type attached");
            yield break;
        }

        variableCorrectObject = listComponentConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (variableCorrectObject == null)
        {
            Debug.Log("List Component: Variable is missing");
            yield break;
        }

        if (variableCorrectObject.GetComponentInParent<IResult>() == null)
        {
            Debug.Log("List Component: No value is in Variable");
            yield break;
        }

        if (Operator.GetObjectToConvert(variableCorrectObject) != typeof(double))
        {
            Debug.LogError("List Component: Wrong type!");
            yield break;
        }

        if (double.Parse(variableCorrectObject.GetComponentInParent<IResult>().GetResult().ToString()) < 0 || double.Parse(variableCorrectObject.GetComponentInParent<IResult>().GetResult().ToString()) == 0)
        {
            Debug.LogError("List Component: Negative or 0 is not acceptable!");
            yield break;
        }

        secondvariableCorrectObject = listComponentConnectors.SecondVariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (secondvariableCorrectObject == null)
        {
            Debug.Log("List Component: Variable is missing");
            yield break;
        }

        if (secondvariableCorrectObject.GetComponentInParent<IResult>() == null)
        {
            Debug.Log("List Component: No value is in Variable");
            yield break;
        }

        listCorrectObject.GetComponentInParent<ListScript>().variables.Insert(int.Parse(variableCorrectObject.GetComponentInParent<IResult>().GetResult().ToString()), secondvariableCorrectObject.GetComponentInParent<IResult>().GetResult());
        listCorrectObject.GetComponentInParent<ListScript>().variables.RemoveAt(int.Parse(variableCorrectObject.GetComponentInParent<IResult>().GetResult().ToString()) + 1);

        NextCall("Replace In List");

        yield return null;
    }

    public IEnumerator InsertIntoList()
    {
        listCorrectObject = listComponentConnectors.ListConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (listCorrectObject == null)
        {
            Debug.Log("List Component: List is missing");
            yield break;
        }

        if (listCorrectObject.GetComponentInParent<ListScript>() == null)
        {
            Debug.Log("List Component: Wrong type attached");
            yield break;
        }

        variableCorrectObject = listComponentConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (variableCorrectObject == null)
        {
            Debug.Log("List Component: Variable is missing");
            yield break;
        }

        if (variableCorrectObject.GetComponentInParent<IResult>() == null)
        {
            Debug.Log("List Component: No value is in Variable");
            yield break;
        }

        if (Operator.GetObjectToConvert(variableCorrectObject) != typeof(double))
        {
            Debug.LogError("List Component: Wrong type!");
            yield break;
        }

        if (double.Parse(variableCorrectObject.GetComponentInParent<IResult>().GetResult().ToString()) < 0 || double.Parse(variableCorrectObject.GetComponentInParent<IResult>().GetResult().ToString()) == 0)
        {
            Debug.LogError("List Component: Negative or 0 is not acceptable!");
            yield break;
        }

        secondvariableCorrectObject = listComponentConnectors.SecondVariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (secondvariableCorrectObject == null)
        {
            Debug.Log("List Component: Variable is missing");
            yield break;
        }

        if (secondvariableCorrectObject.GetComponentInParent<IResult>() == null)
        {
            Debug.Log("List Component: No value is in Variable");
            yield break;
        }

        listCorrectObject.GetComponentInParent<ListScript>().variables.Insert(int.Parse(variableCorrectObject.GetComponentInParent<IResult>().GetResult().ToString()), secondvariableCorrectObject.GetComponentInParent<IResult>().GetResult());

        NextCall("Insert Into List:");

        yield return null;
    }

    public System.Object GetResult()
    {
        switch (listComponentType)
        {
            case ListComponentType.GetItem:
                return GetItem();
            case ListComponentType.GetItemPlace:
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

        return listCorrectObject.GetComponentInParent<ListScript>().GetItem(variableCorrectObject.GetComponentInParent<IResult>().GetResult().ToString());
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

        return listCorrectObject.GetComponentInParent<ListScript>().GetItemPlace(variableCorrectObject.GetComponentInParent<IResult>().GetResult().ToString());
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

    public void NextCall(string previousCall)
    {
        if (listComponentConnectors.NextComponentConnector.GetComponent<RopeSocket>().ropeObject == null)
        {
            Debug.LogWarning(previousCall + ": No next call is connected");
            return;
        }

        nextCallCorrectObject = listComponentConnectors.NextComponentConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (nextCallCorrectObject != null)
            StartCoroutine(nextCallCorrectObject.GetComponentInParent<IComponent>().RunComponent());
    }

    public void OnChangeListComponentPressed()
    {
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
    GetItem,
    GetItemPlace,
    Length
}
