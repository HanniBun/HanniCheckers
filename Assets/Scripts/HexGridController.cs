using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGridController : MonoBehaviour {

    [SerializeField]
    HexGrid myHexGrid;

    public Material[] cellColors = new Material[6]; // Material for the HexCells. 

        List<HexCell> allMyNeighbors = new List<HexCell>();

    public void AllNeighborCheck(int row, int col) 
    {
        ENeighborCheck(row, col);
        WNeighborCheck(row, col);

        foreach (HexCell neighbors in allMyNeighbors)
        {
            neighbors.clickableCell = true; // Can click on neighbors!
        }
  
    }

    HexCell ENeighborCheck(int Erow, int Ecol)
    {
        if (myHexGrid.myGameBoard[Erow, Ecol + 1].myCellState == HexCell.cellState.empty)
        {
            print("There's an empty spot to our right");
            allMyNeighbors.Add(myHexGrid.myGameBoard[Erow, Ecol + 1]); // added to list!
        }

        if (myHexGrid.myGameBoard[Erow, Ecol + 1].clickableCell == true)
        {
            print("Hey, there's someone to the right.");
            return null; // invalid position?
        }
        else
        {
            print("There ain't shit to the right!");
            return null;

            // returns Coordinates E to AllNeighborCheck?
        }
    }

        HexCell WNeighborCheck(int Wrow, int Wcol)
        {
            if (myHexGrid.myGameBoard[Wrow, Wcol - 1].myCellState == HexCell.cellState.empty)
            {
                print("There's an empty spot to our left!");
                return myHexGrid.myGameBoard[Wrow, Wcol - 1];
            }
            if (myHexGrid.myGameBoard[Wrow, Wcol - 1].myCellState != HexCell.cellState.empty || myHexGrid.myGameBoard[Wrow, Wcol - 1].clickableCell == true)
            {
                print("Hey, there's someone to the left.");
                return null;
            }
            else
            {
                print("There ain't shit to the left!");
                return null;
            }
        }
    }
