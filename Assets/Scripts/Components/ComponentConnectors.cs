using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComponentConnectors : MonoBehaviour
{
    public GameObject BoolConnector;
    public GameObject VariableConnector;
    public GameObject SecondVariableConnector;

    public GameObject PreviousComponentConnector;
    public GameObject InsideCallConnector;
    public GameObject SecondInsideCallConnector;
    public GameObject NextCallConnector;

    public bool BoolConnected, VariableConnected, PreviousConnected, InsideConnected, SecondInsideConnected, NextConnected;

    public TMP_Text ComponentName;

    public bool HasConnection()
    {
        if (BoolConnected || VariableConnected || PreviousConnected || InsideConnected || SecondInsideConnected || NextConnected)
            return true;

        return false;
    }

    public void ChangeComponents(ComponentType componentType)
    {
        switch (componentType)
        {
            case ComponentType.Debug:
                {
                    BoolConnector.SetActive(false);
                    VariableConnector.SetActive(true);
                    SecondVariableConnector.SetActive(false);
                    PreviousComponentConnector.SetActive(true);
                    InsideCallConnector.SetActive(false);
                    SecondInsideCallConnector.SetActive(false);
                    NextCallConnector.SetActive(true);
                    ComponentName.text = ">Debug";
                    break;
                }
            case ComponentType.If:
                {
                    BoolConnector.SetActive(true);
                    VariableConnector.SetActive(false);
                    SecondVariableConnector.SetActive(false);
                    PreviousComponentConnector.SetActive(true);
                    InsideCallConnector.SetActive(true);
                    SecondInsideCallConnector.SetActive(false);
                    NextCallConnector.SetActive(true);
                    ComponentName.text = ">If";
                    break;
                }
            case ComponentType.IfElse:
                {
                    BoolConnector.SetActive(true);
                    VariableConnector.SetActive(false);
                    SecondVariableConnector.SetActive(false);
                    PreviousComponentConnector.SetActive(true);
                    InsideCallConnector.SetActive(true);
                    SecondInsideCallConnector.SetActive(true);
                    NextCallConnector.SetActive(true);
                    ComponentName.text = ">If else";
                    break;
                }
            case ComponentType.Loop:
                {
                    BoolConnector.SetActive(false);
                    VariableConnector.SetActive(true);
                    SecondVariableConnector.SetActive(false);
                    PreviousComponentConnector.SetActive(true);
                    InsideCallConnector.SetActive(true);
                    SecondInsideCallConnector.SetActive(false);
                    NextCallConnector.SetActive(true);
                    ComponentName.text = ">Loop";
                    break;
                }
            case ComponentType.LoopUntil:
                {
                    BoolConnector.SetActive(true);
                    VariableConnector.SetActive(false);
                    SecondVariableConnector.SetActive(false);
                    PreviousComponentConnector.SetActive(true);
                    InsideCallConnector.SetActive(true);
                    SecondInsideCallConnector.SetActive(false);
                    NextCallConnector.SetActive(true);
                    ComponentName.text = ">Loop Until";
                    break;
                }
            case ComponentType.WaitForSecond:
                {
                    BoolConnector.SetActive(false);
                    VariableConnector.SetActive(true);
                    SecondVariableConnector.SetActive(false);
                    PreviousComponentConnector.SetActive(true);
                    InsideCallConnector.SetActive(false);
                    SecondInsideCallConnector.SetActive(false);
                    NextCallConnector.SetActive(true);
                    ComponentName.text = "WaitForSec..";
                    break;
                }
            case ComponentType.SetVariable:
                {
                    BoolConnector.SetActive(false);
                    VariableConnector.SetActive(true);
                    SecondVariableConnector.SetActive(true);
                    PreviousComponentConnector.SetActive(true);
                    InsideCallConnector.SetActive(false);
                    SecondInsideCallConnector.SetActive(false);
                    NextCallConnector.SetActive(true);
                    ComponentName.text = ">Set Variable";
                    break;
                }
            default:
                {
                    BoolConnector.SetActive(false);
                    VariableConnector.SetActive(false);
                    SecondVariableConnector.SetActive(false);
                    PreviousComponentConnector.SetActive(false);
                    InsideCallConnector.SetActive(false);
                    SecondInsideCallConnector.SetActive(false);
                    NextCallConnector.SetActive(false);
                    ComponentName.text = ">Assert Component";
                    break;
                }
        }
    }
}
