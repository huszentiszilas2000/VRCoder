using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BooleanOperatorConnectors : MonoBehaviour
{
    public GameObject VariableConnector;
    public GameObject SecondVariableConnector;

    public GameObject BooleanConnector;
    public GameObject SecondBooleanConnector;

    public GameObject OutBooleanConnector;

    public bool BooleanConnected, SecondBooleanConnected, VariableConnected, SecondVeriableConnected, OutBooleanConnected;

    public TMP_Text ComponentName;

    public bool HasConnection()
    {
        if (BooleanConnected || SecondBooleanConnected || SecondVeriableConnected || VariableConnected || OutBooleanConnected)
            return true;

        return false;
    }
    public void ChangeBooleanOperator(BooleanOperatorType booleanOperatorType)
    {
        OutBooleanConnector.SetActive(true);
        switch (booleanOperatorType)
        {
            case BooleanOperatorType.And:
                {
                    ComponentName.text = "And&";
                    VariableConnector.SetActive(false);
                    SecondVariableConnector.SetActive(false);
                    BooleanConnector.SetActive(true);
                    SecondBooleanConnector.SetActive(true);
                    break;
                }
            case BooleanOperatorType.Or:
                {
                    ComponentName.text = "Or|";
                    VariableConnector.SetActive(false);
                    SecondVariableConnector.SetActive(false);
                    BooleanConnector.SetActive(true);
                    SecondBooleanConnector.SetActive(true);
                    break;
                }
            case BooleanOperatorType.Not:
                {
                    ComponentName.text = "Not!";
                    VariableConnector.SetActive(false);
                    SecondVariableConnector.SetActive(false);
                    BooleanConnector.SetActive(true);
                    SecondBooleanConnector.SetActive(false);
                    break;
                }
            case BooleanOperatorType.Equals:
                {
                    ComponentName.text = "Equals=";
                    VariableConnector.SetActive(true);
                    SecondVariableConnector.SetActive(true);
                    BooleanConnector.SetActive(false);
                    SecondBooleanConnector.SetActive(false);
                    break;
                }
            case BooleanOperatorType.GreaterThan:
                {
                    ComponentName.text = "GreaterThan>";
                    VariableConnector.SetActive(true);
                    SecondVariableConnector.SetActive(true);
                    BooleanConnector.SetActive(false);
                    SecondBooleanConnector.SetActive(false);
                    break;
                }
            case BooleanOperatorType.LessThan:
                {
                    ComponentName.text = "LessThan<";
                    VariableConnector.SetActive(true);
                    SecondVariableConnector.SetActive(true);
                    BooleanConnector.SetActive(false);
                    SecondBooleanConnector.SetActive(false);
                    break;
                }
            default:
                {
                    ComponentName.text = "Assert Boolean Operator!!";
                    VariableConnector.SetActive(false);
                    SecondVariableConnector.SetActive(false);
                    BooleanConnector.SetActive(false);
                    SecondBooleanConnector.SetActive(false);
                    OutBooleanConnector.SetActive(false);
                    break;
                }
        }
    }
}
