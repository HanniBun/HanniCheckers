using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HexCell : MonoBehaviour
{
    [SerializeField]
    HexGrid myHexGrid;  // Used to somehow reach the array in which this is in.

    public Material neighborMaterial;
    [SerializeField]
    private int _row, _col;
    public int row { get { return _row; } set { _row = value; } }   // Used so that each cell knows its "address",
    public int col { get { return _col; } set { _col = value; } }   //i.e. its index in the myGameboard[][].



    //public int positionOnCol { get; set; }

    //static string namerino = "Mr Cell"; // Trying out and playing with Static.

    bool occupied;

    public enum cellColor { blue, red, black, white, purple, green, empty};

    [SerializeField]
    HexCell ENeighbor;
    [SerializeField]
    HexCell WNeighbor;
    [SerializeField]
    HexCell SWNeighbor;
    [SerializeField]
    HexCell NWNeighbor;
    [SerializeField]
    HexCell SENeighbor;
    [SerializeField]
    HexCell NENeighbor;

    Color[] allColors = { Color.blue, Color.red, Color.black, Color.white, Color.magenta, Color.green };

   public MeshRenderer myMesh { get; set; } // Work in progress...

    //Meshrenderer myMesh;
    private void Start()
    {
        //MeshRenderer myMesh = GetComponent<MeshRenderer>();
        myHexGrid = FindObjectOfType<HexGrid>();

    }

    void ColorCheck(cellColor myColor)
    {
        switch (myColor)
        {
            case cellColor.blue:
                {
                    myMesh.material.SetColor("blue" , allColors[1]);
                    return;
                }
            case cellColor.red:
                {
                    myMesh.material.SetColor("Red", allColors[2]);
                    Debug.Log("I am red!");
                    return;
                }
            case cellColor.black:
                {
                    myMesh.material.SetColor("Black", allColors[3]);
                    return;
                }
            case cellColor.white:
                {
                    myMesh.material.SetColor("White", allColors[4]);
                    return;
                }
            case cellColor.purple:
                {
                    myMesh.material.SetColor("Purple", allColors[5]);
                    return;
                }
            case cellColor.green:
                {
                    myMesh.material.SetColor("Green", allColors[6]);
                    return;
                }
            default:
                {
                    return;
                }
        }
    }

    public void WhoAreMyNeighbors()
    {
        if ((col - myHexGrid.newOffsetAmount[row] + 1) < myHexGrid.AmountOfStuff[row]) // EAST neighbor check works completely
        {
            ENeighbor = myHexGrid.myGameBoard[row][(col - myHexGrid.newOffsetAmount[row]) + 1];
            //print("E Neighbor: " + ENeighbor.gameObject.GetComponent<HexCell>().row + ", " + ENeighbor.gameObject.GetComponent<HexCell>().col);
            ENeighbor.gameObject.GetComponent<Renderer>().material = neighborMaterial;
        }

        else
        {
            print("No E neighbor");
            ENeighbor = null;
        }

        if ((col - myHexGrid.newOffsetAmount[row] - 1) >= 0) // WEST neighbor check works completely
        {
            WNeighbor = myHexGrid.myGameBoard[row][(col - myHexGrid.newOffsetAmount[row]) - 1];
            //print("W Neighbor: " + WNeighbor.gameObject.GetComponent<HexCell>().row + ", " + WNeighbor.gameObject.GetComponent<HexCell>().col);
            WNeighbor.gameObject.GetComponent<Renderer>().material = neighborMaterial;
        }

        else
        {
            print("No W neighbor");
            WNeighbor = null;
        }

        if (myHexGrid.myGameBoard[row + 1] != null) // Check if there's a row over us. 
        {
            //if (row % 2 == 0) // Check NE, NW neighbors for even rows. Works as intended, AS LONG as the board isn't wonky. 
            //{
            //    if (myHexGrid.myGameBoard[row + 1][(col - myHexGrid.newOffsetAmount[row])] != null) // NE neighbor check
            //    {
            //        print(row.ToString() + "," + col + "(even) NE neighbor: " + myHexGrid.myGameBoard[row + 1][(col - myHexGrid.newOffsetAmount[row])].GetComponent<HexCell>().row.ToString() + ", " + myHexGrid.myGameBoard[row + 1][(col - myHexGrid.newOffsetAmount[row])].GetComponent<HexCell>().col.ToString());
            //        NENeighbor = myHexGrid.myGameBoard[row + 1][(col - myHexGrid.newOffsetAmount[row])];
            //        NENeighbor.gameObject.GetComponent<Renderer>().material = neighborMaterial;
            //    }

            //    else
            //    {
            //        print("(even)No NE neighbor");
            //        NENeighbor = null;
            //    }

            //    if (myHexGrid.myGameBoard[row + 1][(col - myHexGrid.newOffsetAmount[row]) - 1] != null)  // NW neighbor check
            //    {
            //        print(row.ToString() + "," + col + "(even)NW neighbor: " + myHexGrid.myGameBoard[row + 1][(col - myHexGrid.newOffsetAmount[row] - 1)].GetComponent<HexCell>().row.ToString() + ", " + myHexGrid.myGameBoard[row + 1][(col - myHexGrid.newOffsetAmount[row] - 1)].GetComponent<HexCell>().col.ToString());
            //        NWNeighbor = myHexGrid.myGameBoard[row + 1][(col - myHexGrid.newOffsetAmount[row]) - 1];
            //        NWNeighbor.gameObject.GetComponent<Renderer>().material = neighborMaterial;

            //    }

            //    else
            //    {
            //        print("(even)No NW neighbor");
            //        NWNeighbor = null;
            //    }
            //}

            //else if (row % 2 != 0) // Check NE, NW neighbors for uneven rows. Works as intended, as long as I fix the darn board.
            //{
            //    if (myHexGrid.myGameBoard[row + 1][(col - myHexGrid.newOffsetAmount[row])/*+1*/] != null) // NE neighbor check (is this even right??)
            //    {
            //        print(row.ToString() + "," + col + "(uneven) NE neighbor: " + myHexGrid.myGameBoard[row + 1][(col - myHexGrid.newOffsetAmount[row])/*+1*/].GetComponent<HexCell>().row.ToString() + "," + myHexGrid.myGameBoard[row + 1][(col - myHexGrid.newOffsetAmount[row]) /*+ 1*/].GetComponent<HexCell>().col.ToString());
            //        NENeighbor = myHexGrid.myGameBoard[row + 1][(col - myHexGrid.newOffsetAmount[row]) /*+ 1*/];
            //        NENeighbor.gameObject.GetComponent<Renderer>().material = neighborMaterial;
            //    }

            //    else
            //    {
            //        NENeighbor = null;
            //        print("(uneven)No NE neighbor!");
            //    }

            //    if ((myHexGrid.myGameBoard[row + 1][(col - myHexGrid.newOffsetAmount[row]) - 1] != null)) // NW neighbor check (is this even right??))
            //    {
            //        print(row.ToString() + "," + col + "(uneven) NW neighbor: " + myHexGrid.myGameBoard[row + 1][(col - myHexGrid.newOffsetAmount[row]) - 1].GetComponent<HexCell>().row.ToString() + "," + myHexGrid.myGameBoard[row + 1][(col - myHexGrid.newOffsetAmount[row]) - 1].GetComponent<HexCell>().col.ToString());
            //        NWNeighbor = myHexGrid.myGameBoard[row + 1][(col - myHexGrid.newOffsetAmount[row]) - 1];
            //        NWNeighbor.gameObject.GetComponent<Renderer>().material = neighborMaterial;
            //    }

            //    else
            //    {
            //        NWNeighbor = null;
            //        print("(uneven)No NW neighbor!");
            //    }
            //}

            print("There is a row over us.");
        }
        else if (myHexGrid.myGameBoard[row + 1] == null)
            print("No row above us!");

        //if (myHexGrid.myGameBoard[row - 1] != null) // Check if there's a row under us.
        //{
        //    if (row % 2 == 0) // Check SE, SW neighbors for even rows. Works as intended, AS LONG as the board isn't wonky. 
        //    {
        //        if (myHexGrid.myGameBoard[row - 1][(col - myHexGrid.newOffsetAmount[row])] != null) // SW neighbor check
        //        {
        //            print(row.ToString() + "," + col + "(even) SW neighbor: " + myHexGrid.myGameBoard[row - 1][(col - myHexGrid.newOffsetAmount[row])].GetComponent<HexCell>().row.ToString() + ", " + myHexGrid.myGameBoard[row - 1][(col - myHexGrid.newOffsetAmount[row])].GetComponent<HexCell>().col.ToString());
        //            SWNeighbor = myHexGrid.myGameBoard[row - 1][(col - myHexGrid.newOffsetAmount[row])];
        //            SWNeighbor.gameObject.GetComponent<Renderer>().material = neighborMaterial;
        //        }

        //        else
        //        {
        //            print("(even)No SW neighbor");
        //            SWNeighbor = null;
        //        }

        //        if (myHexGrid.myGameBoard[row - 1][(col - myHexGrid.newOffsetAmount[row]) + 1] != null)  // SE neighbor check
        //        {
        //            print(row.ToString() + "," + col + "(even)SE neighbor: " + myHexGrid.myGameBoard[row - 1][(col - myHexGrid.newOffsetAmount[row]) + 1].GetComponent<HexCell>().row.ToString() + ", " + myHexGrid.myGameBoard[row - 1][(col - myHexGrid.newOffsetAmount[row] + 1)].GetComponent<HexCell>().col.ToString());
        //            SENeighbor = myHexGrid.myGameBoard[row - 1][(col - myHexGrid.newOffsetAmount[row]) + 1];
        //            SENeighbor.gameObject.GetComponent<Renderer>().material = neighborMaterial;

        //        }

        //        else
        //        {
        //            print("(even)No SE neighbor");
        //            SENeighbor = null;
        //        }
        //    }

        //    else if (row % 2 != 0) // Check SE, SW neighbors for uneven rows. Works as intended, as long as I fix the darn board.
        //    {
        //        if (myHexGrid.myGameBoard[row - 1][(col - myHexGrid.newOffsetAmount[row])/*+1*/] != null) // SW neighbor check (is this even right??)
        //        {
        //            print(row.ToString() + "," + col + "(uneven) SW neighbor: " + myHexGrid.myGameBoard[row - 1][(col - myHexGrid.newOffsetAmount[row])/*+1*/].GetComponent<HexCell>().row.ToString() + "," + myHexGrid.myGameBoard[row - 1][(col - myHexGrid.newOffsetAmount[row]) /*+ 1*/].GetComponent<HexCell>().col.ToString());
        //            SWNeighbor = myHexGrid.myGameBoard[row - 1][(col - myHexGrid.newOffsetAmount[row]) /*+ 1*/];
        //            SWNeighbor.gameObject.GetComponent<Renderer>().material = neighborMaterial;
        //        }

        //        else
        //        {
        //            SWNeighbor = null;
        //            print("(uneven)No SW neighbor!");
        //        }

        //        if ((myHexGrid.myGameBoard[row - 1][(col - myHexGrid.newOffsetAmount[row]) + 1] != null)) // SE neighbor check (is this even right??))
        //        {
        //            print(row.ToString() + "," + col + "(uneven) SE neighbor: " + myHexGrid.myGameBoard[row - 1][(col - myHexGrid.newOffsetAmount[row]) + 1].GetComponent<HexCell>().row.ToString() + "," + myHexGrid.myGameBoard[row - 1][(col - myHexGrid.newOffsetAmount[row]) + 1].GetComponent<HexCell>().col.ToString());
        //            SENeighbor = myHexGrid.myGameBoard[row - 1][(col - myHexGrid.newOffsetAmount[row]) + 1];
        //            SENeighbor.gameObject.GetComponent<Renderer>().material = neighborMaterial;
        //        }

        //        else
        //        {
        //            SENeighbor = null;
        //            print("(uneven)No SE neighbor!");
        //        }

        //        print("There is a row beneath us.");
        //    }
        //    else if (myHexGrid.myGameBoard[row - 1] == null) // No row beneath us.
        //        print("No row beneath us!");


        //}
    }
}
