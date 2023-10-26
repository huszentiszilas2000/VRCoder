using TMPro;
using UnityEngine;
using System.Collections;

public class VariableWriter : MonoBehaviour
{
    public TMP_Text showText;

    void Start()
    {
        StartCoroutine(UpdateVariable());
    }

    IEnumerator UpdateVariable()
    {
        while (true)
        {
            showText.text = gameObject.transform.parent.GetComponent<VariableScript>().variableName + "/" + gameObject.transform.parent.GetComponent<VariableScript>().variableValue;
            yield return new WaitForSeconds(1f);
        }
    }

    /*void FixedUpdate()
    {
    }*/
}
