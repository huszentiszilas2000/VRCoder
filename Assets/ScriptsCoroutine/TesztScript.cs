using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesztScript : MonoBehaviour
{
    public float xRot;
    public float yRot;
    public float zRot;

    public float xPos;
    public float yPos;
    public float zPos;

    public bool DebugS = false;
    public bool SmoothRotation = false;

    void Start()
    {
        if(SmoothRotation)
        {
            xRot = transform.eulerAngles.x;
            yRot = transform.eulerAngles.y;
            zRot = transform.eulerAngles.z;
        }
    //StartCoroutine(Move());
    }

    public IEnumerator Move()
    {
        while(true)
        {
            GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(xPos, yPos, zPos));
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void Update()
    {
        if(DebugS && GetComponent<Rigidbody>().isKinematic == false)
        {
            GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(xPos, yPos, zPos));
            DebugS = false;
        }

        if(DebugS && GetComponent<Rigidbody>().isKinematic == true)
        {
            Vector3 temp = transform.TransformDirection(new Vector3(xPos, yPos, zPos));
            transform.position += temp;
            DebugS = false;
        }

        if (SmoothRotation)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(xRot, yRot, zRot), 100f * Time.deltaTime);
        else
            transform.Rotate(new Vector3(xRot, yRot, zRot));
    }
}
