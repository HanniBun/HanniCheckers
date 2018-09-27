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

    [SerializeField]
    private int _row, _col; 
    public int row { get { return _row; } set { _row = value; } }   
    public int col { get { return _col; } set { _col = value; } } 

    private void Start()
    {
        myGridController = GetComponentInParent<HexGridController>();

        ColorCheck(); // does a color check on start, and "sets" the cell accordingly with the right color, and if it's clickable or not.
    }

    public void ColorCheck() //****************************************************************
                             // On shitslearning, you suggested using a "uppslagningstabell" instead of this method. Did you mean Lookup or Dictionary? In that case, could you explain how you meant?
                             // I could've asked you in person, but I have been unable to come to school.
    {
        switch (myCellState)
        {
            case StateController.state.invalid:
                {
                    clickableCell = false;
                    //this.gameObject.SetActive(false);
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

            default:
                {
                    clickableCell = false;
                    this.gameObject.SetActive(false);
                    return;
                }
        }
    }
}
