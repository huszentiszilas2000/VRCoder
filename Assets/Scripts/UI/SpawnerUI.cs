using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class SpawnerUI : MonoBehaviour
{
    public TMP_Text categoryName;
    public TMP_Text categoryChildComponentName;
    public TMP_Text categoryChildVariableName;
    public TMP_Text categoryChildGameObjectName;
    public TMP_Text categoryChildCableName;
    public TMP_Text categoryChildOperatorName;
    public TMP_Text listName;
    public TMP_Text variableName;
    public TMP_Text variableValue;
    public Slider sliderLength;
    public TMP_Text objectName;
    public Toggle togglePhysics;
    public Toggle toggleInteractable;

    public GameObject spawnPoint;

    public GameObject component;
    public GameObject listcomponent;
    public GameObject gamecontrollcomponent;
    public GameObject startbuttoncomponent;
    public GameObject stopbuttoncomponent;

    public GameObject ropeComponentSpawner;
    public GameObject variableRopeComponentSpawner;
    public GameObject listRopeComponentSpawner;
    public GameObject gameobjectRopeComponentSpawner;
    public GameObject booleanRopeComponentSpawner;

    public GameObject cubeObject;
    public GameObject sphereObject;
    public GameObject capsuleObject;
    public GameObject cylinderObject;

    public GameObject mathOperatorObject;
    public GameObject booleanOperatorObject;

    public GameObject variableObject;
    public GameObject listvariableObject;
    public GameObject gameObjectvariableObject;

    public void Spawn()
    {
        GameObject spawned = null;
        switch(categoryName.text)
        {
            case "Components":
                {
                    switch(categoryChildComponentName.text)
                    {
                        case "Component":
                            spawned = Instantiate(component, spawnPoint.transform);
                            spawned.transform.SetParent(null);
                            break;
                        case "List Component":
                            spawned = Instantiate(listcomponent, spawnPoint.transform);
                            spawned.transform.SetParent(null);
                            break;
                        case "Object Control":
                            spawned = Instantiate(gamecontrollcomponent, spawnPoint.transform);
                            spawned.transform.SetParent(null);
                            break;
                        case "Start Button":
                            spawned = Instantiate(startbuttoncomponent, spawnPoint.transform);
                            spawned.transform.SetParent(null);
                            break;
                        case "Stop Button":
                            spawned = Instantiate(stopbuttoncomponent, spawnPoint.transform);
                            spawned.transform.SetParent(null);
                            break;
                    }
                    break;
                }
            case "Variables":
                {
                    switch (categoryChildVariableName.text)
                    {
                        case "Variable":
                            if (variableValue.text.Length == 0 || variableValue.text.Length == 1)
                                break;

                            spawned = Instantiate(variableObject, spawnPoint.transform);
                            spawned.transform.SetParent(null);
                            spawned.GetComponent<VariableScript>().variableName = variableName.text.ToString();
                            spawned.GetComponent<VariableScript>().variableValue = variableValue.text.ToString().Substring(0, variableValue.text.Length-1);
                            break;
                        case "List":
                            spawned = Instantiate(listvariableObject, spawnPoint.transform);
                            spawned.transform.SetParent(null);
                            spawned.GetComponent<ListScript>().listName = listName.text.ToString();
                            break;
                    }
                    break;
                }
            case "Cables":
                {
                    switch (categoryChildCableName.text)
                    {
                        case "Variable Cable":
                            variableRopeComponentSpawner.GetComponent<RopeSpawn>().length = sliderLength.value;
                            variableRopeComponentSpawner.GetComponent<RopeSpawn>().Spawn();
                            break;
                        case "List Cable":
                            listRopeComponentSpawner.GetComponent<RopeSpawn>().length = sliderLength.value;
                            listRopeComponentSpawner.GetComponent<RopeSpawn>().Spawn();
                            break;
                        case "Component Cable":
                            ropeComponentSpawner.GetComponent<RopeSpawn>().length = sliderLength.value;
                            ropeComponentSpawner.GetComponent<RopeSpawn>().Spawn();
                            break;
                        case "GameObject Cable":
                            gameobjectRopeComponentSpawner.GetComponent<RopeSpawn>().length = sliderLength.value;
                            gameobjectRopeComponentSpawner.GetComponent<RopeSpawn>().Spawn();
                            break;
                        case "Boolean Cable":
                            booleanRopeComponentSpawner.GetComponent<RopeSpawn>().length = sliderLength.value;
                            booleanRopeComponentSpawner.GetComponent<RopeSpawn>().Spawn();
                            break;
                    }
                    break;
                }
            case "Operator":
                {
                    switch (categoryChildOperatorName.text)
                    {
                        case "Boolean":
                            spawned = Instantiate(booleanOperatorObject, spawnPoint.transform);
                            spawned.transform.SetParent(null);
                            break;
                        case "Math":
                            spawned = Instantiate(mathOperatorObject, spawnPoint.transform);
                            spawned.transform.SetParent(null);
                            break;
                    }
                    break;
                }
            case "GameObjects":
                {
                    if (objectName.text.Length == 0 || objectName.text.Length == 1)
                        break;

                    switch (categoryChildGameObjectName.text)
                    {
                        case "Cube":
                            spawned = Instantiate(cubeObject, spawnPoint.transform);
                            break;
                        case "Sphere":
                            spawned = Instantiate(sphereObject, spawnPoint.transform);
                            break;
                        case "Capsule":
                            spawned = Instantiate(capsuleObject, spawnPoint.transform);
                            break;
                        case "Cylinder":
                            spawned = Instantiate(cylinderObject, spawnPoint.transform);
                            break;
                    }
                    GameObject objectComponent = Instantiate(gameObjectvariableObject, spawnPoint.transform);
                    objectComponent.transform.SetParent(null);
                    objectComponent.GetComponent<GameObjectScript>().variableGameObject = spawned;
                    objectComponent.transform.position = new Vector3(objectComponent.transform.position.x, objectComponent.transform.position.y + 0.3f, objectComponent.transform.position.z);
                    spawned.name = objectName.text;
                    spawned.transform.SetParent(null);
                    spawned.GetComponent<Rigidbody>().useGravity = togglePhysics.isOn;
                    spawned.GetComponent<Rigidbody>().isKinematic = !togglePhysics.isOn;
                    spawned.GetComponent<XRGrab>().enabled = toggleInteractable.isOn;
                    if(togglePhysics.isOn && toggleInteractable.isOn)
                    {
                        spawned.GetComponent<XRGrab>().movementType = XRBaseInteractable.MovementType.VelocityTracking;
                    }
                    else if(toggleInteractable.isOn && !togglePhysics.isOn)
                    {
                        spawned.GetComponent<XRGrab>().movementType = XRBaseInteractable.MovementType.Kinematic;
                    }
                    break;
                }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
