using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexCell : MonoBehaviour
{
    public int row { get; set; }   // Used so that each cell knows its "address",
    public int col { get; set; }   //i.e. its index in the myGameboard[][].


    static string namerino = "Mr Cell"; // Trying out and playing with Static.

}