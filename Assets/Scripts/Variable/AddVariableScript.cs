using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddVariableScript : MonoBehaviour
{
    public TMP_Text variableNameText;
    public TMP_Text variableValueText;
    public string variableValue;
    public string variableName;
    public void AddVariableNotObject()
    {
        variableName = variableNameText.text;
        variableValue = variableValueText.text;
        if (variableValue.Length == 0 || variableName.Length == 0 )
        {
            Debug.LogError("Variable value or name is empty!");
            return;
        }

        if (VisualCompiler.CheckVariableNameAvailibity(variableName) == true )
        {
            Debug.LogError("Variable already exist: " + variableName + ".");
            return;
        }

        VisualCompiler.variableObjects.Add(variableName.ToString(), VisualCompiler.ConvertValueToCorrectObject(variableValue));
        FindVariable();
    }

    void FindVariable()
    {
        foreach(VariableScript variableScript in FindObjectsOfType<VariableScript>())
        {
            Debug.Log(variableScript.variableName);
        }
    }
}
