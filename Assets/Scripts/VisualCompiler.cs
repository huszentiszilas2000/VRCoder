using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class VisualCompiler
{
    public static Dictionary<string, System.Object> variableObjects = new Dictionary<string, System.Object>();
    public static System.Random random = new System.Random();
    public VisualCompiler()
    {
        variableObjects = new Dictionary<string, System.Object>();
    }

    public static System.Object ConvertValueToCorrectObject(string value)
    {
        if (double.TryParse(value, out double d) == true)
        {
            return d;
        }
        else
        {
            return value;
        }
    }
    public static bool CheckVariableNameAvailibity(string name)
    {
        if ( variableObjects == null )
            return false;

        if ( variableObjects.ContainsKey(name) == false)
            return false;

        return true;
    }
}