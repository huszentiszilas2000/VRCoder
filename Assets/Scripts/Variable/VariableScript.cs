using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System;

public class VariableScript : MonoBehaviour, IResult
{
    public string variableName = "";
    public string variableValue = "";

    public System.Object GetResult()
    {
        return variableValue;
    }

}

