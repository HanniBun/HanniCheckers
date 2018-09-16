using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexCell : MonoBehaviour
{
    [SerializeField]
    HexGrid myHexGrid;  // Used to somehow reach the array in which this is in.

    public int row { get; set; }   // Used so that each cell knows its "address",
    public int col { get; set; }   //i.e. its index in the myGameboard[][].

    bool myRowIsEven;
    //static string namerino = "Mr Cell"; // Trying out and playing with Static.

    bool occupied;

    public enum cellColor { blue, red, black, white, purple, green, empty};

    Color[] allColors = { Color.blue, Color.red, Color.black, Color.white, Color.magenta, Color.green };

   public MeshRenderer myMesh { get; set; } // Work in progress...

    List<HexCell> myNeighbors; // Temporary fix, I just need it to work right now.

    //Meshrenderer myMesh;
    private void Start()
    {
        MeshRenderer myMesh = GetComponent<MeshRenderer>();
        //cellColor myCellColor = myMesh.material.color();
        //ColorCheck(myCellColor);

        CheckIfRowIsEven();

    }
    
    void CheckIfRowIsEven()
    {
        if (row % 2 == 0)  // row is an index in the array, but when checking for neighbors we can just as well use its x and z positions. Hmm.
        {
            myRowIsEven = true;
        }
        else
        {
            myRowIsEven = false;
        }
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

    public void WhoAreMyNeighbors(float x, float z)
    {

        // E and W neighbors are the same no matter what row it is.
        Debug.Log("My neighbors are (E)... X:" + (x + 1) + ", Z:" + z + "|| (W) X: " + (x - 1) + ", Z: " + z);
        // E: x + 1, z;  W: x - 1, z

        if (myRowIsEven == true) {

            Debug.Log("|| (NW) X: " + (x - 1.5) + ", Z: " + (z + 1) + "|| (NE) X: " + (x + 1.5) + ", Z: " + (z + 1) + "|| (SW) X: " + (x - 1.5) + ", Z: " + (z - 1) + "|| (SE) X: " + (x + 1.5) +  ", Z: " + (z - 1));
            // NW: x - 1.5, z + 1;  NE: x + 1.5, z + 1;  SW: x - 1.5, z - 1;  SE: x + 1.5, z - 1;

        }
        else
        { }

        // NW: x - 0.5, z + 1; NE: x 0.5, z + 1;  SW: x - 1, z - 1;  SE: x + 1, z - 1;

    }
}