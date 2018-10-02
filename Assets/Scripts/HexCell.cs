using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HexCell : MonoBehaviour
{
    [SerializeField]
    HexGridController myGridController;  // Used to reach the materials for the cells!

    public StateController.State myCellState { get; set; }

    public bool clickableCell;

    [SerializeField]
    private int _row, _col; 
    public int row { get { return _row; } set { _row = value; } }   
    public int col { get { return _col; } set { _col = value; } } 

    private void Start()
    {
        myGridController = GetComponentInParent<HexGridController>();
        ColorCheck(); 
    }

    public void ColorCheck() // Note to self: Can connect states with the cellcolors, they have the same index :)
    {
        switch (myCellState)
        {
            case StateController.State.invalid:
                {
                    clickableCell = false;
                    return;
                }

            case StateController.State.empty:
                {
                    this.GetComponent<Renderer>().material = myGridController.cellColors[6];
                    clickableCell = false; // set this to true if a neighbor. (via ClickerManager -> HexGridController)
                    return;
                }

            case StateController.State.blue:
                {
                    this.GetComponent<Renderer>().material = myGridController.cellColors[0];
                    clickableCell = true;
                    return;
                }
            case StateController.State.green:
                {
                    this.GetComponent<Renderer>().material = myGridController.cellColors[1]; 
                    clickableCell = true;
                    return;
                }
            case StateController.State.orange:
                {
                    this.GetComponent<Renderer>().material = myGridController.cellColors[2];
                    clickableCell = true;
                    return;
                }
            case StateController.State.purple:
                {
                    this.GetComponent<Renderer>().material = myGridController.cellColors[3];
                    clickableCell = true;
                    return;
                }
            case StateController.State.red:
                {
                    this.GetComponent<Renderer>().material = myGridController.cellColors[4];
                    clickableCell = true;
                    return;
                }

            case StateController.State.yellow:
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
