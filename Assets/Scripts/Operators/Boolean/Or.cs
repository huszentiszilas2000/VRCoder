using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Or : Operator, IResultBoolean
{
    public bool GetResult()
    {
        if (variableFirst == null || variableSecond == null)
        {
            Debug.LogError("One of the object is missing");
            return false;
        }

        if (variableFirst.GetComponent<IResultBoolean>() == null || variableSecond.GetComponent<IResultBoolean>() == null)
        {
            Debug.LogError("One of the object is not Boolean type!");
            return false;
        }

        bool bValue1 = variableFirst.GetComponent<IResultBoolean>().GetResult();
        bool bValue2 = variableSecond.GetComponent<IResultBoolean>().GetResult();

        if (bValue1 == true || bValue2 == true)
            return true;

        return false;
    }
}
