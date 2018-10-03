using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class SaveFile {

    public int[,] savedStates = new int [17,13];

    public int playerAmount;
    public int currentPlayer;

}
