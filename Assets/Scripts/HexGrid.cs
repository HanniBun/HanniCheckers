using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexGrid : MonoBehaviour
{
    [SerializeField] GameObject cellPrefab;
    GameObject tempCell;

    const int rows = 17, columns = 13;

    HexCell [,] myGameBoard = new HexCell[rows, columns];
    public Material[] cellColors = new Material[6]; // Material for our HexCells. Maybe move this to some sort of HexGrid Controller script later?

    void Start()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (i % 2 == 0)
                {
                    tempCell = Instantiate(cellPrefab, new Vector3(0.865f + j * 1.73f, 0, i * 1f), transform.rotation);
                }
                else
                {
                    tempCell = Instantiate(cellPrefab, new Vector3(j * 1.73f, 0, i * 1f), transform.rotation);
                }
                tempCell.GetComponent<HexCell>().row = i;
                tempCell.GetComponent<HexCell>().col = j;
                myGameBoard[i, j] = tempCell.GetComponent<HexCell>();

                tempCell.GetComponent<HexCell>().myCellState = HexCell.cellState.blue;
            }
        }
    }
}
