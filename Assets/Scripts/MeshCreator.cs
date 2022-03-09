using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class MeshCreator: MonoBehaviour
{
    [SerializeField] private MeshFilter _meshFilter;
    [SerializeField] private MeshCollider _meshCollider;
    private Mesh _mesh;
    private Vector3[] _vertices;
    [SerializeField] private List<Transform> _verticesList;

    private int[] _triangles;

    [ExecuteInEditMode]
    // initialize a triangle mesh
    public void CreateVertex()
    {
        _mesh = new Mesh();
        _meshFilter.mesh = _mesh;

        _vertices = new Vector3[]
        {
            new Vector3(0,0,0),
            new Vector3(1.5f,1.5f,0),
            new Vector3(1,0,0),
        };

        _triangles = new int[]
        {
            0, 1, 2,
        };

        _mesh.Clear();
        _mesh.vertices = _vertices;
        _mesh.triangles = _triangles;
    }

    public void UpdateMesh()
    {
        _mesh = new Mesh();
        SynchronizeVerticesPosition();
        SynchronizeTriangles();
        if (!_mesh)
        {
            Debug.LogWarning("No mesh is detected on the MeshRoot!");
            return;
        }
        _mesh.Clear();
        _mesh.vertices = _vertices;
        _mesh.triangles = _triangles;
        _meshFilter.mesh = _mesh;
        _meshCollider.sharedMesh = _mesh;
    }

    private void SynchronizeTriangles()
    {
        List<int> triangleList = new List<int>();
        // triangles = vertices - 2
        int vertexCount = _verticesList.Count;
        int triangleCount = vertexCount - 2;
        for (int i = 0; i < triangleCount; i++)
        {
            triangleList.Add(0);
            triangleList.Add(i + 1);
            triangleList.Add(i + 2);
        }
        _triangles = triangleList.ToArray();
        //Debug.Log("triangles count: " + _triangles.Length);
        //DebugTriangles();
    }

    private void DebugTriangles()
    {
        foreach(int i in _triangles)
        {
            Debug.Log(i);
        }
    }

    private void SynchronizeVerticesPosition()
    {
        //Debug.Log("vertices count: " + _verticesList.Count);
        // add vertex position into vertices array
        List<Vector3> verticesList = new List<Vector3>();
        for (int i = 0; i < _verticesList.Count; i++)
        {
            verticesList.Add(_verticesList[i].TransformPoint(Vector3.zero) - transform.position);
        }
        _vertices = verticesList.ToArray();
        //DebugVertices();
    }

    private void DebugVertices()
    {
        foreach (Vector3 i in _vertices)
        {
            Debug.Log(i);
        }
    }

    public void AddVertex()
    {
        _verticesList.Add(GenerateNewVertex());
    }

    private Transform GenerateNewVertex()
    {
        Transform newVertex = new GameObject().transform;
        newVertex.gameObject.AddComponent<VertexPoint>();
        newVertex.GetComponent<VertexPoint>().Index = _verticesList.Count;
        newVertex.SetParent(transform);
        return newVertex;
    }

    public void ClearAllVertices()
    {
        _verticesList.Clear();
        Array.Clear(_vertices, 0, _vertices.Length);
        Array.Clear(_triangles, 0, _triangles.Length);
    }

    public void ClearMesh()
    {
        _mesh.Clear();
        List<Vector3> vertices = _vertices.ToList();
        vertices.Clear();
        _vertices = vertices.ToArray();
        List<int> triangles = _triangles.ToList();
        triangles.Clear();
        _triangles = triangles.ToArray();
        Debug.Log("_vertices count: " + _vertices.Length);
        Debug.Log("triangles count: " + _triangles.Length);
    }
}


