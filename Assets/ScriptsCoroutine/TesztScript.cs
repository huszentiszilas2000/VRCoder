using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesztScript : MonoBehaviour
{
    public float xRot;
    public float yRot;
    public float zRot;
    void Start()
    {
        
    }

    private void Update()
    {
        gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(xRot, yRot, zRot), 100f * Time.deltaTime);
    }
}
