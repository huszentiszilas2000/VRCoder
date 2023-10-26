using System;
using UnityEngine;

public class Equals : Operator, IResultBoolean
{
    public bool GetResult()
    {
        if (variableFirst == null || variableSecond == null)
        {
            Debug.LogError("One of the object is missing");
            return false;
        }

        string value1 = "";
        string value2 = "";

        value1 = Operator.GetValueString(variableFirst);
        value2 = Operator.GetValueString(variableSecond);

        Type typeOf = Operator.GetObjectToConvert(variableFirst, variableSecond);
        if (typeOf == typeof(int))
        {
            int i1 = int.Parse(value1);
            int i2 = int.Parse(value2);
            return i1 == i2;
        }
        else if (typeOf == typeof(double))
        {
            double d1 = double.Parse(value1);
            double d2 = double.Parse(value2);
            return d1 == d2;
        }
        else
        {
            return false;
        }
    }
}
