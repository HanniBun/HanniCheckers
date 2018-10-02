using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Dir { Northeast, East, Southeast, Southwest, West, Northwest }

public class HexGridController : MonoBehaviour
{
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
            neighbors.clickableCell = true;
            neighbors.gameObject.GetComponent<Renderer>().material = cellHighlightColor;
        }
    }

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

        if ((y < 0 || y >= 17) || (x < 0 || x >= 13)) // Check if rows or columns are out of index
        {
            return;
        }


        HexCell originalNode = myHexGrid.myGameBoard[column, row];
        HexCell destinationNode = myHexGrid.myGameBoard[y, x];
        Debug.Log(string.Format("Moving from ({0}) to ({1}) in {2}", originalNode, destinationNode, direction));


        if (originalNode == null || destinationNode == null) // If the original node is null, abort mission. 
        {
            return;
        }

        if (destinationNode.myCellState == StateController.State.empty) // Destination is empty
        {
            if (!hasJumped) // Not jumped
            {
                if (!allMyNeighbors.Contains(destinationNode))
                {
                    allMyNeighbors.Add(destinationNode);
                }
            }

            else // If we have jumped to the cell we're on now
            {
                
                // If original node is NOT empty OR original node is NOT null
                if (originalNode.myCellState != StateController.State.empty && originalNode.myCellState != StateController.State.invalid)
                {
                    // If destination isn't in the list of neighbors
                    if (!allMyNeighbors.Contains(destinationNode))
                    {
                        allMyNeighbors.Add(destinationNode);

                        for (int i = 0; i <= (int)Dir.Northwest; i++)
                        {
                            DirectionCheck(x, y, true, (Dir)i);   // Directioncheck from DestinationNode's x and y, set jumping to true
                        }
                    }
                }

            }
        }

        else // Destination is not empty
        {
            if (originalNode.myCellState != StateController.State.empty && hasJumped)
            {
                return;
            }

            DirectionCheck(x, y, true, direction);
        }
    }
}


