using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectControlling : MonoBehaviour, IComponent, IResult
{
    public XYZChoice xYZChoice;
    [SerializeField]
    GameObjectControllingType gameObjectControllingType;

    GameObjectControllerConnectors gameObjectControllerConnectors;

    GameObject correctGameObjectObject;
    GameObject correctVariableObject;
    GameObject correctNextCallObject;

    public bool DebugChange = false;
    public IEnumerator RunComponent()
    {
        switch (gameObjectControllingType)
        {
            case GameObjectControllingType.SetPosition:
                StartCoroutine(SetPosition());
                break;
            case GameObjectControllingType.SetRotation:
                StartCoroutine(SetRotation());
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

    public IEnumerator SetPosition()
    {
        correctGameObjectObject = gameObjectControllerConnectors.GameObjectConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        correctVariableObject = gameObjectControllerConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (correctGameObjectObject == null)
        {
            Debug.LogError("GameObjectControlling: GetPosition: Gameobject is not connected");
            yield break;
        }

        if (correctVariableObject == null)
        {
            Debug.LogError("GameObjectControlling: GetPosition: Variable is not connected");
            yield break;
        }

        if (correctGameObjectObject.GetComponentInParent<GameObjectScript>() == null)
        {
            Debug.LogError("GameObjectControlling: GetPosition: Wrong type attached");
            yield break;
        }
        GameObject correctGameObjectToMove = correctGameObjectObject.GetComponentInParent<GameObjectScript>().variableGameObject;
        if (correctGameObjectToMove == null)
        {
            Debug.LogError("GameObjectControlling: GetPosition: Missing gameobject in the variable");
            yield break;
        }

        string value1 = Operator.GetValueString(correctVariableObject.gameObject);
        Type typeOf = Operator.GetObjectToConvert(correctVariableObject.gameObject);

        if (typeof(double) == typeOf)
        {
            switch (xYZChoice)
            {
                case XYZChoice.X:
                    correctGameObjectToMove.GetComponent<Rigidbody>().MovePosition(new Vector3(correctGameObjectToMove.transform.position.x + float.Parse(value1), correctGameObjectToMove.transform.position.y, correctGameObjectToMove.transform.position.z));
                    break;
                case XYZChoice.Y:
                    correctGameObjectToMove.GetComponent<Rigidbody>().MovePosition(new Vector3(correctGameObjectToMove.transform.position.x, correctGameObjectToMove.transform.position.y + float.Parse(value1), correctGameObjectToMove.transform.position.z));
                    break;
                case XYZChoice.Z:
                    correctGameObjectToMove.GetComponent<Rigidbody>().MovePosition(new Vector3(correctGameObjectToMove.transform.position.x, correctGameObjectToMove.transform.position.y, correctGameObjectToMove.transform.position.z + float.Parse(value1)));
                    break;
                default:
                    yield break;
            }
        }

        NextCall("SetPosition");
    }

    public IEnumerator SetRotation()
    {
        correctGameObjectObject = gameObjectControllerConnectors.GameObjectConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        correctVariableObject = gameObjectControllerConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (correctGameObjectObject == null)
        {
            Debug.LogError("GameObjectControlling: SetRotation: Gameobject is not connected");
            yield break;
        }

        if (correctVariableObject == null)
        {
            Debug.LogError("GameObjectControlling: SetRotation: Variable is not connected");
            yield break;
        }

        if (correctGameObjectObject.GetComponentInParent<GameObjectScript>() == null)
        {
            Debug.LogError("GameObjectControlling: SetRotation: Wrong type attached");
            yield break;
        }
        GameObject correctGameObjectToMove = correctGameObjectObject.GetComponentInParent<GameObjectScript>().variableGameObject;
        if (correctGameObjectToMove == null)
        {
            Debug.LogError("GameObjectControlling: SetRotation: Missing gameobject in the variable");
            yield break;
        }

        string value1 = Operator.GetValueString(correctVariableObject.gameObject);
        Type typeOf = Operator.GetObjectToConvert(correctVariableObject.gameObject);

        if (typeof(double) == typeOf)
        {
            switch (xYZChoice)
            {
                case XYZChoice.X:
                    {
                        Vector3 rotationToAdd = new Vector3(float.Parse(value1),0,0);
                        correctGameObjectToMove.transform.Rotate(rotationToAdd);
                        break;
                    }
                case XYZChoice.Y:
                    {
                        Vector3 rotationToAdd = new Vector3(0, float.Parse(value1), 0);
                        correctGameObjectToMove.transform.Rotate(rotationToAdd);
                        break;
                    }
                case XYZChoice.Z:
                    {
                        Vector3 rotationToAdd = new Vector3(0, 0, float.Parse(value1));
                        correctGameObjectToMove.transform.Rotate(rotationToAdd);
                        break;
                    }
                default:
                    yield break;
            }
        }

        NextCall("SetRotation");
    }

    public void NextCall(string previousCall)
    {
        if (gameObjectControllerConnectors.NextComponentConnector.GetComponent<RopeSocket>().ropeObject == null)
        {
            Debug.LogWarning(previousCall + ": No next call is connected");
            return;
        }

        correctNextCallObject = gameObjectControllerConnectors.NextComponentConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (correctNextCallObject != null)
            StartCoroutine(correctNextCallObject.GetComponentInParent<IComponent>().RunComponent());
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
        switch (gameObjectControllingType)
        {
            case GameObjectControllingType.GetPosition:
                return GetPosition();
            case GameObjectControllingType.GetRotation:
                return GetPosition();
            case GameObjectControllingType.GetScale:
                return GetScale();
        }

        return null;
    }

    public double GetPosition()
    {
        correctGameObjectObject = gameObjectControllerConnectors.GameObjectConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if(correctGameObjectObject == null )
        {
            Debug.LogError("GameObjectControlling: GetPosition: Gameobject is not connected");
            return 0f;
        }

        if( correctGameObjectObject.GetComponentInParent<GameObjectScript>() == null)
        {
            Debug.LogError("GameObjectControlling: GetPosition: Wrong type attached");
            return 0f;
        }

        if( correctGameObjectObject.GetComponentInParent<GameObjectScript>().variableGameObject == null )
        {
            Debug.LogError("GameObjectControlling: GetPosition: Missing gameobject in the variable");
            return 0f;
        }

        switch(xYZChoice)
        {
            case XYZChoice.X:
                return correctGameObjectObject.GetComponentInParent<GameObjectScript>().variableGameObject.transform.position.x;
            case XYZChoice.Y:
                return correctGameObjectObject.GetComponentInParent<GameObjectScript>().variableGameObject.transform.position.y;
            case XYZChoice.Z:
                return correctGameObjectObject.GetComponentInParent<GameObjectScript>().variableGameObject.transform.position.z;
            default:
                return 0f;
        }    
    }

    public double GetRotation()
    {
        correctGameObjectObject = gameObjectControllerConnectors.GameObjectConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (correctGameObjectObject == null)
        {
            Debug.LogError("GameObjectControlling: GetPosition: Gameobject is not connected");
            return 0f;
        }

        if (correctGameObjectObject.GetComponentInParent<GameObjectScript>() == null)
        {
            Debug.LogError("GameObjectControlling: GetPosition: Wrong type attached");
            return 0f;
        }

        if (correctGameObjectObject.GetComponentInParent<GameObjectScript>().variableGameObject == null)
        {
            Debug.LogError("GameObjectControlling: GetPosition: Missing gameobject in the variable");
            return 0f;
        }

        switch (xYZChoice)
        {
            case XYZChoice.X:
                return correctGameObjectObject.GetComponentInParent<GameObjectScript>().variableGameObject.transform.rotation.x;
            case XYZChoice.Y:
                return correctGameObjectObject.GetComponentInParent<GameObjectScript>().variableGameObject.transform.rotation.y;
            case XYZChoice.Z:
                return correctGameObjectObject.GetComponentInParent<GameObjectScript>().variableGameObject.transform.rotation.z;
            default:
                return 0f;
        }
    }

    public double GetScale()
    {
        correctGameObjectObject = gameObjectControllerConnectors.GameObjectConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (correctGameObjectObject == null)
        {
            Debug.LogError("GameObjectControlling: GetPosition: Gameobject is not connected");
            return 0f;
        }

        if (correctGameObjectObject.GetComponentInParent<GameObjectScript>() == null)
        {
            Debug.LogError("GameObjectControlling: GetPosition: Wrong type attached");
            return 0f;
        }

        if (correctGameObjectObject.GetComponentInParent<GameObjectScript>().variableGameObject == null)
        {
            Debug.LogError("GameObjectControlling: GetPosition: Missing gameobject in the variable");
            return 0f;
        }

        switch (xYZChoice)
        {
            case XYZChoice.X:
                return correctGameObjectObject.GetComponentInParent<GameObjectScript>().variableGameObject.transform.localScale.x;
            case XYZChoice.Y:
                return correctGameObjectObject.GetComponentInParent<GameObjectScript>().variableGameObject.transform.localScale.y;
            case XYZChoice.Z:
                return correctGameObjectObject.GetComponentInParent<GameObjectScript>().variableGameObject.transform.localScale.z;
            default:
                return 0f;
        }
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
