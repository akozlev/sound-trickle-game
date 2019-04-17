using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]

public class TestPolygon : MonoBehaviour
{
    MeshFilter meshFilter;
    MeshRenderer meshRenderer;
    public Material material;
    public Transform axis;
    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
    }
    void Start()
    {
        // Vector2[] vertices2D = new Vector2[]
        // {
        //    new Vector2(0,0),
        //    new Vector2(0,1),
        //    new Vector2(1,1),
        //    new Vector2(1,2),
        //    new Vector2(0,2),
        //    new Vector2(0,3),
        //    new Vector2(3,3),
        //    new Vector2(3,2),
        //    new Vector2(2,2),
        //    new Vector2(2,1),
        //    new Vector2(3,1),
        //    new Vector2(3,0)
        //};
        Vector2[] vertices2D = new Vector2[]
        {
            new Vector2(0,0),
            new Vector2(1,0),
            new Vector2(0.5f, 0.86602540378f)
        };
        Vector3[] vertices3D = System.Array.ConvertAll<Vector2, Vector3>(vertices2D, v => v);

        Triangulator tr = new Triangulator(vertices2D);
        int[] indices = tr.Triangulate();

        Color[] colors = Enumerable.Range(0, vertices3D.Length).Select(i => Random.ColorHSV()).ToArray();

        Mesh msh = new Mesh
        {
            name = "This Mesh",
            vertices = vertices3D,
            triangles = indices,
            colors = colors
        };
        msh.RecalculateNormals();
        msh.RecalculateBounds();

        meshRenderer.material = material;


        meshFilter.mesh = msh;
        GetComponent<PolygonCollider2D>().SetPath(0, vertices2D);
        
    }
   

}
