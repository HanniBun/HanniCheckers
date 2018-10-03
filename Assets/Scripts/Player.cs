using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Player
{    /// <summary> 
     /// Contains each player's name which right now only is used in the Inspector, but the idea is that it eventually can be
     /// used in the UI, for example to show which player's turn it is.
     /// We use Player.Color for checking if a clicked cell belongs to the current player.
     /// The list playerCells contain each player's cells, i.e. the ones with the same color. The list is changed through PlayerController()
     /// when a move has been made in ClickerManager().
     /// </summary>

    #region Definitions and references
    StateController playersStateController;

    [SerializeField]
    private string name;
    public string Name { get { return name; } set { name = value; } }

    [SerializeField]
    private StateController.State color;
    public StateController.State Color { get { return color; } }

    public List<HexCell> playerCells = new List<HexCell>();
    public List<HexCell> playerGoalCells = new List<HexCell>();

    #endregion

    public Player(StateController.State color)
    {
        this.color = color;
    }
}

