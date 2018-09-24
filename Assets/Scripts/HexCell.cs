using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HexCell : MonoBehaviour
{
    [SerializeField]
    HexGridController myGridController;  // Used to reach the materials for the cells!
    public enum cellState { invalid, empty, blue, green, orange, purple, red, yellow, };

    public HexGrid.state myCellState { get; set; }

    public bool clickableCell;
    public bool pickedUp;

    struct Coordinates { int row; int col; }  // Instead of using raycast, use coordinates? This can be made into a list as well. Neat!

    [SerializeField]
    private int _row, _col; // So that we can see the rows and col in the Inspector.
    public int row { get { return _row; } set { _row = value; } }   
    public int col { get { return _col; } set { _col = value; } }   // I'm not entirely sure these are necessary, but I'm leaving them as they are for now.


    private void Start()
    {
        myGridController = FindObjectOfType<HexGridController>(); // Maybe not use Find? There is always only one controller object. 

        ColorCheck(); // does a color check on start, and "sets" the cell accordingly with the right color, and if it's clickable or not.
    }

    public void ColorCheck()
    {
        switch (myCellState)
        {
            case HexGrid.state.invalid:
                {
                    clickableCell = false;
                    this.gameObject.SetActive(false); // sets invalid HexCells to not active. I wonder how this affects the myGameboard array? Are they still in there or are their indexes set to null somehow?
                    return;
                }

            case HexGrid.state.empty:
                {
                    this.GetComponent<Renderer>().material = myGridController.cellColors[6];
                    clickableCell = false; // set this to true if a neighbor. (via ClickerManager -> HexGridController)
                    return;
                }

            case HexGrid.state.blue:
                {
                    this.GetComponent<Renderer>().material = myGridController.cellColors[0];
                    print("I have become bluuuue");
                    clickableCell = true;
                    return;
                }
            case HexGrid.state.green:
                {
                    this.GetComponent<Renderer>().material = myGridController.cellColors[1]; 
                    clickableCell = true;
                    return;
                }
            case HexGrid.state.orange:
                {
                    this.GetComponent<Renderer>().material = myGridController.cellColors[2];
                    clickableCell = true;
                    return;
                }
            case HexGrid.state.purple:
                {
                    this.GetComponent<Renderer>().material = myGridController.cellColors[3];
                    clickableCell = true;
                    return;
                }
            case HexGrid.state.red:
                {
                    this.GetComponent<Renderer>().material = myGridController.cellColors[4];
                    clickableCell = true;
                    return;
                }

            case HexGrid.state.yellow:
                {
                    this.GetComponent<Renderer>().material = myGridController.cellColors[5];
                    clickableCell = true;
                    return;
                }

            default:  // There's supposed to always be a default in a Switch statement, right?
                {
                    clickableCell = false;
                    this.gameObject.SetActive(false);
                    return;
                }
        }



    }
}
