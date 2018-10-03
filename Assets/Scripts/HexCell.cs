using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HexCell : MonoBehaviour
{
    /// <summary>
    /// HexCells make up the gameboard. They each contain their state, as well as ColorCheck(), which give the cell the corresponding material
    /// for its state. It's called upon on Start, as well as in ClickerManager when a cellstate is changed.
    /// </summary>

    #region Definitions and references
    [SerializeField]
    HexGridController myGridController;

    public StateController.State MyCellstate { get; set; }

    [SerializeField]
    private int _row, _col;
    public int row { get { return _row; } set { _row = value; } }
    public int col { get { return _col; } set { _col = value; } }

    #endregion

    private void Start()
    {
        myGridController = GetComponentInParent<HexGridController>();
        ColorCheck();
    }

    public void ColorCheck()
    {
        switch (MyCellstate)
        {
            case StateController.State.invalid:
                {
                    return;
                }

            case StateController.State.empty:
                {
                    this.GetComponent<Renderer>().material = myGridController.cellColors[6];
                    return;
                }

            case StateController.State.blue:
                {
                    this.GetComponent<Renderer>().material = myGridController.cellColors[0];
                    return;
                }
            case StateController.State.green:
                {
                    this.GetComponent<Renderer>().material = myGridController.cellColors[1];
                    return;
                }
            case StateController.State.orange:
                {
                    this.GetComponent<Renderer>().material = myGridController.cellColors[2];
                    return;
                }
            case StateController.State.purple:
                {
                    this.GetComponent<Renderer>().material = myGridController.cellColors[3];
                    return;
                }
            case StateController.State.red:
                {
                    this.GetComponent<Renderer>().material = myGridController.cellColors[4];
                    return;
                }

            case StateController.State.yellow:
                {
                    this.GetComponent<Renderer>().material = myGridController.cellColors[5];
                    return;
                }

            default:
                {
                    this.gameObject.SetActive(false);
                    return;
                }
        }
    }
}
