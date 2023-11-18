using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameObjectNameWriter : MonoBehaviour
{
    public TMP_Text nameObject;

    private void Start()
    {
        StartCoroutine(NameWriter());
    }


    IEnumerator NameWriter()
    {
        while(true)
        {
            if (GetComponentInParent<GameObjectScript>().variableGameObject != null)
                nameObject.text = GetComponentInParent<GameObjectScript>().variableGameObject.name;
            else
                nameObject.text = "";

            yield return new WaitForSeconds(2f);
        }
    }
}
