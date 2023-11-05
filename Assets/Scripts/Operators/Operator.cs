using System;
using System.Collections.Generic;
using UnityEngine;

public class Operator : MonoBehaviour
{
    public GameObject variableFirst;
    public GameObject variableSecond;

    public static System.Random random = new System.Random();

    public static string GetValueString(GameObject gameObject)
    {
        return gameObject.GetComponentInParent<IResult>().GetResult().ToString();
    }

    public static bool GetBool(GameObject gameObject)
    {
        return gameObject.GetComponentInParent<IResultBoolean>().GetResult();
    }

    public static Type GetObjectToConvert(GameObject gameObject)
    {
        if (gameObject == null)
            return null;

        System.Object object1 = VisualCompiler.ConvertValueToCorrectObject(Operator.GetValueString(gameObject));

        if(object1 == null)
            return null;

        if (object1.GetType() == typeof(string))
            return typeof(string);
        else if (object1.GetType() == typeof(double))
            return typeof(double);
        else
        {
            Debug.LogError("Assert: Wrong Type somehow???");
            return typeof(System.Object);
        }
    }

    public static Type GetObjectsToConvert(GameObject gameObject, GameObject gameObject2)
    {
        System.Object object1 = VisualCompiler.ConvertValueToCorrectObject(Operator.GetValueString(gameObject));
        System.Object object2 = VisualCompiler.ConvertValueToCorrectObject(Operator.GetValueString(gameObject2));

        if (object1.GetType() == typeof(string) || object2.GetType() == typeof(string))
            return typeof(string);
        else if (object1.GetType() == typeof(double) || object2.GetType() == typeof(double))
            return typeof(double);
        else
        {
            Debug.LogError("Assert: Wrong Type somehow???");
            return typeof(System.Object);
        }
    }
}
