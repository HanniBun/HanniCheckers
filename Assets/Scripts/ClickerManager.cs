using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerManager : MonoBehaviour
{
    /// <summary>
    /// This script handles click input from the player. Right now it uses a raycast, 
    /// because I didn't really feel like I had enough time figuring out alternative methods that use less memory.
    /// 
    /// This script is not done: Except for the fact that it's not supposed to use
    /// raycast for click input, I am also aware that it can be written easier to read. I have added comments for the
    /// if statements that I feel are cluttered.
    /// </summary>

    #region Definitions and references

    [SerializeField]
    HexGridController myHexgridController;
    [SerializeField]
    UIController myUIController;

    PlayerController myPlayerController;

    [SerializeField]
    HexCell firstClickedCell;

    [SerializeField]
    HexCell secondClickedCell;

    public Material clickedMaterial;
    bool pickedUpCell;
    #endregion

    private void Start()
    {
        pickedUpCell = false;

        myPlayerController = FindObjectOfType<PlayerController>();
    }

    #region Click input
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.GetComponent<HexCell>() == true)
            {
                Player currentPlayer = myPlayerController.allPlayers[myPlayerController.currentPlayer];


                // If we haven't picked up anything yet, and the cell belongs to the current player
                if (pickedUpCell == false &&
                    hit.collider.gameObject.GetComponent<HexCell>().MyCellstate == currentPlayer.Color)
                {
                    firstClickedCell = hit.collider.gameObject.GetComponent<HexCell>();
                    pickedUpCell = true;
                    print("Cell picked up.");

                    myHexgridController.AllNeighborCheck(firstClickedCell.row, firstClickedCell.col, false);
                    firstClickedCell.gameObject.GetComponent<Renderer>().material = clickedMaterial;
                }

                else if (pickedUpCell == true) // If we HAVE picked up a cell...
                {
                    secondClickedCell = hit.collider.gameObject.GetComponent<HexCell>();

                    if (myHexgridController.allMyNeighbors.Contains(secondClickedCell) &&
                        secondClickedCell != firstClickedCell) // If goalcell is valid (i.e. a neighbor and not startcell)
                    {
                        pickedUpCell = false;
                        print("Cell moved.");

                        foreach (HexCell neighbors in myHexgridController.allMyNeighbors)
                        {
                            neighbors.ColorCheck();
                        }
                        myHexgridController.allMyNeighbors.Clear();

                        // Gives the cells the correct state
                        secondClickedCell.MyCellstate = firstClickedCell.MyCellstate;
                        firstClickedCell.MyCellstate = StateController.State.empty;
                        firstClickedCell.ColorCheck();
                        secondClickedCell.ColorCheck();

                        myPlayerController.UpdatePlayerCellList(secondClickedCell, firstClickedCell);

                        if (currentPlayer.playerGoalCells.Contains(secondClickedCell))
                        {
                            myPlayerController.WinCheck(currentPlayer);
                        }

                        myPlayerController.NextTurn();
                    }

                    else if (secondClickedCell == firstClickedCell)
                    {
                        pickedUpCell = false;
                        print("Clicked the same thing twice.");

                        foreach (HexCell neighbors in myHexgridController.allMyNeighbors)
                        {
                            neighbors.ColorCheck();
                        }
                        myHexgridController.allMyNeighbors.Clear();

                        firstClickedCell.ColorCheck();
                    }

                    else
                    {
                        print("Something went wrong.");
                    }
                }

                else
                {
                    print("You can't click me, fool.");
                }
            }

            else // When clicking on something else than something containing a HexCell
            {
                print("Area out of bounds");
            }
        }
    }
}
#endregion
