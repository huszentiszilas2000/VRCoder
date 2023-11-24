using System;
using System.Collections;
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

    [SerializeField]
    bool DebugChange = false;
    public IEnumerator RunComponent()
    {
        switch (gameObjectControllingType)
        {
            case GameObjectControllingType.SetPosition:
                StartCoroutine(SetPosition());
                break;
            case GameObjectControllingType.Rotate:
                StartCoroutine(Rotate());
                break;
            case GameObjectControllingType.RotateByDegress:
                StartCoroutine(RotateByDegress());
                break;
            case GameObjectControllingType.SetScale:
                StartCoroutine(SetScale());
                break;
            case GameObjectControllingType.SetName:
                StartCoroutine(SetName());
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
            Debug.LogError("GameObjectControlling: SetPosition: Gameobject is not connected");
            yield break;
        }

        if (correctVariableObject == null)
        {
            Debug.LogError("GameObjectControlling: SetPosition: Variable is not connected");
            yield break;
        }

        if (correctGameObjectObject.GetComponentInParent<GameObjectScript>() == null)
        {
            Debug.LogError("GameObjectControlling: SetPosition: Wrong type attached");
            yield break;
        }
        GameObject correctGameObjectToMove = correctGameObjectObject.GetComponentInParent<GameObjectScript>().variableGameObject;
        if (correctGameObjectToMove == null)
        {
            Debug.LogError("GameObjectControlling: SetPosition: Missing gameobject in the variable");
            yield break;
        }

        string value1 = Operator.GetValueString(correctVariableObject.gameObject);
        Type typeOf = Operator.GetObjectToConvert(correctVariableObject.gameObject);

        if (typeof(double) == typeOf)
        {
            switch (xYZChoice)
            {
                case XYZChoice.X:
                    correctGameObjectToMove.GetComponent<GameObjectControl>().xPos = float.Parse(value1);
                    correctGameObjectToMove.GetComponent<GameObjectControl>().SetPosition = true;
                    break;
                case XYZChoice.Y:
                    Debug.Log(value1);
                    correctGameObjectToMove.GetComponent<GameObjectControl>().yPos = float.Parse(value1);
                    correctGameObjectToMove.GetComponent<GameObjectControl>().SetPosition = true;
                    break;
                case XYZChoice.Z:
                    correctGameObjectToMove.GetComponent<GameObjectControl>().zPos = float.Parse(value1);
                    correctGameObjectToMove.GetComponent<GameObjectControl>().SetPosition = true;
                    break;
                default:
                    yield break;
            }
        }

        NextCall("SetPosition");
    }

    public IEnumerator Rotate()
    {
        correctGameObjectObject = gameObjectControllerConnectors.GameObjectConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        correctVariableObject = gameObjectControllerConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (correctGameObjectObject == null)
        {
            Debug.LogError("GameObjectControlling: Rotate: Gameobject is not connected");
            yield break;
        }

        if (correctVariableObject == null)
        {
            Debug.LogError("GameObjectControlling: Rotate: Variable is not connected");
            yield break;
        }

        if (correctGameObjectObject.GetComponentInParent<GameObjectScript>() == null)
        {
            Debug.LogError("GameObjectControlling: Rotate: Wrong type attached");
            yield break;
        }
        GameObject correctGameObjectToRotate = correctGameObjectObject.GetComponentInParent<GameObjectScript>().variableGameObject;
        if (correctGameObjectToRotate == null)
        {
            Debug.LogError("GameObjectControlling: Rotate: Missing gameobject in the variable");
            yield break;
        }

        string value1 = Operator.GetValueString(correctVariableObject.gameObject);
        Type typeOf = Operator.GetObjectToConvert(correctVariableObject.gameObject);

        if (typeof(double) == typeOf)
        {
            correctGameObjectToRotate.GetComponent<GameObjectControl>().Rotate = true;
            switch (xYZChoice)
            {
                case XYZChoice.X:
                    {
                        correctGameObjectToRotate.GetComponent<GameObjectControl>().xRot = float.Parse(value1);
                        break;
                    }
                case XYZChoice.Y:
                    {
                        correctGameObjectToRotate.GetComponent<GameObjectControl>().yRot = float.Parse(value1);
                        break;
                    }
                case XYZChoice.Z:
                    {
                        correctGameObjectToRotate.GetComponent<GameObjectControl>().zRot = float.Parse(value1);
                        break;
                    }
                default:
                    yield break;
            }
        }

        NextCall("Rotate");
    }

    public IEnumerator RotateByDegress()
    {
        correctGameObjectObject = gameObjectControllerConnectors.GameObjectConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        correctVariableObject = gameObjectControllerConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (correctGameObjectObject == null)
        {
            Debug.LogError("GameObjectControlling: RotateTowards: Gameobject is not connected");
            yield break;
        }

        if (correctVariableObject == null)
        {
            Debug.LogError("GameObjectControlling: RotateTowards: Variable is not connected");
            yield break;
        }

        if (correctGameObjectObject.GetComponentInParent<GameObjectScript>() == null)
        {
            Debug.LogError("GameObjectControlling: RotateTowards: Wrong type attached");
            yield break;
        }
        GameObject correctGameObjectToRotate = correctGameObjectObject.GetComponentInParent<GameObjectScript>().variableGameObject;
        if (correctGameObjectToRotate == null)
        {
            Debug.LogError("GameObjectControlling: RotateTowards: Missing gameobject in the variable");
            yield break;
        }

        string value1 = Operator.GetValueString(correctVariableObject.gameObject);
        Type typeOf = Operator.GetObjectToConvert(correctVariableObject.gameObject);

        if (typeof(double) == typeOf)
        {
            correctGameObjectToRotate.GetComponent<GameObjectControl>().Rotate = false;
            switch (xYZChoice)
            {
                case XYZChoice.X:
                    {
                        correctGameObjectToRotate.transform.Rotate(float.Parse(value1),0,0);
                        break;
                    }
                case XYZChoice.Y:
                    {
                        correctGameObjectToRotate.transform.Rotate(0,float.Parse(value1),0);
                        break;
                    }
                case XYZChoice.Z:
                    {
                        correctGameObjectToRotate.transform.Rotate(0,0,float.Parse(value1));
                        break;
                    }
                default:
                    yield break;
            }
        }

        NextCall("RotateByDegress");
    }

    public IEnumerator SetScale()
    {
        correctGameObjectObject = gameObjectControllerConnectors.GameObjectConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        correctVariableObject = gameObjectControllerConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (correctGameObjectObject == null)
        {
            Debug.LogError("GameObjectControlling: SetScale: Gameobject is not connected");
            yield break;
        }

        if (correctVariableObject == null)
        {
            Debug.LogError("GameObjectControlling: SetScale: Variable is not connected");
            yield break;
        }

        if (correctGameObjectObject.GetComponentInParent<GameObjectScript>() == null)
        {
            Debug.LogError("GameObjectControlling: SetScale: Wrong type attached");
            yield break;
        }
        GameObject correctGameObjectToScale = correctGameObjectObject.GetComponentInParent<GameObjectScript>().variableGameObject;
        if (correctGameObjectToScale == null)
        {
            Debug.LogError("GameObjectControlling: SetScale: Missing gameobject in the variable");
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
                        correctGameObjectToScale.transform.localScale += new Vector3(float.Parse(value1), 0, 0);
                        break;
                    }
                case XYZChoice.Y:
                    {
                        correctGameObjectToScale.transform.localScale += new Vector3(0, float.Parse(value1), 0);
                        break;
                    }
                case XYZChoice.Z:
                    {
                        correctGameObjectToScale.transform.localScale += new Vector3(0, 0, float.Parse(value1));
                        break;
                    }
                default:
                    yield break;
            }
        }

        NextCall("SetScale");

    }

    public IEnumerator SetName()
    {
        correctGameObjectObject = gameObjectControllerConnectors.GameObjectConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        correctVariableObject = gameObjectControllerConnectors.VariableConnector.GetComponent<RopeSocket>().GetComponentCorrect(gameObject);
        if (correctGameObjectObject == null)
        {
            Debug.LogError("GameObjectControlling: SetName: Gameobject is not connected");
            yield break;
        }

        if (correctVariableObject == null)
        {
            Debug.LogError("GameObjectControlling: SetName: Variable is not connected");
            yield break;
        }

        if (correctGameObjectObject.GetComponentInParent<GameObjectScript>() == null)
        {
            Debug.LogError("GameObjectControlling: SetName: Wrong type attached");
            yield break;
        }
        GameObject correctGameObjectToScale = correctGameObjectObject.GetComponentInParent<GameObjectScript>().variableGameObject;
        if (correctGameObjectToScale == null)
        {
            Debug.LogError("GameObjectControlling: SetName: Missing gameobject in the variable");
            yield break;
        }

        string value1 = Operator.GetValueString(correctVariableObject.gameObject);

        correctGameObjectToScale.name = value1;

        NextCall("SetName");
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
                return correctGameObjectObject.GetComponentInParent<GameObjectScript>().variableGameObject.transform.eulerAngles.x;
            case XYZChoice.Y:
                return correctGameObjectObject.GetComponentInParent<GameObjectScript>().variableGameObject.transform.eulerAngles.y;
            case XYZChoice.Z:
                return correctGameObjectObject.GetComponentInParent<GameObjectScript>().variableGameObject.transform.eulerAngles.z;
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
   Rotate,
   RotateByDegress,
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
