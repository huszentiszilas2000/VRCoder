using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectControl : MonoBehaviour
{
    public bool SetPosition = false;
    public bool SmoothRotation = false;

    public float xRot;
    public float yRot;
    public float zRot;

    public float xPos;
    public float yPos;
    public float zPos;

    private void Update()
    {
        if (SetPosition && GetComponent<Rigidbody>().isKinematic == false)
        {
            GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(xPos, yPos, zPos));
            SetPosition = false;
        }

        if (SetPosition && GetComponent<Rigidbody>().isKinematic == true)
        {
            Vector3 temp = transform.TransformDirection(new Vector3(xPos, yPos, zPos));
            transform.position += temp;
            SetPosition = false;
        }

        if (SmoothRotation)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(xRot, yRot, zRot), 100f * Time.deltaTime);
        else
            transform.Rotate(new Vector3(xRot, yRot, zRot));
    }
}
