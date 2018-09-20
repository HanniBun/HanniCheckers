using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HexCell : MonoBehaviour
{
    [SerializeField]
    HexGridController myGridController;  // Used to reach the materials for the cells!
    public enum cellState { invalid, empty, blue, green, orange, purple, red, yellow, }; // Invalid is the default, that's why it's the first index.

    public cellState myCellState { get; set; }

    public bool clickableCell;
    public bool pickedUp;

    struct Coordinates { int row; int col; }  // Instead of using raycast, use coordinates? This can be made into a list as well. Neat!

    [SerializeField]
    private int _row, _col; // So that we can see the rows and col in the Inspector.
    public int row { get { return _row; } set { _row = value; } }   // Used so that each cell knows its "address",
    public int col { get { return _col; } set { _col = value; } }   //i.e. its index in the myGameboard[,].


    private void Start()
    {
        myGridController = FindObjectOfType<HexGridController>(); // Maybe not use Find? There is always only one controller object.

        ColorCheck(myCellState); // does a color check on start, and sets the cell accordingly.
        //print("my cell state is " + myCellState);
    }

    void ColorCheck(cellState myColor)
    {
        switch (myColor)
        {
            case cellState.invalid:
                {
                    clickableCell = false;
                    //this.gameObject.SetActive(false); // sets invalid HexCells to not active. I wonder how this affects the myGameboard array? Are they still in there or are their indexes set to null somehow?
                    return;
                }

            case cellState.empty:
                {
                    clickableCell = false; // set this to true if a neighbor?
                    return;
                }

            case cellState.blue:
                {
                    this.GetComponent<Renderer>().material = myGridController.cellColors[0]; // Sets this cell to a lovely blue color.
                    clickableCell = true;
                    return;
                }
            case cellState.green:
                {
                    this.GetComponent<Renderer>().material = myGridController.cellColors[1]; // And so on.
                    clickableCell = true;
                    return;
                }
            case cellState.orange:
                {
                    this.GetComponent<Renderer>().material = myGridController.cellColors[2];
                    clickableCell = true;
                    return;
                }
            case cellState.purple:
                {
                    this.GetComponent<Renderer>().material = myGridController.cellColors[3];
                    clickableCell = true;
                    return;
                }
            case cellState.red:
                {
                    this.GetComponent<Renderer>().material = myGridController.cellColors[4];
                    clickableCell = true;
                    return;
                }

            case cellState.yellow:
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
