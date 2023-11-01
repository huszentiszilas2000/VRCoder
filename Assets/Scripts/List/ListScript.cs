using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ListScript : MonoBehaviour
{
    public string listName;
    public List<System.Object> variables = new List<System.Object>();

    public TMP_Text listNameText;

    private void Update()
    {
        StartCoroutine(UpdateListVariable());
    }

    IEnumerator UpdateListVariable()
    {
        while (true)
        {
            listNameText.text = listName + "/Count:" + variables.Count;
            yield return new WaitForSeconds(1f);
        }
    }

    public System.Object GetItem(string itemToFind)
    {
        foreach(System.Object item in variables)
        {
            if (item.ToString().Equals(itemToFind))
                return item;
        }

        return null;
    }

    public double GetItemPlace(string itemToFind)
    {
        double counter = 0;
        foreach (System.Object item in variables)
        {
            counter++;
            if (item.ToString().Equals(itemToFind))
                return counter;
        }

        return counter;
    }

    public System.Object GetLength()
    {
        return (double)variables.Count;
    }
}
        
