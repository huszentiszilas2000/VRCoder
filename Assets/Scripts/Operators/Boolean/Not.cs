using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Not : Operator, IResultBoolean
{
    public bool GetResult()
    {
        if (variableFirst == null )
        {
            Debug.LogError("Object is missing");
            return false;
        }

        if (variableFirst.GetComponent<IResultBoolean>() == null )
        {
            Debug.LogError("One of the object is not Boolean type!");
            return false;
        }

        bool bValue1 = variableFirst.GetComponent<IResultBoolean>().GetResult();

        if (bValue1 == true )
            return false;

        return true;
    }
}
