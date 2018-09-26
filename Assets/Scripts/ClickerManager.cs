using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerManager : MonoBehaviour
{
    // This script handles click input from the player. Right now it uses a raycast, because I don't really feel like I have much time figuring out alternative methods that use less memory.
    [SerializeField]
    HexGridController myHexgridController;
    bool pickedUpCell;

    [SerializeField]
    HexCell startClickedCell;
    [SerializeField]
    HexCell goalClickedCell;

    public Material clickedMaterial;

    // Note to self: Maybe have a temporary list of myClickCell's neighbors here, for easy access? Or maybe keep it in the HexGridController?


    //static int layer = 8;
    //int layerMask = 1 << layer; 
    // Had an idea on using layermasks with the raycast instead of GetComponent before. Keeping this variable if I need it in the future for some reason.

    private void Start()
    {
        pickedUpCell = false;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.GetComponent<HexCell>() == true) // If we click on a cell...
            {
                if (pickedUpCell == false && 
                    hit.collider.gameObject.GetComponent<HexCell>().myCellState != StateController.state.invalid && 
                    hit.collider.gameObject.GetComponent<HexCell>().myCellState != StateController.state.empty) // if we haven't picked up a cell and the clicked one contains something...
                {
                    startClickedCell = hit.collider.gameObject.GetComponent<HexCell>();  // ... set clicked cell to Start clicked cell.
                    pickedUpCell = true; // Pick it up!
                    print("Cell picked up.");

                    myHexgridController.AllNeighborCheck(startClickedCell.row, startClickedCell.col, false); // Check for neighbors
                    startClickedCell.gameObject.GetComponent<Renderer>().material = clickedMaterial;
                }

                else if (pickedUpCell == true) // If we HAVE picked up a cell...
                {
                    goalClickedCell = hit.collider.gameObject.GetComponent<HexCell>();

                    if (myHexgridController.allMyNeighbors.Contains(goalClickedCell) &&
                        goalClickedCell != startClickedCell) // If goalcell is valid (i.e. a neighbor and not startcell)
                    {
                        pickedUpCell = false;
                        //myHexgridController.hasJumped = false;
                        print("Cell moved.");

                        foreach (HexCell neighbors in myHexgridController.allMyNeighbors)
                        {
                            neighbors.ColorCheck(); // To return original color? 
                        }
                        myHexgridController.allMyNeighbors.Clear(); // Empties the list when you place new cell down.

                        goalClickedCell.myCellState = startClickedCell.myCellState;
                        startClickedCell.myCellState = StateController.state.empty;
                        startClickedCell.ColorCheck();
                        goalClickedCell.ColorCheck();     // Can't this if-loop be made any smoother?

                    }

                    else if (goalClickedCell == startClickedCell)
                    {
                        pickedUpCell = false;
                        //myHexgridController.hasJumped = false;

                        print("Clicked the same thing twice.");

                        foreach (HexCell neighbors in myHexgridController.allMyNeighbors)
                        {
                            neighbors.ColorCheck(); // To return original color? 
                        }
                        myHexgridController.allMyNeighbors.Clear();


                        startClickedCell.ColorCheck(); // Returns original color.
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
