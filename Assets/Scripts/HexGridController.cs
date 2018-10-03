using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Dir { Northeast, East, Southeast, Southwest, West, Northwest }

public class HexGridController : MonoBehaviour
{
    /// <summary>
    /// Used when checking for valid moves, as well as storing said moves, for a clicked cell. 
    /// </summary>

    [SerializeField]
    HexGrid myHexGrid;

    public Material[] cellColors = new Material[7];
    [SerializeField]
    Material cellHighlightColor;

    public List<HexCell> allMyNeighbors = new List<HexCell>();


    public void AllNeighborCheck(int row, int col, bool jumped)
    {
        for (int i = 0; i <= (int)Dir.Northwest; i++)
        {
            DirectionCheck(row, col, jumped, (Dir)i);
        }

        foreach (HexCell neighbors in allMyNeighbors)
        {
            neighbors.gameObject.GetComponent<Renderer>().material = cellHighlightColor;
        }
    }

    #region Direction Switch
    public void DirectionCheck(int row, int column, bool hasJumped, Dir direction)
    {
        int x = 0;
        int y = 0;

        switch (direction)
        {
            case Dir.East:
                x = row + 1;
                y = column;
                break;

            case Dir.West:
                x = row - 1;
                y = column;
                break;

            case Dir.Northeast:
                if (column % 2 == 0)
                {
                    x = row + 1;
                    y = column + 1;
                }
                else
                {
                    x = row;
                    y = column + 1;
                }
                break;

            case Dir.Northwest:
                if (column % 2 == 0)
                {
                    x = row;
                    y = column + 1;
                }
                else
                {
                    x = row - 1;
                    y = column + 1;
                }
                break;

            case Dir.Southeast:
                if (column % 2 == 0)
                {
                    x = row + 1;
                    y = column - 1;
                }
                else
                {
                    x = row;
                    y = column - 1;
                }
                break;

            case Dir.Southwest:
                if (column % 2 == 0)
                {
                    x = row;
                    y = column - 1;
                }
                else
                {
                    x = row - 1;
                    y = column - 1;
                }
                break;
        }
        #endregion

        if ((y < 0 || y >= 17) || (x < 0 || x >= 13)) // Check if rows or columns are out of index
        {
            return;
        }

        HexCell originalCell = myHexGrid.myGameBoard[column, row];
        HexCell destinationCell = myHexGrid.myGameBoard[y, x];

        if (originalCell == null || destinationCell == null) // If the original cell is null, quit checking for valid moves.
        {
            return;
        }

        #region Main check for valid move from a cell

        if (destinationCell.MyCellstate == StateController.State.empty) // If destination cell is empty
        {
            if (!hasJumped)
            {
                if (!allMyNeighbors.Contains(destinationCell))
                {
                    allMyNeighbors.Add(destinationCell);
                }
            }

            else // If we have jumped to the cell we're on now
            {
                // If original node is NOT empty OR original node is NOT null
                if (originalCell.MyCellstate != StateController.State.empty && originalCell.MyCellstate != StateController.State.invalid)
                {
                    if (!allMyNeighbors.Contains(destinationCell))
                    {
                        allMyNeighbors.Add(destinationCell);

                        for (int i = 0; i <= (int)Dir.Northwest; i++)
                        {
                            DirectionCheck(x, y, true, (Dir)i);
                        }
                    }
                }

            }
        }

        else // Destination cell is not empty
        {
            if (originalCell.MyCellstate != StateController.State.empty && hasJumped)
            {
                return;
            }

            DirectionCheck(x, y, true, direction);
        }

        #endregion
    }
}


