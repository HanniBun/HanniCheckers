using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexGrid : MonoBehaviour {

    public int width = 6;  
    public int height = 6;  // how large we want the grid to be.

    public HexCell cellPrefab;  // Our base shape we use for the grid.

    HexCell[] cells;  // Array of the shapes.

    public Text cellLabelPrefab;

    Canvas gridCanvas;

    void Awake()  // Creates the grid.
    {
        gridCanvas = GetComponentInChildren<Canvas>();

        cells = new HexCell[height * width]; // determines the size. 

        for (int z = 0, i = 0; z < height; z++)
        {
            for (int x = 0; x < width; x++)
            {
                CreateCell(x, z, i++);
            }
        }
    }

    void CreateCell(int x, int z, int i)  //CreateCell takes in the xyz-coordinates we give it.
    {
        Vector3 position;
        position.x = (x + z * 0.5f - z / 2) * (HexagonSizeScript.innerRadius * 2f);  // Offset, because hexagons are like that.
        position.y = 0f;
        position.z = z * (HexagonSizeScript.outerRadius * 1.5f);
        if (!(x == 3 && z == 16))
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

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
