using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject partObject, parentObject, plugObject;

    [SerializeField]
    [Range(0, 20)]
    float length = 0;

    [SerializeField]
    float partDistance = 0.1f;

    [SerializeField]
    bool spawn, firstPlug, lastPlug;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Spawn()
    {
        int count = (int)(length / partDistance);
        GameObject gm;
        gm = Instantiate(parentObject);
        if (gm.GetComponent<RopeMeshRenderer>() != null)
        {
            gm.GetComponent<RopeMeshRenderer>().UseFirstPlug = firstPlug;
            gm.GetComponent<RopeMeshRenderer>().UseLastPlug = lastPlug;
        }
        for(int i = 0; i < count; i++)
        {
            GameObject tmp;
            if(i == 0 && firstPlug)
            {
                tmp = Instantiate(plugObject, new Vector3(transform.position.x + partDistance * (i + 1), transform.position.y, transform.position.z), Quaternion.identity, gm.transform);
                tmp.transform.eulerAngles = new Vector3(0, 0, 90);
            }
            else if(i == (count-1) && lastPlug)
            {
                tmp = Instantiate(plugObject, new Vector3(transform.position.x + partDistance * (i + 1), transform.position.y, transform.position.z), Quaternion.identity, gm.transform);
                tmp.transform.eulerAngles = new Vector3(0, 180, 90);
            }
            else
            {
                tmp = Instantiate(partObject, new Vector3(transform.position.x + partDistance * (i + 1), transform.position.y, transform.position.z), Quaternion.identity, gm.transform);
                tmp.transform.eulerAngles = new Vector3(0, 0, 90);
            }
            tmp.name = gm.transform.childCount.ToString();
            if( i == 0 )
            {
                Destroy(tmp.GetComponent<CharacterJoint>());
            
            }
            else
            {
                tmp.GetComponent<CharacterJoint>().connectedBody = gm.transform.Find((gm.transform.childCount - 1).ToString()).GetComponent<Rigidbody>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(spawn)
        {
            spawn = false;
            Spawn();
        }
    }
}
