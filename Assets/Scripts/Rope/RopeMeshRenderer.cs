using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeMeshRenderer : MonoBehaviour
{
    Mesh mesh;
    List<Vector3> vertices;
    List<int> triangles;
    public GameObject point;
    public bool DebugPoints;
    public bool UseFirstPlug;
    public bool UseLastPlug;
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        vertices = new List<Vector3>();
        triangles = new List<int>();
    }

    void Update()
    {
        transform.position = new Vector3(0, 0, 0);
        GameObject[] renderPoints = GameObject.FindGameObjectsWithTag("RenderPoint");
        foreach (GameObject renderPoint in renderPoints)
            Destroy(renderPoint);

        mesh.Clear();
        vertices.Clear();
        triangles.Clear();
        GameObject parent = new GameObject();
        parent.name = "RenderPoints";
        parent.tag = "RenderPoint";

        for (int i = 0; i < this.transform.childCount; i++)
        {
            GameObject gmChild = transform.GetChild(i).gameObject;
            float radius = transform.GetChild(1).gameObject.GetComponent<SphereCollider>().radius;

            if (radius == 0f)
                break;

            if (UseFirstPlug && i == 0)
            {
                gmChild = GetSpawner(gmChild);
                if (gmChild == null)
                    continue;

                if (DebugPoints)
                {
                    Instantiate(point, gmChild.transform.TransformPoint(new Vector3(radius, 0, 0)), Quaternion.identity, gmChild.transform);
                    Instantiate(point, gmChild.transform.TransformPoint(new Vector3((Mathf.Sqrt(radius) / 2f), 0, (-Mathf.Sqrt(radius) / 2f))), Quaternion.identity, gmChild.transform);
                    Instantiate(point, gmChild.transform.TransformPoint(new Vector3(0, 0, -radius)), Quaternion.identity, gmChild.transform);
                    Instantiate(point, gmChild.transform.TransformPoint(new Vector3((-Mathf.Sqrt(radius) / 2f), 0, (-Mathf.Sqrt(radius) / 2f))), Quaternion.identity, gmChild.transform);
                    Instantiate(point, gmChild.transform.TransformPoint(new Vector3(-radius, 0, 0)), Quaternion.identity, gmChild.transform);
                    Instantiate(point, gmChild.transform.TransformPoint(new Vector3((-Mathf.Sqrt(radius) / 2f), 0, (Mathf.Sqrt(radius) / 2f))), Quaternion.identity, gmChild.transform);
                    Instantiate(point, gmChild.transform.TransformPoint(new Vector3(0, 0, radius)), Quaternion.identity, gmChild.transform);
                    Instantiate(point, gmChild.transform.TransformPoint(new Vector3((Mathf.Sqrt(radius) / 2f), 0, (Mathf.Sqrt(radius) / 2f))), Quaternion.identity, gmChild.transform);
                }
                vertices.Add(gmChild.transform.TransformPoint(new Vector3(radius, 0, 0)));
                vertices.Add(gmChild.transform.TransformPoint(new Vector3((Mathf.Sqrt(radius) / 2f), 0, (-Mathf.Sqrt(radius) / 2f))));
                vertices.Add(gmChild.transform.TransformPoint(new Vector3(0, 0, -radius)));
                vertices.Add(gmChild.transform.TransformPoint(new Vector3((-Mathf.Sqrt(radius) / 2f), 0, (-Mathf.Sqrt(radius) / 2f))));
                vertices.Add(gmChild.transform.TransformPoint(new Vector3(-radius, 0, 0)));
                vertices.Add(gmChild.transform.TransformPoint(new Vector3((-Mathf.Sqrt(radius) / 2f), 0, (Mathf.Sqrt(radius) / 2f))));
                vertices.Add(gmChild.transform.TransformPoint(new Vector3(0, 0, radius)));
                vertices.Add(gmChild.transform.TransformPoint(new Vector3((Mathf.Sqrt(radius) / 2f), 0, (Mathf.Sqrt(radius) / 2f))));
                continue;
            }
            else if (UseLastPlug && i == this.transform.childCount - 1)
            {
                gmChild = GetSpawner(gmChild);
                if (gmChild == null)
                    continue;

                if (DebugPoints)
                {
                    Instantiate(point, gmChild.transform.TransformPoint(new Vector3(radius, 0, 0)), Quaternion.identity, gmChild.transform);
                    Instantiate(point, gmChild.transform.TransformPoint(new Vector3((Mathf.Sqrt(radius) / 2f), 0, (Mathf.Sqrt(radius) / 2f))), Quaternion.identity, gmChild.transform);
                    Instantiate(point, gmChild.transform.TransformPoint(new Vector3(0, 0, radius)), Quaternion.identity, gmChild.transform);
                    Instantiate(point, gmChild.transform.TransformPoint(new Vector3((-Mathf.Sqrt(radius) / 2f), 0, (Mathf.Sqrt(radius) / 2f))), Quaternion.identity, gmChild.transform);
                    Instantiate(point, gmChild.transform.TransformPoint(new Vector3(-radius, 0, 0)), Quaternion.identity, gmChild.transform);
                    Instantiate(point, gmChild.transform.TransformPoint(new Vector3((-Mathf.Sqrt(radius) / 2f), 0, (-Mathf.Sqrt(radius) / 2f))), Quaternion.identity, gmChild.transform);
                    Instantiate(point, gmChild.transform.TransformPoint(new Vector3(0, 0, -radius)), Quaternion.identity, gmChild.transform);
                    Instantiate(point, gmChild.transform.TransformPoint(new Vector3((Mathf.Sqrt(radius) / 2f), 0, (-Mathf.Sqrt(radius) / 2f))), Quaternion.identity, gmChild.transform);
                }
                vertices.Add(gmChild.transform.TransformPoint(new Vector3(radius, 0, 0)));
                vertices.Add(gmChild.transform.TransformPoint(new Vector3((Mathf.Sqrt(radius) / 2f), 0, (Mathf.Sqrt(radius) / 2f))));
                vertices.Add(gmChild.transform.TransformPoint(new Vector3(0, 0, radius)));
                vertices.Add(gmChild.transform.TransformPoint(new Vector3((-Mathf.Sqrt(radius) / 2f), 0, (Mathf.Sqrt(radius) / 2f))));
                vertices.Add(gmChild.transform.TransformPoint(new Vector3(-radius, 0, 0)));
                vertices.Add(gmChild.transform.TransformPoint(new Vector3((-Mathf.Sqrt(radius) / 2f), 0, (-Mathf.Sqrt(radius) / 2f))));
                vertices.Add(gmChild.transform.TransformPoint(new Vector3(0, 0, -radius)));
                vertices.Add(gmChild.transform.TransformPoint(new Vector3((Mathf.Sqrt(radius) / 2f), 0, (-Mathf.Sqrt(radius) / 2f))));
                continue;
            }

            if (DebugPoints)
            {
                Instantiate(point, gmChild.transform.TransformPoint(new Vector3(radius, 0, 0)), Quaternion.identity, gmChild.transform);
                Instantiate(point, gmChild.transform.TransformPoint(new Vector3((Mathf.Sqrt(radius) / 2f), 0, (-Mathf.Sqrt(radius) / 2f))), Quaternion.identity, gmChild.transform);
                Instantiate(point, gmChild.transform.TransformPoint(new Vector3(0, 0, -radius)), Quaternion.identity, gmChild.transform);
                Instantiate(point, gmChild.transform.TransformPoint(new Vector3((-Mathf.Sqrt(radius) / 2f), 0, (-Mathf.Sqrt(radius) / 2f))), Quaternion.identity, gmChild.transform);
                Instantiate(point, gmChild.transform.TransformPoint(new Vector3(-radius, 0, 0)), Quaternion.identity, gmChild.transform);
                Instantiate(point, gmChild.transform.TransformPoint(new Vector3((-Mathf.Sqrt(radius) / 2f), 0, (Mathf.Sqrt(radius) / 2f))), Quaternion.identity, gmChild.transform);
                Instantiate(point, gmChild.transform.TransformPoint(new Vector3(0, 0, radius)), Quaternion.identity, gmChild.transform);
                Instantiate(point, gmChild.transform.TransformPoint(new Vector3((Mathf.Sqrt(radius) / 2f), 0, (Mathf.Sqrt(radius) / 2f))), Quaternion.identity, gmChild.transform);
            }

            vertices.Add(gmChild.transform.TransformPoint(new Vector3(radius, 0, 0)));
            vertices.Add(gmChild.transform.TransformPoint(new Vector3((Mathf.Sqrt(radius) / 2f), 0, (-Mathf.Sqrt(radius) / 2f))));
            vertices.Add(gmChild.transform.TransformPoint(new Vector3(0, 0, -radius)));
            vertices.Add(gmChild.transform.TransformPoint(new Vector3((-Mathf.Sqrt(radius) / 2f), 0, (-Mathf.Sqrt(radius) / 2f))));
            vertices.Add(gmChild.transform.TransformPoint(new Vector3(-radius, 0, 0)));
            vertices.Add(gmChild.transform.TransformPoint(new Vector3((-Mathf.Sqrt(radius) / 2f), 0, (Mathf.Sqrt(radius) / 2f))));
            vertices.Add(gmChild.transform.TransformPoint(new Vector3(0, 0, radius)));
            vertices.Add(gmChild.transform.TransformPoint(new Vector3((Mathf.Sqrt(radius) / 2f), 0, (Mathf.Sqrt(radius) / 2f))));
        }
        int a = 0;
        int b = 8;
        int c = 1;
        for (int i = 0; i < this.transform.childCount - 1; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (j == 7)
                {
                    triangles.Add(a);
                    triangles.Add(b);
                    triangles.Add(c);

                    triangles.Add(a);
                    triangles.Add(c);
                    triangles.Add(a - 7);
                    a++;
                    b++;
                    c++;
                    break;
                }
                triangles.Add(a);
                triangles.Add(b);
                triangles.Add(c);

                triangles.Add(a + 1);
                triangles.Add(b);
                triangles.Add(c + 8);

                a++;
                b++;
                c++;
            }
        }

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
    }

            /*Minden 8. 

                i = 0    
                j = 8
                k = 1

                i = 1   i + 1
                j = 8   j
                k = 5   k + 4

                i + 1
                j + 1
                k + 1

                -------

                i = 1
                j = 5
                k = 2

                i = 2 
                j = 5
                k = 6


                ------
                i = 2
                j = 6
                k = 3

                i = 3
                j = 6
                k = 7

                -----
                i = 3
                j = 7
                k = 4

                i = 3
                j = 4
                k = 0

                */
    //   }
    //}

    GameObject GetSpawner(GameObject parent)
    {
        for(int i = 0; i < parent.transform.childCount; i++)
        {
            GameObject child = parent.transform.GetChild(i).gameObject;
            if( child.name == "Spawner" )
            {
                return child;
            }
        }
        return null;
    }
}
