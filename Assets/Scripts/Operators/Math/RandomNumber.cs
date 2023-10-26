using System;
using UnityEngine;

public class RandomNumber : Operator, IResult
{
    public System.Object GetResult()
    {
        if (variableFirst == null || variableSecond == null)
        {
            Debug.LogError("One of the object is missing");
            return null;
        }

        string value1 = Operator.GetValueString(variableFirst);
        string value2 = Operator.GetValueString(variableSecond);

        //Type typeOf = Operator.GetObjectToConvert(variableFirst, variableSecond);
        if (Operator.GetObjectToConvert(variableFirst, variableSecond) == typeof(int))
        {
            return VisualCompiler.random.Next(int.Parse(value1), int.Parse(value2) +1);
        }
        else if (Operator.GetObjectToConvert(variableFirst, variableSecond) == typeof(double))
        {
            double d1 = double.Parse(value1);
            double d2 = double.Parse(value2);
            return VisualCompiler.random.NextDouble() * ((d2 - d1) + d1);
        }
        else
        {
            return null;
        }
    }
}
