using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGridController : MonoBehaviour
{
    // Note to self: Change void into something that returns a value when possible.
    // Note to self 2: I really should rename this script to "MoveController" or something like that.
    // *******************************
    // I've begun to notice a pattern in how I check "neighbors". Since it feels so repetitive, it may be possible to make it into only one method. 
    // But for now, I just want to make it work and also the "chain" jumping as well. Just wanted to write that I am aware that this can be made better.

    [SerializeField]
    HexGrid myHexGrid;

    public Material[] cellColors = new Material[7]; //HexCell's colors. I don't want this array to be on every 121 cell, so, for now it's here.
    [SerializeField]
    Material cellHighlightColor;

    public List<HexCell> allMyNeighbors = new List<HexCell>();   // Temporary list that is supposed to be made every time a valid cell is clicked.

    //public bool hasJumped = false; // For jump-chaining to work correctly

    public void AllNeighborCheck(int row, int col, bool jumped) // Return List instead??
    {
        ENeighborCheck(row, col, jumped);
        WNeighborCheck(row, col, jumped);
        NENeighborCheck(row, col, jumped);
        NWNeighborCheck(row, col, jumped);
        SENeighborCheck(row, col, jumped);
        SWNeighborCheck(row, col);

        foreach (HexCell neighbors in allMyNeighbors)
        {
            neighbors.clickableCell = true;
            neighbors.gameObject.GetComponent<Renderer>().material = cellHighlightColor;
        }
    }

    void ENeighborCheck(int row, int col, bool hasJumped)
    {
        // initial check: Are we on a eastern ledge? (i.e. east is null) Having this in the beginning makes it so the code skips this completely if it's null. Neat!
        if (myHexGrid.myGameBoard[row, col + 1] != null)
        {
            // East is empty and we haven't jumped to this cell
            if (!hasJumped &&
                myHexGrid.myGameBoard[row, col + 1].myCellState == StateController.state.empty)

            {
                allMyNeighbors.Add(myHexGrid.myGameBoard[row, col + 1]); // Add neighbor to list (Stops jumping through ClickerManager on next click)
            }

            // East is not empty, and east +1 is not null and empty
            else if (myHexGrid.myGameBoard[row, col + 1].myCellState != StateController.state.empty &&
                 myHexGrid.myGameBoard[row, col + 2] != null &&
                    myHexGrid.myGameBoard[row, col + 2].myCellState == StateController.state.empty)

            {
                allMyNeighbors.Add(myHexGrid.myGameBoard[row, col + 2]);
                ENeighborCheck(myHexGrid.myGameBoard[row, col + 2].row, myHexGrid.myGameBoard[row, col + 2].col, true); // Starts jump
            }

            else
            {
                //print("Can't move to the right!");
            }
        }
        else
            print("No cells on the right");
    }

    void WNeighborCheck(int row, int col, bool hasJumped)
    {
        // Initial check: Are we on a west ledge? 
        if (myHexGrid.myGameBoard[row, col - 1] != null)
        {
            // West is empty, and we haven't done a jump over anything on the board
            if (!hasJumped &&
                myHexGrid.myGameBoard[row, col - 1].myCellState == StateController.state.empty)

            {
                allMyNeighbors.Add(myHexGrid.myGameBoard[row, col - 1]);
            }

            // West +1 isn't null, is empty, doesn't exist in the neighbor list, and West isn't empty (Enables jumping to the west)
            else if (myHexGrid.myGameBoard[row, col - 2] != null &&
                myHexGrid.myGameBoard[row, col - 1].myCellState != StateController.state.empty &&
                    myHexGrid.myGameBoard[row, col - 2].myCellState == StateController.state.empty &&
                    !allMyNeighbors.Contains(myHexGrid.myGameBoard[row, col - 2])) // If we don't do this check, things spiral out a bit of hand, and we get an infinite loop. 

            {
                allMyNeighbors.Add(myHexGrid.myGameBoard[row, col - 2]);
                WNeighborCheck(myHexGrid.myGameBoard[row, col - 2].row, myHexGrid.myGameBoard[row, col - 2].col, true); //Starts jump
            }

            else
            {
                print("Can't move to the left");
            }
        }
    }

    public void NENeighborCheck(int row, int column, bool hasJumped)
    {
        if (row % 2 == 0)
        {
            if (myHexGrid.myGameBoard[row + 1, column + 1] != null) // NE for even rows is not null
            {
                // If NE is empty, and we haven't jumped to this cell
                if (myHexGrid.myGameBoard[row + 1, column + 1].myCellState == StateController.state.empty &&
                    !hasJumped)
                {
                    allMyNeighbors.Add(myHexGrid.myGameBoard[row + 1, column + 1]);
                }

                // If NE is NOT empty, NE +1 is not null and is empty, and NE +1 doesn't exist in the neighbor list
                else if (myHexGrid.myGameBoard[row + 1, column + 1].myCellState == StateController.state.empty &&
                   myHexGrid.myGameBoard[row + 2, column + 1] != null &&
                   myHexGrid.myGameBoard[row + 2, column + 1].myCellState == StateController.state.empty &&
                   !allMyNeighbors.Contains(myHexGrid.myGameBoard[row + 2, column + 1]))

                {
                    allMyNeighbors.Add(myHexGrid.myGameBoard[row + 2, column + 1]);
                    NENeighborCheck(myHexGrid.myGameBoard[row + 2, column + 1].row, myHexGrid.myGameBoard[row + 2, column + 1].col, true);
                }
            }

            else
                print("Can't move to the NE");

        }
        else // Uneven rows
        {
            if (myHexGrid.myGameBoard[row + 1, column] != null)
            {
                // If NE is empty and we haven't jumped
                if (myHexGrid.myGameBoard[row + 1, column].myCellState == StateController.state.empty &&
                    !hasJumped)
                {
                    allMyNeighbors.Add(myHexGrid.myGameBoard[row + 1, column]);
                }

                // If NE is NOT empty, NE +1 is not null and is empty, and NE +1 doesn't exist in the neighbor list
                else if (myHexGrid.myGameBoard[row + 1, column].myCellState != StateController.state.empty &&
                    myHexGrid.myGameBoard[row + 2, column + 1] != null &&
                    myHexGrid.myGameBoard[row + 2, column + 1].myCellState == StateController.state.empty &&
                    !allMyNeighbors.Contains(myHexGrid.myGameBoard[row + 2, column + 1]))

                {
                    allMyNeighbors.Add(myHexGrid.myGameBoard[row + 2, column + 1]);
                    NENeighborCheck(myHexGrid.myGameBoard[row + 2, column + 1].row, myHexGrid.myGameBoard[row + 2, column + 1].col, true);
                }
            }
            else
                print("Can't move to the NE");
        }
    }

    public void NWNeighborCheck(int row, int column, bool hasJumped)
    {
        if (row % 2 == 0) // Even rows
        {
            if (myHexGrid.myGameBoard[row + 1, column] != null)
            {
                if (myHexGrid.myGameBoard[row + 1, column].myCellState == StateController.state.empty &&
                    !hasJumped)
                {
                    allMyNeighbors.Add(myHexGrid.myGameBoard[row + 1, column]); // Add as neighbor.
                }

                else if (myHexGrid.myGameBoard[row + 1, column].myCellState != StateController.state.empty &&
                    myHexGrid.myGameBoard[row + 2, column - 1] != null &&
                    myHexGrid.myGameBoard[row + 2, column - 1].myCellState == StateController.state.empty &&
                    !allMyNeighbors.Contains(myHexGrid.myGameBoard[row + 2, column + 1]))

                {
                    allMyNeighbors.Add(myHexGrid.myGameBoard[row + 2, column + 1]);
                    NWNeighborCheck(myHexGrid.myGameBoard[row + 2, column + 1].row, myHexGrid.myGameBoard[row + 2, column + 1].col, true);
                }

            }
            else
                print("You can't move to the NW.");
        }
        else // uneven rows
        {
            if (myHexGrid.myGameBoard[row + 1, column - 1] != null)
            {
                if (myHexGrid.myGameBoard[row + 1, column - 1].myCellState == StateController.state.empty &&
                    !hasJumped)
                {
                    allMyNeighbors.Add(myHexGrid.myGameBoard[row + 1, column - 1]);
                }

                else if (myHexGrid.myGameBoard[row + 1, column - 1].myCellState != StateController.state.empty &&
                    myHexGrid.myGameBoard[row + 2, column - 1] != null &&
                    myHexGrid.myGameBoard[row + 2, column - 1].myCellState == StateController.state.empty &&
                    !allMyNeighbors.Contains(myHexGrid.myGameBoard[row + 2, column - 1]))

                {
                    allMyNeighbors.Add(myHexGrid.myGameBoard[row + 2, column - 1]);
                    NWNeighborCheck(myHexGrid.myGameBoard[row + 2, column - 1].row, myHexGrid.myGameBoard[row + 2, column - 1].col, true);
                }
            }
        }
    }

    public void SENeighborCheck(int row, int column, bool hasJumped)
    {
        if (row % 2 == 0) //even rows
        {
            if (myHexGrid.myGameBoard[row - 1, column + 1] != null)
            {
                if (myHexGrid.myGameBoard[row - 1, column + 1].myCellState == StateController.state.empty &&
                    !hasJumped)
                {
                    allMyNeighbors.Add(myHexGrid.myGameBoard[row - 1, column + 1]);
                }

                else if (myHexGrid.myGameBoard[row - 1, column + 1].myCellState != StateController.state.empty &&
                    myHexGrid.myGameBoard[row - 2, column + 1].myCellState == StateController.state.empty)
                    print("You can't move to the southeast.");

            }
        }
        else //Uneven rows
        {
            if (myHexGrid.myGameBoard[row - 1, column] != null &&
                myHexGrid.myGameBoard[row - 1, column].myCellState == StateController.state.empty)
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
            if (myHexGrid.myGameBoard[row - 1, column] != null &&
                myHexGrid.myGameBoard[row - 1, column].myCellState == StateController.state.empty)
            {
                allMyNeighbors.Add(myHexGrid.myGameBoard[row - 1, column]);
            }
            else
            {
                //print("You can't go to the southwest.");
                //if (matris[row - 2, column - 1].state == Tile.TileState.open &&
                //    matris[row - 1, column].state != Tile.TileState.open && !validJumpList.Contains(matris[row - 2, column - 1]))
                //{
                //    validJumpList.Add(matris[row - 2, column - 1]);
                //    CheckForValidMoves(matris[row - 2, column - 1].GetComponent<Tile>(), true);
                //}
            }
        }
        else // uneven rows
        {
            if (myHexGrid.myGameBoard[row - 1, column - 1] != null &&
                myHexGrid.myGameBoard[row - 1, column - 1].myCellState == StateController.state.empty)
            {
                allMyNeighbors.Add(myHexGrid.myGameBoard[row - 1, column - 1]);
            }
            else
            {
                //print("You can't go to the southwest.");
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


