using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexGrid : MonoBehaviour {

    public int width = 13;  
    public int height = 17;  

    public HexCell cellPrefab;  // Our base shape we use for the grid.
    HexMesh hexMesh;
    Canvas gridCanvas;

    bool invalidBuildCell;

    HexCell[] cells;  // Array of the shapes.

    public Text cellLabelPrefab;

    void Awake()  
    {
        gridCanvas = GetComponentInChildren<Canvas>();
        hexMesh = GetComponentInChildren<HexMesh>();

        cells = new HexCell[height * width]; // determines the size. 

        for (int z = 0, i = 0; z < height; z++)
        {
            for (int x = 0; x < width; x++)
            {
                CreateCell(x, z, i++);
            }
        }
    }

    void Start()  // Remember: This happens AFTER Awake. So, before this happens, the script knows the size of the board.
    {
        //hexMesh.Triangulate(cells);
    }

    void CreateCell(int x, int z, int i)  //CreateCell takes in the xyz-coordinates we give it.
    {
        Vector3 position;
        position.x = (x + z * 0.5f - z / 2) * (HexagonSizeScript.innerRadius * 2f);  // Offset, because hexagons.
        position.y = 0f;
        position.z = z * (HexagonSizeScript.outerRadius * 1.5f);
        //if (!((x <= 6 || x >= 8) && z == 0)) Old check.
            BuildCheckIfValid(x, z, cells[i]); // check to see if it's valid or not. Made by ME!
        if (invalidBuildCell == false)
        {
            HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);  // Actually creates the shape.
            cell.transform.SetParent(transform, false);  // SetParent so that the hierarchy doesn't flood with hexagons. Haha!
            cell.transform.localPosition = position;

            Text label = Instantiate<Text>(cellLabelPrefab);  // Together with the cell, create a cell label to show the coordinates.
            label.rectTransform.SetParent(gridCanvas.transform, false); // Accesses the grid canvas and makes it the parent of the labels. The hiearchy doesn't become cluttered.
            label.rectTransform.anchoredPosition =
                new Vector2(position.x, position.z);
            label.text = x.ToString() + "\n" + z.ToString();
        }
    }

    void BuildCheckIfValid(int x, int z, HexCell cellToBuild)
    {
        if (z == 0 && x <= 6 || x >= 8 || z == 1 && x <= 5 && x >= 8 || z == 2 && x <= 5 || x >= 8) // Wow, this looks messy. And it's just the first 3 rows.      
            {
            invalidBuildCell = true;
        }
    }

	}

