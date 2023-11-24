using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RopeConnector : MonoBehaviour
{
    public bool FirstConnected, LastConnected;
    public GameObject FirstObject;
    public GameObject LastObject;

    public void FreezeAll()
    {
        if(!FirstConnected || !LastConnected)
            return;

        for(int i = 0; i < transform.childCount; i++)
        {
            GameObject ropeLink = transform.GetChild(i).gameObject;
            if (ropeLink.GetComponent<Rigidbody>() == null)
                continue;

            //ropeLink.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    public void UnFreezeAll()
    {
        if (!FirstConnected || !LastConnected)
            return;

        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject ropeLink = transform.GetChild(i).gameObject;
            if (ropeLink.GetComponent<Rigidbody>() == null)
                continue;

            //ropeLink.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
}
