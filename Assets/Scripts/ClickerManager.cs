using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerManager : MonoBehaviour {

    [SerializeField]
    HexCell startClickedCell;
    [SerializeField]
    HexCell goalClickedCell;

    [SerializeField]
    HexGridController myHexgridController;
    public Material clickedMaterial;

    bool pickedUpCell;

    // Maybe have a temporary list of myClickCell's neighbors, for easy access? 


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

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.GetComponent<HexCell>() == true) // If we haven't picked up a cell...
            {
                if (pickedUpCell == false) // if we haven't picked up a cell...
                {
                    startClickedCell = hit.collider.gameObject.GetComponent<HexCell>();  // ... set clicked cell to Start clicked cell.

                    if (startClickedCell.myCellState != HexCell.cellState.invalid && startClickedCell.myCellState != HexCell.cellState.empty) // If it contains a player... ( to be changed later, just making sure it works for now)
                    {
                        print("Hello! My index is... " + "row: " + startClickedCell.row.ToString() + ", col: " + startClickedCell.col + ", and I'm " + startClickedCell.myCellState);

                        startClickedCell.pickedUp = true; // Pick it up! 
                        pickedUpCell = true;
                        myHexgridController.AllNeighborCheck(startClickedCell.row, startClickedCell.col);  // Check for neighbors! (WORK IN PROGRESS)
                        hit.collider.gameObject.GetComponent<Renderer>().material = clickedMaterial;
                        print("I have been picked up!");
                    }

                    else
                        print("You can't click me.");
                }

                else if (pickedUpCell == true) // If we HAVE picked up a cell...
                {
                    goalClickedCell = hit.collider.gameObject.GetComponent<HexCell>();

                    // check neighbors of StartCell, see if goalClickedCell is one of them? Or just clickable?
                }
            }


            else
                print("Area out of bounds"); // When clicking on something else than something containing a HexCell
        }
    }
}
