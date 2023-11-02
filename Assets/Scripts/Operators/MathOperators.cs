using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathOperators : Operator, IResult
{
    [SerializeField]
    MathOperatorType mathOperatorType;
    public string value1;
    public string value2;
    public Type typeOf;

    MathOperatorConnectors mathOperatorConnectors;

    GameObject variableCorrectObject;
    GameObject secondvariableCorrectObject;

    public bool DebugChange = false;

    public System.Object GetResult()
    {
        switch (mathOperatorType)
        {
            case MathOperatorType.Add:
                return Add();
            case MathOperatorType.Subtract:
                return Subtract();
            case MathOperatorType.Multiply:
                return Multiply();
            case MathOperatorType.Divide:
                return Divide();
            case MathOperatorType.Random:
                return Random();
            default:
                break;
        }
        return null;
    }

    public void SetVariables()
    {
        value1 = Operator.GetValueString(variableCorrectObject.gameObject);
        value2 = Operator.GetValueString(secondvariableCorrectObject.gameObject);
        typeOf = Operator.GetObjectToConvert(variableCorrectObject.gameObject, secondvariableCorrectObject.gameObject);
    }
    System.Object Add()
    {
        variableCorrectObject = mathOperatorConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        secondvariableCorrectObject = mathOperatorConnectors.SecondVariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (variableCorrectObject == null || secondvariableCorrectObject == null)
        {
            Debug.LogError("One of the object is missing");
            return null;
        }

        SetVariables();

        if (typeOf == typeof(double))
        {
            return (double.Parse(value1) + double.Parse(value2));
        }
        else
        {
            return value1 + value2;
        }
    }
    System.Object Subtract()
    {
        variableCorrectObject = mathOperatorConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        secondvariableCorrectObject = mathOperatorConnectors.SecondVariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (variableCorrectObject == null || secondvariableCorrectObject == null)
        {
            Debug.LogError("One of the object is missing");
            return null;
        }

        SetVariables();

        if (typeOf == typeof(double))
        {
            return (double.Parse(value1) - double.Parse(value2));
        }
        else
        {
            return null;
        }
    }
    System.Object Multiply()
    {
        variableCorrectObject = mathOperatorConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        secondvariableCorrectObject = mathOperatorConnectors.SecondVariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (variableCorrectObject == null || secondvariableCorrectObject == null)
        {
            Debug.LogError("One of the object is missing");
            return null;
        }

        SetVariables();

        if (typeOf == typeof(double))
        {
            return (double.Parse(value1) * double.Parse(value2));
        }
        else
        {
            return null;
        }
    }
    System.Object Divide()
    {
        variableCorrectObject = mathOperatorConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        secondvariableCorrectObject = mathOperatorConnectors.SecondVariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (variableCorrectObject == null || secondvariableCorrectObject == null)
        {
            Debug.LogError("One of the object is missing");
            return null;
        }

        SetVariables();

        if(double.Parse(value2) == 0)
        {
            Debug.LogError("Dividing with zero!");
            return null;
        }

        if (typeOf == typeof(double))
        {
            return (double.Parse(value1) / double.Parse(value2));
        }
        else
        {
            return null;
        }
    }
    System.Object Random()
    {
        variableCorrectObject = mathOperatorConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        secondvariableCorrectObject = mathOperatorConnectors.SecondVariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (variableCorrectObject == null || secondvariableCorrectObject == null)
        {
            Debug.LogError("One of the object is missing");
            return null;
        }

        SetVariables();

        if (Operator.GetObjectToConvert(variableCorrectObject, secondvariableCorrectObject) == typeof(double))
        {
            double d1 = double.Parse(value1);
            double d2 = double.Parse(value2);
            double x = Operator.random.NextDouble();
            if (d1 % 1 == 0 && d2 % 1 == 0)
            {
                return Math.Round((double)(x * d2 + (1 - x) * d1),0);
            }

            return x * d2 + ( 1-x ) * d1;
        }
        else
        {
            return null;
        }
    }
    void Start()
    {
        mathOperatorConnectors = GetComponent<MathOperatorConnectors>();
        OnChangeMathOperatorPressed();
    }
    void Update()
    {
        if (DebugChange)
        {
            OnChangeMathOperatorPressed();
            DebugChange = false;
        }
    }
    public void OnChangeMathOperatorPressed()
    {
        if (mathOperatorConnectors.HasConnection() == true)
        {
            Debug.LogError("Cannot change component with connections!");
            return;
        }

        if (mathOperatorType == MathOperatorType.Random)
        {
            mathOperatorType = 0;
            mathOperatorConnectors.ChangeMathOperator(mathOperatorType);
            return;
        }
        mathOperatorType += 1;
        mathOperatorConnectors.ChangeMathOperator(mathOperatorType);
    }
}

public enum MathOperatorType
{
    Add,
    Subtract,
    Divide,
    Multiply,
    Random
}
