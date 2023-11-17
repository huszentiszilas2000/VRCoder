using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuCategoryHandler : MonoBehaviour
{
    public TMP_Text categoryName;
    public TMP_Text categoryChildName;
    public GameObject components;
    public GameObject cables;
    public GameObject variables;
    public GameObject objects;
    public GameObject operators;
    public GameObject panelCable;
    public GameObject panelGameObjects;
    public GameObject panelVariable;
    public GameObject panelListVariable;

    public void OnValueChange()
    {
        switch(categoryName.text)
        {
            case "Components":
                components.SetActive(true);
                cables.SetActive(false);
                variables.SetActive(false);
                objects.SetActive(false);
                operators.SetActive(false);
                panelCable.SetActive(false);
                panelVariable.SetActive(false);
                panelListVariable.SetActive(false);
                panelGameObjects.SetActive(false);
                break;
            case "Cables":
                components.SetActive(false);
                cables.SetActive(true);
                variables.SetActive(false);
                objects.SetActive(false);
                operators.SetActive(false);
                panelCable.SetActive(true);
                panelVariable.SetActive(false);
                panelListVariable.SetActive(false);
                panelGameObjects.SetActive(false);
                break;
            case "Variables":
                {
                    components.SetActive(false);
                    cables.SetActive(false);
                    variables.SetActive(true);
                    objects.SetActive(false);
                    operators.SetActive(false);
                    panelCable.SetActive(false);
                    panelGameObjects.SetActive(false);
                    if (categoryChildName.text == "Variable")
                    {
                        panelVariable.SetActive(true);
                        panelListVariable.SetActive(false);
                    }
                    else if(categoryChildName.text == "List")
                    {
                        panelVariable.SetActive(false);
                        panelListVariable.SetActive(true);
                    }
                    break;
                }
            case "GameObjects":
                components.SetActive(false);
                cables.SetActive(false);
                variables.SetActive(false);
                objects.SetActive(true);
                operators.SetActive(false);
                panelCable.SetActive(false);
                panelVariable.SetActive(false);
                panelListVariable.SetActive(false);
                panelGameObjects.SetActive(true);
                break;
            case "Operator":
                components.SetActive(false);
                cables.SetActive(false);
                variables.SetActive(false);
                objects.SetActive(false);
                operators.SetActive(true);
                panelCable.SetActive(false);
                panelVariable.SetActive(false);
                panelListVariable.SetActive(false);
                panelGameObjects.SetActive(false);
                break;
            default:
                break;
        }
    }
}
