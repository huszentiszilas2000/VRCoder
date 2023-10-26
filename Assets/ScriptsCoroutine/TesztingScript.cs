using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesztingScript : MonoBehaviour, ITest
{
    public GameObject nextCall;
    public IEnumerator RunTest()
    {
        Debug.Log("Called");
        System.Random random = new System.Random();
        int a = 0;
        int i = 0;
        while (a != 30)
        {
            i++;
            a = random.Next(1, 100000);
        }
        Debug.Log("30 found!, Finished in steps:" + i);
        StartCoroutine(nextCall.GetComponent<ITest>().RunTest());
        yield return null;
    }
}
