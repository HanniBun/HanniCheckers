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

    public int row { get; set; }   // Used so that each cell knows its "address",
    public int col { get; set; }   //i.e. its index in the myGameboard[][].

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

    List<HexCell> myNeighbors; // Temporary fix, I just need it to work right now.

    //Meshrenderer myMesh;
    private void Start()
    {
        MeshRenderer myMesh = GetComponent<MeshRenderer>();
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
        if ((col - myHexGrid.offsetAmount[row] + 1) < myHexGrid.AmountOfStuff[row]) // EAST neighbor check
        {
            ENeighbor = myHexGrid.myGameBoard[row][(col - myHexGrid.offsetAmount[row]) + 1];
            Debug.Log("My eastern neighbor is... " + myHexGrid.myGameBoard[row][(col - myHexGrid.offsetAmount[row]) + 1].GetComponent<HexCell>().row.ToString() + "," + myHexGrid.myGameBoard[row][(col - myHexGrid.offsetAmount[row]) + 1].GetComponent<HexCell>().col);
            ENeighbor.gameObject.GetComponent<Renderer>().material = neighborMaterial;
        }

        else
        {
            ENeighbor = null;
            print((col - myHexGrid.offsetAmount[row]) + 1);
            print("No neighbor to the East");
        }

        if ((col - myHexGrid.offsetAmount[row] - 1) > 0) // WEST neighbor check
        {
            WNeighbor = myHexGrid.myGameBoard[row][(col - myHexGrid.offsetAmount[row]) - 1];
            Debug.Log("My western neighbor is... " + myHexGrid.myGameBoard[row][(col - myHexGrid.offsetAmount[row]) - 1].GetComponent<HexCell>().row.ToString() + "," + myHexGrid.myGameBoard[row][(col - myHexGrid.offsetAmount[row]) - 1].GetComponent<HexCell>().col);
            WNeighbor.gameObject.GetComponent<Renderer>().material = neighborMaterial;
        }
        else
        {
            WNeighbor = null;
            print("No neighbor to the West");
        }

        /*if (row % 2 == 0) // i.e. even row
        {
            if ()  // NE*/
           // Debug.Log("|| (NW) X: " + (x - 1.5) + ", Z: " + (z + 1) + "|| (NE) X: " + (x + 1.5) + ", Z: " + (z + 1) + "|| (SW) X: " + (x - 1.5) + ", Z: " + (z - 1) + "|| (SE) X: " + (x + 1.5) + ", Z: " + (z - 1));
            // NW: x - 1.5, z + 1;  NE: x + 1.5, z + 1;  SW: x - 1.5, z - 1;  SE: x + 1.5, z - 1;

       // }

        //if (row % 2 != 0) // i.e. uneven row
        //{
          // NW: x - 0.5, z + 1; NE: x 0.5, z + 1;  SW: x - 1, z - 1;  SE: x + 1, z - 1;*/
        //}*/



    }
}