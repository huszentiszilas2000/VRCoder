using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRRemoveSameSideCollider : MonoBehaviour
{
    XRSocketInteractor asd;
    public bool SocketLeft;
    public bool SocketRight;
    public GameObject connected;
    // Start is called before the first frame update
    void Start()
    {
        asd = GetComponent<XRSocketInteractor>();
    }

    public void Teszt()
    {
        if (SocketLeft)
            asd.interactablesSelected[0].transform.Find("SocketRight").gameObject.SetActive(false);
        else if (SocketRight)
            asd.interactablesSelected[0].transform.Find("SocketLeft").gameObject.SetActive(false);
        else
            return;

        connected = asd.interactablesSelected[0].transform.gameObject;

    }

    public void TesztDisconnect()
    {
        if (SocketLeft)
            connected.transform.Find("SocketRight").gameObject.SetActive(true);
        else if (SocketRight)
            connected.transform.Find("SocketLeft").gameObject.SetActive(true);
        else
            return;

        connected = null;

    }
}
