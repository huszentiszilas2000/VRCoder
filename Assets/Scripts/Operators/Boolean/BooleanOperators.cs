using System;
using UnityEngine;

public class BooleanOperators : Operator, IResultBoolean
{
    [SerializeField]
    BooleanOperatorType booleanOperatorType;
    string value1;
    string value2;
    Type typeOf;

    bool bool1;
    bool bool2;

    GameObject variableCorrectObject;
    GameObject secondvariableCorrectObject;
    GameObject booleanCorrectObject;
    GameObject secondbooleanCorrectObject;

    BooleanOperatorConnectors booleanOperatorConnectors;

    [SerializeField]
    bool DebugChange = false;

    public bool GetResult()
    {
        switch (booleanOperatorType)
        {
            case BooleanOperatorType.And:
                return And();
            case BooleanOperatorType.Or:
                return Or();
            case BooleanOperatorType.Not:
                return Not();
            case BooleanOperatorType.Equals:
                return Equals();
            case BooleanOperatorType.GreaterThan:
                return GreaterThan();
            case BooleanOperatorType.LessThan:
                return LessThan();
            default:
                return false;
        }
    }
    public void SetVariables()
    {
        value1 = Operator.GetValueString(variableCorrectObject.gameObject);
        value2 = Operator.GetValueString(secondvariableCorrectObject.gameObject);
        typeOf = Operator.GetObjectsToConvert(variableCorrectObject.gameObject, secondvariableCorrectObject.gameObject);
    }
    public void SetBooleans()
    {
        bool1 = Operator.GetBool(booleanCorrectObject.gameObject);
        bool2 = Operator.GetBool(secondbooleanCorrectObject.gameObject);
    }

    bool And()
    {
        booleanCorrectObject = booleanOperatorConnectors.BooleanConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        secondbooleanCorrectObject = booleanOperatorConnectors.SecondBooleanConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (booleanCorrectObject == null || secondbooleanCorrectObject == null)
        {
            Debug.LogError("One of the boolean object is missing");
            return false;
        }

        SetBooleans();


        if (bool1 != true || bool2 != true)
            return false;

        return true;
    }

    bool Or()
    {
        booleanCorrectObject = booleanOperatorConnectors.BooleanConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        secondbooleanCorrectObject = booleanOperatorConnectors.SecondBooleanConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (booleanCorrectObject == null || secondbooleanCorrectObject == null)
        {
            Debug.LogError("One of the boolean object is missing");
            return false;
        }

        SetBooleans();
        if (bool1 == true || bool2 == true)
            return true;

        return false;
    }

    bool Not()
    {
        booleanCorrectObject = booleanOperatorConnectors.BooleanConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (booleanCorrectObject == null )
        {
            Debug.LogError("Boolean object is missing");
            return false;
        }
        
        SetBooleans();

        if (bool1 == true)
            return false;

        return true;
    }

    bool Equals()
    {
        variableCorrectObject = booleanOperatorConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        secondvariableCorrectObject = booleanOperatorConnectors.SecondVariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (variableCorrectObject == null || secondvariableCorrectObject == null)
        {
            Debug.LogError("One of the object is missing");
            return false;
        }

        SetVariables();

        if (typeOf == typeof(double))
        {
            return (double.Parse(value1) == double.Parse(value2));
        }
        else
        {
            return false;
        }
    }

    bool GreaterThan()
    {
        variableCorrectObject = booleanOperatorConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        secondvariableCorrectObject = booleanOperatorConnectors.SecondVariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (variableCorrectObject == null || secondvariableCorrectObject == null)
        {
            Debug.LogError("One of the object is missing");
            return false;
        }

        SetVariables();

        if (typeOf == typeof(double))
        {
            return (double.Parse(value1) > double.Parse(value2));
        }
        else
        {
            return false;
        }
    }
    bool LessThan()
    {
        variableCorrectObject = booleanOperatorConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        secondvariableCorrectObject = booleanOperatorConnectors.SecondVariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (variableCorrectObject == null || secondvariableCorrectObject == null)
        {
            Debug.LogError("One of the object is missing");
            return false;
        }

        SetVariables();

        if (typeOf == typeof(double))
        {
            return (double.Parse(value1) < double.Parse(value2));
        }
        else
        {
            return false;
        }
    }

    void Start()
    {
        booleanOperatorConnectors = GetComponent<BooleanOperatorConnectors>();
        OnChangeBooleanOperatorPressed();
    }

    void Update()
    {
        if (DebugChange)
        {
            OnChangeBooleanOperatorPressed();
            DebugChange = false;
        }
    }

    public void OnChangeBooleanOperatorPressed()
    {
        if (booleanOperatorType == BooleanOperatorType.GreaterThan)
        {
            booleanOperatorType = 0;
            booleanOperatorConnectors.ChangeBooleanOperator(booleanOperatorType);
            return;
        }
        booleanOperatorType += 1;
        booleanOperatorConnectors.ChangeBooleanOperator(booleanOperatorType);
    }
}

public enum BooleanOperatorType
{
    And,
    Or,
    Not,
    Equals,
    LessThan,
    GreaterThan
}
