using System.Collections;
using UnityEngine;

public class DebuggingComponent : Component, IComponent
{
    public IEnumerator RunComponent()
    {
        Debug.Log("Debug Component!");
        yield return null;
    }
}
