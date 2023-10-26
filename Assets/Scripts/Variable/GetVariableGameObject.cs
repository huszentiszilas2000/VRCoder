using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetVariableGameObject : MonoBehaviour
{
    public GameObject variableGameObject;
    public string variableName;
    public string variableValue;
   public void GetVariable()
    {
        /*if (variableName.Length != 0 && VisualCompiler.variableObjects.ContainsKey(variableName) == false)
        {
            Debug.LogError("No variable named:" + variableName);
            return;
        }

        if( variableValue.Length == 0 && variableName.Length == 0)
        {
            return;
        }
        
        variableGameObject.transform.GetChild(0).gameObject.SetActive(true);
        variableGameObject.GetComponent<VariableScript>().variableName = variableName;
        if (variableName.Length == 0)
        {

            variableGameObject.GetComponent<VariableScript>().variableValue = variableValue;
        }
        else
        {
            variableGameObject.GetComponent<VariableScript>().variableValue = VisualCompiler.variableObjects[variableName].();
        }
        
        Instantiate(variableGameObject);*/
    }
}
