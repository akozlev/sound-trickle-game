using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public abstract class Shape : MonoBehaviour
{
    Vector2[] vertices;
    new Collider2D collider;
    Mesh mesh;
    MeshRenderer meshRenderer;
    MeshFilter meshFilter;
}
