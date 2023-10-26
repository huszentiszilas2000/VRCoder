using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RopeSocket : MonoBehaviour
{
    XRSocketInteractor xRSocket;
    public GameObject ropeObject;
    private void Start()
    {
        xRSocket = GetComponent<XRSocketInteractor>();
    }

    public void RopeFrezee()
    {
        if (xRSocket.interactablesSelected.Count == 0)
        {
            Debug.LogError("Connector Assert");
            return;
        }
        GetRopeObject();
        if( ropeObject.GetComponent<RopeConnector>().FirstConnected )
        {
            ropeObject.GetComponent<RopeConnector>().LastConnected = true;
            ropeObject.GetComponent<RopeConnector>().LastObject = this.gameObject;
        }
        else
        {
            ropeObject.GetComponent<RopeConnector>().FirstConnected = true;
            ropeObject.GetComponent<RopeConnector>().FirstObject = this.gameObject;
        }
        ropeObject.GetComponent<RopeConnector>().FreezeAll();
    }

    public void GetRopeObject()
    {
        ropeObject = xRSocket.interactablesSelected[0].transform.parent.gameObject;
    }

    public GameObject GetComponentCorrect(GameObject parent)
    {
        if( parent == null )
        {
            Debug.Log("Rope Socket: No parent is called");
            return null;
        }

        if( ropeObject == null )
        {
            Debug.LogError("Rope Socket: No rope is connected!");
            return null;
        }

        if( ropeObject.GetComponent<RopeConnector>() == null )
        {
            Debug.LogError("Rope Socket: Missing connector!");
            return null;
        }

        if(ropeObject.GetComponent<RopeConnector>().FirstObject == null || ropeObject.GetComponent<RopeConnector>().LastObject == null )
        {
            Debug.Log("Rope Socket: One of the side is not connected!");
            return null;
        }

        if(ropeObject.GetComponent<RopeConnector>().FirstObject.gameObject.GetHashCode().Equals(gameObject.GetHashCode()))
        {
            return ropeObject.GetComponent<RopeConnector>().LastObject;
        }

        return ropeObject.GetComponent<RopeConnector>().FirstObject;
    }

    void RemoveRopeObject()
    {
        if(ropeObject.GetComponent<RopeConnector>().LastObject != null && ropeObject.GetComponent<RopeConnector>().LastObject.gameObject.GetHashCode().Equals(gameObject.GetHashCode()))
        {
            ropeObject.GetComponent<RopeConnector>().LastConnected = false;
            ropeObject.GetComponent<RopeConnector>().LastObject = null;
        }
        else if(ropeObject.GetComponent<RopeConnector>().FirstObject != null && ropeObject.GetComponent<RopeConnector>().FirstObject.gameObject.GetHashCode().Equals(gameObject.GetHashCode()))
        {
            ropeObject.GetComponent<RopeConnector>().FirstConnected = false;
            ropeObject.GetComponent<RopeConnector>().FirstObject = null;
        }

        ropeObject = null;
    }

    public void RopeUnfreeze()
    {
        ropeObject.GetComponent<RopeConnector>().UnFreezeAll();
        RemoveRopeObject();
    }
}
