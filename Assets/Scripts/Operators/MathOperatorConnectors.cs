using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MathOperatorConnectors : MonoBehaviour
{
    public GameObject VariableConnector;
    public GameObject SecondVariableConnector;

    public GameObject OutVariableConnector;

    public bool VariableConnectored, SecondVariableConnected, OutVariableConnected;

    public TMP_Text ComponentName;

    public bool HasConnection()
    {
        if (VariableConnectored || SecondVariableConnected || OutVariableConnected)
            return true;

        return false;
    }
    public void ChangeMathOperator(MathOperatorType mathOperatorType)
    {
        VariableConnector.SetActive(true);
        SecondVariableConnector.SetActive(true);
        OutVariableConnector.SetActive(true);
        switch (mathOperatorType)
        {
            case MathOperatorType.Add:
                {
                    ComponentName.text = "+Add";
                    break;
                }
            case MathOperatorType.Subtract:
                {
                    ComponentName.text = "-Subtract";
                    break;
                }
            case MathOperatorType.Multiply:
                {
                    
                    ComponentName.text = "*Multiply";
                    break;
                }
            case MathOperatorType.Divide:
                {
                    
                    ComponentName.text = "/Divide";
                    break;
                }
            case MathOperatorType.Random:
                {
                    
                    ComponentName.text = "?Random";
                    break;
                }
            default:
                {
                    VariableConnector.SetActive(false);
                    SecondVariableConnector.SetActive(false);
                    OutVariableConnector.SetActive(false);
                    ComponentName.text = ">Assert Math Operator";
                    break;
                }
        }
    }
}
