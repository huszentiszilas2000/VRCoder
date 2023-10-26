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

    public bool spawn = false;

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
        value1 = Operator.GetValueString(mathOperatorConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject).gameObject);
        value2 = Operator.GetValueString(mathOperatorConnectors.SecondVariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject).gameObject);
        typeOf = Operator.GetObjectToConvert(mathOperatorConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject).gameObject, mathOperatorConnectors.SecondVariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject).gameObject);
    }

    System.Object Add()
    {
        if (mathOperatorConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject) == null || mathOperatorConnectors.SecondVariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject) == null)
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
        if (mathOperatorConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject) == null || mathOperatorConnectors.SecondVariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject) == null)
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
        if (mathOperatorConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject) == null || mathOperatorConnectors.SecondVariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject) == null)
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
        if (mathOperatorConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject) == null || mathOperatorConnectors.SecondVariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject) == null)
        {
            Debug.LogError("One of the object is missing");
            return null;
        }

        SetVariables();

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
        if (mathOperatorConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject) == null || mathOperatorConnectors.SecondVariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject) == null)
        {
            Debug.LogError("One of the object is missing");
            return null;
        }

        SetVariables();

        if (Operator.GetObjectToConvert(mathOperatorConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject), mathOperatorConnectors.SecondVariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject)) == typeof(double))
        {
            double d1 = double.Parse(value1);
            double d2 = double.Parse(value2);
            double x = VisualCompiler.random.NextDouble();
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
        if (spawn)
        {
            OnChangeMathOperatorPressed();
            spawn = false;
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
