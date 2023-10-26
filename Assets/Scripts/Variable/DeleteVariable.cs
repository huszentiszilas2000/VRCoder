using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteVariable
{
    string variableName;
    public void DeleteVariableNotObject()
    {
        if ( variableName.Length == 0 )
        {
            Debug.LogError("Variable name is empty!");
            return;
        }

        if ( VisualCompiler.CheckVariableNameAvailibity(variableName) == true )
        {
            Debug.LogError("Variable does not exist: " + variableName);
            return;
        }

        VisualCompiler.variableObjects.Remove(variableName);
    }

}
