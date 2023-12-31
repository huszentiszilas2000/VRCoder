using TMPro;
using UnityEngine;

public class GameObjectControllerConnectors : MonoBehaviour
{
    public GameObject VariableConnector;
    public GameObject GameObjectConnector;


    public GameObject VariableOutConnector;

    public GameObject PreviousComponentConnector;
    public GameObject NextComponentConnector;

    public GameObject XYZComponent;

    public TMP_Text ComponentName;

    public void ChangeGameObjectController(GameObjectControllingType gameObjectControllingType)
    {
        switch (gameObjectControllingType)
        {
            case GameObjectControllingType.GetPosition:
                {
                    ComponentName.text = "GetPosition";
                    VariableConnector.SetActive(false);
                    GameObjectConnector.SetActive(true);
                    VariableOutConnector.SetActive(true);
                    PreviousComponentConnector.SetActive(false);
                    NextComponentConnector.SetActive(false);
                    XYZComponent.SetActive(true);
                    break;
                }
            case GameObjectControllingType.GetRotation:
                {
                    ComponentName.text = "GetRotation";
                    VariableConnector.SetActive(false);
                    GameObjectConnector.SetActive(true);
                    VariableOutConnector.SetActive(true);
                    PreviousComponentConnector.SetActive(false);
                    NextComponentConnector.SetActive(false);
                    XYZComponent.SetActive(true);
                    break;
                }
            case GameObjectControllingType.GetScale:
                {
                    ComponentName.text = "GetScale";
                    VariableConnector.SetActive(false);
                    GameObjectConnector.SetActive(true);
                    VariableOutConnector.SetActive(true);
                    PreviousComponentConnector.SetActive(false);
                    NextComponentConnector.SetActive(false); 
                    XYZComponent.SetActive(true);
                    break;
                }
            case GameObjectControllingType.SetPosition:
                {
                    ComponentName.text = "SetPosition";
                    VariableConnector.SetActive(true);
                    GameObjectConnector.SetActive(true);
                    VariableOutConnector.SetActive(false);
                    PreviousComponentConnector.SetActive(true);
                    NextComponentConnector.SetActive(true);
                    XYZComponent.SetActive(true);
                    break;
                }
            case GameObjectControllingType.Rotate:
                {
                    ComponentName.text = "RotateContinously";
                    VariableConnector.SetActive(true);
                    GameObjectConnector.SetActive(true);
                    VariableOutConnector.SetActive(false);
                    PreviousComponentConnector.SetActive(true);
                    NextComponentConnector.SetActive(true);
                    XYZComponent.SetActive(true);
                    break;
                }
            case GameObjectControllingType.RotateByDegress:
                {
                    ComponentName.text = "RotateByDegress";
                    VariableConnector.SetActive(true);
                    GameObjectConnector.SetActive(true);
                    VariableOutConnector.SetActive(false);
                    PreviousComponentConnector.SetActive(true);
                    NextComponentConnector.SetActive(true);
                    XYZComponent.SetActive(true);
                    break;
                }
            case GameObjectControllingType.SetScale:
                {
                    ComponentName.text = "SetScale";
                    VariableConnector.SetActive(true);
                    GameObjectConnector.SetActive(true);
                    VariableOutConnector.SetActive(false);
                    PreviousComponentConnector.SetActive(true);
                    NextComponentConnector.SetActive(true);
                    XYZComponent.SetActive(true);
                    break;
                }
            case GameObjectControllingType.SetName:
                {
                    ComponentName.text = "SetName";
                    VariableConnector.SetActive(true);
                    GameObjectConnector.SetActive(true);
                    VariableOutConnector.SetActive(false);
                    PreviousComponentConnector.SetActive(true);
                    NextComponentConnector.SetActive(true);
                    XYZComponent.SetActive(false);
                    break;
                }
            default:
                {
                    ComponentName.text = "Assert Gameobject controlling!!";
                    VariableConnector.SetActive(false);
                    GameObjectConnector.SetActive(false);
                    VariableOutConnector.SetActive(false);
                    PreviousComponentConnector.SetActive(false);
                    NextComponentConnector.SetActive(false);
                    XYZComponent.SetActive(false);
                    break;
                }
        }
    }
}
