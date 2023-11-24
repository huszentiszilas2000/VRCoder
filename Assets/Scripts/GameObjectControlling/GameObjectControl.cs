using UnityEngine;

public class GameObjectControl : MonoBehaviour
{
    public bool SetPosition = false;
    public bool Rotate = false;

    public float xRot;
    public float yRot;
    public float zRot;

    public float xPos;
    public float yPos;
    public float zPos;

    public bool Debug = false;

    private void Update()
    {
        if( Debug )
        {
            transform.Rotate(new Vector3(xRot, yRot, zRot));
            Debug = false;
        }
        if (SetPosition && GetComponent<Rigidbody>() != null && GetComponent<Rigidbody>().isKinematic == false)
        {
            GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(xPos, yPos, zPos));
            SetPosition = false;
            xPos = 0;
            yPos = 0;
            zPos = 0;
        }

        if (SetPosition && ( GetComponent<Rigidbody>() == null || GetComponent<Rigidbody>().isKinematic == true ) )
        {
            Vector3 temp = transform.TransformDirection(new Vector3(xPos, yPos, zPos));
            transform.position += temp;
            SetPosition = false;
            xPos = 0;
            yPos = 0;
            zPos = 0;
        }

        /*if (SmoothRotation)
        {
            transform.Rotate(new Vector3(xRot, yRot, zRot));
            SmoothRotation = false;
            /*if (transform.rotation.eulerAngles.x == xRot && transform.rotation.eulerAngles.y == yRot && transform.rotation.eulerAngles.z == zRot)
                Rotate = false;

            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(xRot, yRot, zRot), 100f * Time.deltaTime);
        }*/
        if(Rotate)
            transform.Rotate(new Vector3(xRot, yRot, zRot));
    }
}
