using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectControlling : MonoBehaviour, IComponent, IResult
{
    public XYZChoice xYZChoice;
    [SerializeField]
    GameObjectControllingType gameObjectControllingType;

    GameObjectControllerConnectors gameObjectControllerConnectors;

    public bool DebugChange = false;
    public IEnumerator RunComponent()
    {
        switch (gameObjectControllingType)
        {
            case GameObjectControllingType.GetPosition:
                break;
            case GameObjectControllingType.GetRotation:
                break;
            case GameObjectControllingType.GetScale:
                break;
            case GameObjectControllingType.SetPosition:
                break;
            case GameObjectControllingType.SetRotation:
                break;
            case GameObjectControllingType.SetScale:
                break;
            case GameObjectControllingType.SetName:
                break;
            default:
                break;
        }
        yield return null;
    }

    void Start()
    {
        gameObjectControllerConnectors = GetComponent<GameObjectControllerConnectors>();
        OnChangeGameObjectControllerPressed();
    }

    void Update()
    {
        if (DebugChange)
        {
            OnChangeGameObjectControllerPressed();
            DebugChange = false;
        }
    }

    public System.Object GetResult()
    {
        return 0;
    }

    public void ChangeXYZ(int inXYZ)
    {
        switch(inXYZ)
        {
            case 0:
                xYZChoice = XYZChoice.X;
                break;
            case 1:
                xYZChoice = XYZChoice.Y;
                break;
            case 2:
                xYZChoice = XYZChoice.Z;
                break;
            default:
                xYZChoice = XYZChoice.X;
                break;
        }
    }

    public void OnChangeGameObjectControllerPressed()
    {
        if (gameObjectControllerConnectors.HasConnection() == true)
        {
            Debug.LogError("Cannot change gameobject controller with connections!");
            return;
        }

        if (gameObjectControllingType == GameObjectControllingType.SetName)
        {
            gameObjectControllingType = 0;
            gameObjectControllerConnectors.ChangeGameObjectController(gameObjectControllingType);
            return;
        }
        gameObjectControllingType += 1;
        gameObjectControllerConnectors.ChangeGameObjectController(gameObjectControllingType);
    }

}

public enum GameObjectControllingType
{
   SetPosition,
   GetPosition,
   SetRotation,
   GetRotation,
   SetScale,
   GetScale,
   SetName
}

public enum XYZChoice
{
    X,
    Y,
    Z
}
