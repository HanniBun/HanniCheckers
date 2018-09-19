using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HexCell : MonoBehaviour
{
    [SerializeField]
    HexGrid myHexGrid;  // Used to reach the materials for the cells!
    public enum cellState { blue, green, orange, purple, red, yellow, empty, invalid };

    public cellState myCellState { get; set; }

    bool occupied;
    bool clickableCell;

    [SerializeField]
    private int _row, _col; // So that we can see the rows and col in the Inspector.
    public int row { get { return _row; } set { _row = value; } }   // Used so that each cell knows its "address",
    public int col { get { return _col; } set { _col = value; } }   //i.e. its index in the myGameboard[][].


   public MeshRenderer myMesh { get; set; } // Work in progress...

    //Meshrenderer myMesh;
    private void Start()
    {
        myHexGrid = FindObjectOfType<HexGrid>(); // Maybe not use Find? There is always only one HexGrid.
    }

    void ColorCheck(cellState myColor)
    {
        switch (myColor)
        {
            case cellState.blue:
                {
                    clickableCell = true;
                    return;
                }
            case cellState.green:
                {
                    clickableCell = true;
                    return;
                }
            case cellState.orange:
                {
                    clickableCell = true;
                    return;
                }
            case cellState.purple:
                {
                    clickableCell = true;
                    return;
                }
            case cellState.red:
                {
                    clickableCell = true;
                    return;
                }

            case cellState.yellow:
                {
                    clickableCell = true;
                    return;
                }

            case cellState.empty:
                {
                    clickableCell = true;
                    return;
                }
            case cellState.invalid:
                {
                    clickableCell = false;
                    return;
                }
            default:
                {
                    clickableCell = false;
                    return;
                }
        }

    }
}
