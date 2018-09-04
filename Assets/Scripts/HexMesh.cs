﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]  
public class HexMesh : MonoBehaviour
{ // Creates the actual hexagonal texture on the hex cell.
    Mesh hexMesh;
    List<Vector3> vertices;
    List<int> triangles;


    void Awake()
    {
        GetComponent<MeshFilter>().mesh = hexMesh = new Mesh();

        hexMesh.name = "Hex Mesh";
        vertices = new List<Vector3>();
        triangles = new List<int>();
    }

    public void Triangulate(HexCell[] cells) // Calls the entire Cells[] array in the HexCell script. Dvs hela spelplanen, med varje position inuti arrayen.
    {
        hexMesh.Clear();
        vertices.Clear();
        triangles.Clear();  // Clears the things in its lists.
        for (int i = 0; i < cells.Length; i++)
        {
            Triangulate(cells[i]); 
        }
        hexMesh.vertices = vertices.ToArray();
        hexMesh.triangles = triangles.ToArray();
        hexMesh.RecalculateNormals();
    }


    void Triangulate(HexCell cell)  // second triangulate
    {
        Vector3 center = cell.transform.localPosition;
        AddTriangle(
            center,
            center + HexagonSizeScript.corners[0],
            center + HexagonSizeScript.corners[1]
        );
    }

    void AddTriangle(Vector3 v1, Vector3 v2, Vector3 v3)
    {
        int vertexIndex = vertices.Count;
        vertices.Add(v1);
        vertices.Add(v2);
        vertices.Add(v3);
        triangles.Add(vertexIndex);
        triangles.Add(vertexIndex + 1);
        triangles.Add(vertexIndex + 2);
    }



}