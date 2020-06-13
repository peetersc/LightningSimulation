using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTerrain : MonoBehaviour
{
    int heightScale = 3;
    float detailScale = 12.0f;
    List<GameObject> myTrees = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        for (int v = 0; v < vertices.Length; ++v)
        {
            vertices[v].y = Mathf.PerlinNoise((vertices[v].x + this.transform.position.x)/detailScale, 
                                              (vertices[v].z +this.transform.position.z)/detailScale)*heightScale;

            if (vertices[v].y > 2 && Mathf.PerlinNoise((vertices[v].x + 5)/10, (vertices[v].z+5)/10)*10 > 4.6)
            {
                GameObject newTree = TreePool.getTree();
                if(newTree != null)
                {
                    Vector3 treePos = new Vector3(vertices[v].x + this.transform.position.x + Random.Range(20,50),
                                                  vertices[v].y - 2,
                                                  vertices[v].z + this.transform.position.z + Random.Range(20, 50));

                    newTree.transform.position = treePos;
                    newTree.SetActive(true);
                    myTrees.Add(newTree);
                }
            }
        }

        mesh.vertices = vertices;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        this.gameObject.AddComponent<MeshCollider>();
        
    }

    private void OnDestroy()
    {
        for (int i = 0; i < myTrees.Count; i++)
        {
            if (myTrees[i] != null)
                myTrees[i].SetActive(false);
        }
        myTrees.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
