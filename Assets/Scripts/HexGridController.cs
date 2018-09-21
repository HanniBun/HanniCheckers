using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGridController : MonoBehaviour {
    // Note to self: Change void into something that returns a value when possible.


    [SerializeField]
    HexGrid myHexGrid;

    public Material[] cellColors = new Material[7]; // Material for the HexCells. 

    public List<HexCell> allMyNeighbors = new List<HexCell>();   // Temporary list that is supposed to be made every time a movable cell is clicked.
                                                              //  Somehow reach this list from ClickerManager. Or maybe actually have the list there instead.

    public void AllNeighborCheck(int row, int col) // Return List instead??
    {
        ENeighborCheck(row, col);
        WNeighborCheck(row, col);
        NENeighborCheck(row, col);
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

    public void NENeighborCheck(int row, int column /*bool hasJumped*/) // Maybe change Neighbor to Move?
    {
        if (row % 2 == 0)
        {
            if (myHexGrid.myGameBoard[row + 1, column + 1].myCellState == HexCell.cellState.empty /*&& !matris[row, column].validMove && !hasJumped*/)
            {
                allMyNeighbors.Add(myHexGrid.myGameBoard[row + 1, column + 1]);
            }
            /*else
            {
                if (matris[row + 2, column + 1].state == Tile.TileState.open && matris[row + 1, column + 1].state != Tile.TileState.open && !validJumpList.Contains(matris[row + 2, column + 1]))
                {
                    validJumpList.Add(matris[row + 2, column + 1]);
                    CheckForValidMoves(matris[row + 2, column + 1].GetComponent<Tile>(), true);
                }
            }*/ // use this later for jumping.
            else
            {
                print("You can't move to the northeast.");
            }
        }
        else
        {
            if (myHexGrid.myGameBoard[row + 1, column].myCellState == HexCell.cellState.empty /*&& !matris[row, column].validMove && !hasJumped*/)
            {
                allMyNeighbors.Add(myHexGrid.myGameBoard[row + 1, column]);
            }
            /*else
            {
                if (matris[row + 2, column + 1].state == Tile.TileState.open &&
                    matris[row + 1, column].state != Tile.TileState.open && !validJumpList.Contains(matris[row + 2, column + 1]))
                {
                    validJumpList.Add(matris[row + 2, column + 1]);
                    CheckForValidMoves(matris[row + 2, column + 1].GetComponent<Tile>(), true);
                }
            }*/
            else
            {
                print("You can't move to the northeast.");
            }
        }
    }
}
