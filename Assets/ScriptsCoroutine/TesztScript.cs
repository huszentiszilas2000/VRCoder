using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesztScript : MonoBehaviour, ITest
{
    public GameObject nextCall;
    public int a = 0;
    public double i = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Application.targetFrameRate = 150;
    }

    public IEnumerator RunTest()
    {
        GameObject gameobject = GameObject.Find("tesztgomb");
        float lastTime = 0;
        Debug.Log("My method start:" + System.DateTime.Now.Minute + ":" + System.DateTime.Now.Second + ":" + System.DateTime.Now.Millisecond);
        while (i < 1000000000) //10 000 000 000
        {
            i++;
            lastTime += Time.deltaTime;
            if (lastTime > 250f)
            {
                lastTime = 0f;
                yield return new WaitForEndOfFrame();
            }
        }
        Debug.Log("My method end:" + System.DateTime.Now.Minute + ":" + System.DateTime.Now.Second + ":" + System.DateTime.Now.Millisecond);


        yield return new WaitForSeconds(3);
       /* i = 0;
        Debug.Log("Yield always start:" + Time.time);
        while (i < 100000) //10 000 000 000
        {
            i++;
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("Yield always end:" + Time.time);
       */
        i = 0;
        Debug.Log("Never yield start:" + System.DateTime.Now.Minute + ":" + System.DateTime.Now.Second + ":" + System.DateTime.Now.Millisecond);
        while (i < 1000000000) //10 000 000 000 - 100 000 000
        {
            i++;
        }
        Debug.Log("Never yield end:" + System.DateTime.Now.Minute + ":" + System.DateTime.Now.Second + ":" + System.DateTime.Now.Millisecond);

        //Debug.Log("Found 10! Finished in steps:" + i);
        if (nextCall != null)
        {
            StartCoroutine(nextCall.GetComponent<ITest>().RunTest());
        }

        yield return null;
    }

    public void Test()
    {
        GameObject.Find("tesztgomb").SetActive(true);
        StartCoroutine(RunTest());
        StopCoroutine(RunTest());
    }
}
