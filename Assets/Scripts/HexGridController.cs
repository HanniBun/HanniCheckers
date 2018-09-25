using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGridController : MonoBehaviour {
    // Note to self: Change void into something that returns a value when possible.

    // *******************************
    // Neighborchecks methods are taken directly from a classmate's code but changed since I don't use "jumping" over occupied cells yet.
    // I really should rename this script to "NeighborController" or something like that.


    [SerializeField]
    HexGrid myHexGrid;

    public Material[] cellColors = new Material[7]; // Material for the HexCells. 
    [SerializeField]
    Material cellHighlightColor;

    public List<HexCell> allMyNeighbors = new List<HexCell>();   // Temporary list that is supposed to be made every time a movable cell is clicked.
                                                                 //  Somehow reach this list from ClickerManager. Or maybe actually have the list there instead.

    public void AllNeighborCheck(int row, int col) // Return List instead??
    {
        ENeighborCheck(row, col);
        WNeighborCheck(row, col);
        NENeighborCheck(row, col);
        NWNeighborCheck(row, col);
        SENeighborCheck(row, col);
        SWNeighborCheck(row, col);

        foreach (HexCell neighbors in allMyNeighbors)
        {
            neighbors.clickableCell = true; // Neighbors are clickable.
            //neighbors.gameObject.GetComponent<Renderer>().material = cellHighlightColor;
        }
    }

    void ENeighborCheck(int row, int col)
    {
        if (myHexGrid.myGameBoard[row, col + 1].myCellState == HexGrid.state.empty)
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
        if (myHexGrid.myGameBoard[row, col - 1].myCellState == HexGrid.state.empty)
        {
            print("There's an empty spot to our left!");
            allMyNeighbors.Add(myHexGrid.myGameBoard[row, col - 1]); // added to list!
        }
        if (myHexGrid.myGameBoard[row, col - 1].myCellState != HexGrid.state.empty || myHexGrid.myGameBoard[row, col - 1].clickableCell == true)
        {
            print("Hey, there's someone to the left.");
        }
        else
        {
            print("Nothing to the right!");
        }
    }

    public void NENeighborCheck(int row, int column /*bool hasJumped*/)
    {
        if (row % 2 == 0)
        {
            if (myHexGrid.myGameBoard[row + 1, column + 1].myCellState == HexGrid.state.empty /*&& !matris[row, column].validMove && !hasJumped*/)
            {
                allMyNeighbors.Add(myHexGrid.myGameBoard[row + 1, column + 1]);
            }

            else
            {
                print("You can't move to the northeast.");
            }
        }
        else
        {
            if (myHexGrid.myGameBoard[row + 1, column].myCellState == HexGrid.state.empty /*&& !matris[row, column].validMove && !hasJumped*/)
            {
                allMyNeighbors.Add(myHexGrid.myGameBoard[row + 1, column]);
            }

            else
            {
                print("You can't move to the northeast.");
            }
        }
    }

    public void NWNeighborCheck(int row, int column)
    {
        if (row % 2 == 0) // Even rows
        {
            if (myHexGrid.myGameBoard[row + 1, column].myCellState == HexGrid.state.empty) // If the row over us is empty...
            {
                allMyNeighbors.Add(myHexGrid.myGameBoard[row + 1, column]); // Add as neighbor.
            }
            else
            {
                print("You can't move to the northwest.");

                // Enable jumping!
                //if (myHexGrid.myGameBoard[row + 2, column - 1].myCellState == HexCell.cellState.empty &&
                //    myHexGrid.myGameBoard[row + 1, column].myCellState != HexCell.cellState.empty /*&& !validJumpList.Contains(matris[row + 2, column - 1])*/) // 
                //{
                //    allMyNeighbors.Add(myHexGrid.myGameBoard[row + 2, column - 1]);
                //}
            }
        }
        else // uneven rows
        {
            if (myHexGrid.myGameBoard[row + 1, column - 1].myCellState == HexGrid.state.empty)
            {
                allMyNeighbors.Add(myHexGrid.myGameBoard[row + 1, column - 1]);
            }
            else
            {
                print("You can't go to the northwest.");
                //if (matris[row + 2, column - 1].state == Tile.TileState.open &&
                //    matris[row + 1, column - 1].state != Tile.TileState.open && !validJumpList.Contains(matris[row + 2, column - 1]))
                //{
                //    validJumpList.Add(matris[row + 2, column - 1]);
                //    CheckForValidMoves(matris[row + 2, column - 1].GetComponent<Tile>(), true);
                //}
            }
        }
    }

    public void SENeighborCheck(int row, int column)
    {
        if (row % 2 == 0) //even rows
        {
            if (myHexGrid.myGameBoard[row - 1, column + 1].myCellState == HexGrid.state.empty)
            {
                allMyNeighbors.Add(myHexGrid.myGameBoard[row - 1, column + 1]);
            }
            else
                print("You can't move to the southeast.");
            //{
            //    if (matris[row - 2, column + 1].state == Tile.TileState.open &&
            //        matris[row - 1, column + 1].state != Tile.TileState.open && !validJumpList.Contains(matris[row - 2, column + 1]))
            //    {
            //        validJumpList.Add(matris[row - 2, column + 1]);
            //        CheckForValidMoves(matris[row - 2, column + 1].GetComponent<Tile>(), true);
            //    }
        }
        else
        {
            if (myHexGrid.myGameBoard[row - 1, column].myCellState == HexGrid.state.empty)
                allMyNeighbors.Add(myHexGrid.myGameBoard[row - 1, column]);

            else
                print("You can't go to the southeast.");
            //if (matris[row - 2, column + 1].state == Tile.TileState.open &&
            //      matris[row - 1, column].state != Tile.TileState.open && !validJumpList.Contains(matris[row - 2, column + 1]))
            //{
            //    validJumpList.Add(matris[row - 2, column + 1]);
            //    CheckForValidMoves(matris[row - 2, column + 1].GetComponent<Tile>(), true);
            //}
        }
    }

    public void SWNeighborCheck(int row, int column)
    {
        if (row % 2 == 0)
        {
            if (myHexGrid.myGameBoard[row - 1, column].myCellState == HexGrid.state.empty)
            {
                allMyNeighbors.Add(myHexGrid.myGameBoard[row - 1, column]);
            }
            else
            {
                print("You can't go to the southwest.");
                //if (matris[row - 2, column - 1].state == Tile.TileState.open &&
                //    matris[row - 1, column].state != Tile.TileState.open && !validJumpList.Contains(matris[row - 2, column - 1]))
                //{
                //    validJumpList.Add(matris[row - 2, column - 1]);
                //    CheckForValidMoves(matris[row - 2, column - 1].GetComponent<Tile>(), true);
                //}
            }
        }
        else
        {
            if (myHexGrid.myGameBoard[row - 1, column - 1].myCellState == HexGrid.state.empty)
            {
                allMyNeighbors.Add(myHexGrid.myGameBoard[row - 1, column - 1]);
            }
            else
            {
                print("You can't go to the southwest.");
                //if (matris[row - 2, column - 1].state == Tile.TileState.open &&
                //    matris[row - 1, column - 1].state != Tile.TileState.open && !validJumpList.Contains(matris[row - 2, column - 1]))
                //{
                //    validJumpList.Add(matris[row - 2, column - 1]);
                //    CheckForValidMoves(matris[row - 2, column - 1].GetComponent<Tile>(), true);
                //}
            }
        }
    }
}


