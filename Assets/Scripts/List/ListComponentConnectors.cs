using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ListComponentConnectors : MonoBehaviour
{
    public GameObject VariableConnector;
    public GameObject SecondVariableConnector;

    public GameObject ListConnector;

    public GameObject OutVariableConnector;

    public GameObject PreviousComponentConnector;
    public GameObject NextComponentConnector;

    public bool ListConnected, VariableConnected, SecondVeriableConnected, OutVariableConnected, PreviousComponentConnected, NextComponentConnected;

    public TMP_Text ComponentName;

    public bool HasConnection()
    {
        if (ListConnected  || SecondVeriableConnected || VariableConnected || OutVariableConnected || PreviousComponentConnected || NextComponentConnected)
            return true;

        return false;
    }
    public void ChangeListComponent(ListComponentType listComponentType)
    {
        switch (listComponentType)
        {
            case ListComponentType.Add:
                {
                    ComponentName.text = "Add+";
                    VariableConnector.SetActive(true);
                    SecondVariableConnector.SetActive(false);
                    ListConnector.SetActive(true);
                    OutVariableConnector.SetActive(false);
                    PreviousComponentConnector.SetActive(true);
                    NextComponentConnector.SetActive(true);
                    break;
                }
            case ListComponentType.Delete:
                {
                    ComponentName.text = "Delete-";
                    VariableConnector.SetActive(true);
                    SecondVariableConnector.SetActive(false);
                    ListConnector.SetActive(true);
                    OutVariableConnector.SetActive(false);
                    PreviousComponentConnector.SetActive(true);
                    NextComponentConnector.SetActive(true);
                    break;
                }
            case ListComponentType.DeleteAll:
                {
                    ComponentName.text = "DeleteAll--";
                    VariableConnector.SetActive(false);
                    SecondVariableConnector.SetActive(false);
                    ListConnector.SetActive(true);
                    OutVariableConnector.SetActive(false);
                    PreviousComponentConnector.SetActive(true);
                    NextComponentConnector.SetActive(true);
                    break;
                }
            case ListComponentType.Insert:
                {
                    ComponentName.text = "Insert>";
                    VariableConnector.SetActive(true);
                    SecondVariableConnector.SetActive(true);
                    ListConnector.SetActive(true);
                    OutVariableConnector.SetActive(false);
                    PreviousComponentConnector.SetActive(true);
                    NextComponentConnector.SetActive(true);
                    break;
                }
            case ListComponentType.Replace:
                {
                    ComponentName.text = ">Replace>";
                    VariableConnector.SetActive(true);
                    SecondVariableConnector.SetActive(true);
                    ListConnector.SetActive(true);
                    OutVariableConnector.SetActive(false);
                    PreviousComponentConnector.SetActive(true);
                    NextComponentConnector.SetActive(true);
                    break;
                }
            case ListComponentType.Item:
                {
                    ComponentName.text = "Item,";
                    VariableConnector.SetActive(true);
                    SecondVariableConnector.SetActive(false);
                    ListConnector.SetActive(true);
                    OutVariableConnector.SetActive(true);
                    PreviousComponentConnector.SetActive(false);
                    NextComponentConnector.SetActive(false);
                    break;
                }
            case ListComponentType.ItemPlace:
                {
                    ComponentName.text = "ItemPlace~";
                    VariableConnector.SetActive(true);
                    SecondVariableConnector.SetActive(false);
                    ListConnector.SetActive(true);
                    OutVariableConnector.SetActive(true);
                    PreviousComponentConnector.SetActive(false);
                    NextComponentConnector.SetActive(false);
                    break;
                }
            case ListComponentType.Length:
                {
                    ComponentName.text = "Length..";
                    VariableConnector.SetActive(false);
                    SecondVariableConnector.SetActive(false);
                    ListConnector.SetActive(true);
                    OutVariableConnector.SetActive(true);
                    PreviousComponentConnector.SetActive(false);
                    NextComponentConnector.SetActive(false);
                    break;
                }
            default:
                {
                    ComponentName.text = "Assert List Component!!";
                    VariableConnector.SetActive(false);
                    SecondVariableConnector.SetActive(false);
                    ListConnector.SetActive(false);
                    OutVariableConnector.SetActive(false);
                    PreviousComponentConnector.SetActive(false);
                    NextComponentConnector.SetActive(false);
                    break;
                }
        }
    }
}
