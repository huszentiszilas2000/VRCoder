using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AddTogether : Operator, IResult
{
    public System.Object GetResult()
    {
        if (variableFirst == null || variableSecond == null)
        {
            Debug.LogError("One of the object is missing");
            return null;
        }

        string value1 = "";
        string value2 = "";

        value1 = Operator.GetValueString(variableFirst);
        value2 = Operator.GetValueString(variableSecond);
      
        Type typeOf = Operator.GetObjectToConvert(variableFirst, variableSecond);
        if (typeOf == typeof(int))
        {
             return int.Parse(value1) + int.Parse(value2);
        }
        else if (typeOf == typeof(double))
        {
            return (double.Parse(value1) + double.Parse(value2));
        }
        else
        {
            return value1 + value2;
        }
    }
}
