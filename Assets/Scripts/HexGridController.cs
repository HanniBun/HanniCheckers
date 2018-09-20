using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGridController : MonoBehaviour {

    [SerializeField]
    HexGrid myHexGrid;

    public Material[] cellColors = new Material[7]; // Material for the HexCells. 

        List<HexCell> allMyNeighbors = new List<HexCell>();   // Temporary list that is supposed to be made every time a movable cell is clicked.
                                                              //  Somehow reach this list from ClickerManager. Or maybe actually have the list there instead.

    public void AllNeighborCheck(int row, int col) 
    {
        ENeighborCheck(row, col);
        WNeighborCheck(row, col);
        // Gonna add the rest of the "neighbors" here later. Wanna make sure that the ClickerManager script works OK.

        foreach (HexCell neighbors in allMyNeighbors)
        {
            neighbors.clickableCell = true; // Neighbors are clickable.
        } 
    }

    void ENeighborCheck(int row, int col)
    {
        if (myHexGrid.myGameBoard[row, col + 1].myCellState == HexCell.cellState.empty)
        {
            print("There's an empty spot to our right");
            allMyNeighbors.Add(myHexGrid.myGameBoard[row, col + 1]); // added to list!
        }

        if (myHexGrid.myGameBoard[row, col + 1].clickableCell == true)
        {
            print("Hey, there's someone to the right.");
        }
        else
        {
            print("Nothing to the right!");
        }
    }

       void WNeighborCheck(int row, int col)
        {
            if (myHexGrid.myGameBoard[row, col - 1].myCellState == HexCell.cellState.empty)
            {
                print("There's an empty spot to our left!");
            allMyNeighbors.Add(myHexGrid.myGameBoard[row, col - 1]); // added to list!
        }
            if (myHexGrid.myGameBoard[row, col - 1].myCellState != HexCell.cellState.empty || myHexGrid.myGameBoard[row, col - 1].clickableCell == true)
            {
                print("Hey, there's someone to the left.");
            }
            else
            {
                print("Nothing to the right!");
            }
        }
    }
