using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexCell : MonoBehaviour
{
    enum AreaOnBoard { Home, Goal, Battlefield }
    // The idea here is that there are 3 areas on the board; 
    //one Home, where they spawn, one Goal, which somehow (I don't know how right now, I'll get to it later) is to be used in some sort of Win-condition.
    // The Battlefield area is just there because I think the word sounds cool, and I wanted a state for the cells that aren't Home or Goal.

    static string namerino = "Mr Cell"; // Trying out and playing with Static.
    public int IndexOnBoard;

}