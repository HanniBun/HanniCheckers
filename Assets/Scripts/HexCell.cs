using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HexCell : MonoBehaviour
{
    [SerializeField]
    HexGridController myGridController;  // Used to reach the materials for the cells!


    public StateController.state myCellState { get; set; }

    public bool clickableCell;
    public bool pickedUp;

    //struct Coordinates { int row; int col; }  // Instead of using raycast, use coordinates? This can be made into a list as well. Neat!

    [SerializeField]
    private int _row, _col; // So that we can see the rows and col in the Inspector.
    public int row { get { return _row; } set { _row = value; } }   
    public int col { get { return _col; } set { _col = value; } }   // I'm not entirely sure these are necessary, but I'm leaving them as they are for now.


    private void Start()
    {
        myGridController = GetComponentInParent<HexGridController>();

        ColorCheck(); // does a color check on start, and "sets" the cell accordingly with the right color, and if it's clickable or not.
    }

    public void ColorCheck()
    {
        switch (myCellState)
        {
            case StateController.state.invalid:
                {
                    clickableCell = false;
                    this.gameObject.SetActive(false);
                    return;
                }

            case StateController.state.empty:
                {
                    this.GetComponent<Renderer>().material = myGridController.cellColors[6];
                    clickableCell = false; // set this to true if a neighbor. (via ClickerManager -> HexGridController)
                    return;
                }

            case StateController.state.blue:
                {
                    this.GetComponent<Renderer>().material = myGridController.cellColors[0];
                    clickableCell = true;
                    return;
                }
            case StateController.state.green:
                {
                    this.GetComponent<Renderer>().material = myGridController.cellColors[1]; 
                    clickableCell = true;
                    return;
                }
            case StateController.state.orange:
                {
                    this.GetComponent<Renderer>().material = myGridController.cellColors[2];
                    clickableCell = true;
                    return;
                }
            case StateController.state.purple:
                {
                    this.GetComponent<Renderer>().material = myGridController.cellColors[3];
                    clickableCell = true;
                    return;
                }
            case StateController.state.red:
                {
                    this.GetComponent<Renderer>().material = myGridController.cellColors[4];
                    clickableCell = true;
                    return;
                }

            case StateController.state.yellow:
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
