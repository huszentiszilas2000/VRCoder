using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyScript : MonoBehaviour
{
    [SerializeField]
    public GameObject copyObject;

    private void Start()
    {
        copyObject = transform.gameObject;
    }

    public void Copy()
    {
        if (copyObject == null)
        {
            Debug.LogError("Assert: Copy script is missing object");
        }
        Instantiate(copyObject, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity, transform.parent);
    }
}
