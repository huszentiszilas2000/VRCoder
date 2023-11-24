using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesztingScript1 : MonoBehaviour, ITest
{
    public GameObject nextCall;
    public IEnumerator RunTest()
    {
        Debug.Log("TesztScript 1: Called");
        System.Random random = new System.Random();
        int a = 0;
        int i = 0;
        while (a != 30)
        {
            i++;
            a = random.Next(1, 100000);
        }
        Debug.Log("TesztScript 1: 30 found!, Finished in steps:" + i);
        //StartCoroutine(nextCall.GetComponent<ITest>().RunTest());
        yield return null;
    }
}
