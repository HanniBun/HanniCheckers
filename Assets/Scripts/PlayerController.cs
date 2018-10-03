using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Contains how many players there are, as well as a list of them. 
    /// On Start(), HexGrid calls upon PlayerController.AddPlayers() so that we then can keep track of which player's turn it is.
    /// That happens through ClickerManager when a cell's been moved. It then calls upon PlayerController.NextTurn() which every time
    /// increases the index in allPlayers, and sets it to 0 if the next is out of index.
    /// </summary>

    // The script's not done: I have yet to connect the WinCheck() with some kind of UI element that informs the player who won.

    #region Definitions and references
    public int currentPlayer = 0;

    public int playerAmount;

    Player playerRef;

    public List<Player> allPlayers;

    #endregion

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);  // This is because the script needs to exist in both the menu and in game.
    }

    public void AddPlayers()
    {
        allPlayers = new List<Player>();

        for (int i = 0; i < playerAmount; i++)
        {
            Player player = new Player((StateController.State)i + 2)
            {
                Name = string.Format("Player {0}", i + 1)
            };

            allPlayers.Add(player);
        }
    }

    public void UpdatePlayerCellList(HexCell goalClickedCell, HexCell startClickedCell)
    {
        allPlayers[currentPlayer].playerCells.Remove(startClickedCell);
        allPlayers[currentPlayer].playerCells.Add(goalClickedCell);

        //TO DO: Add a check win condition method here. 
    }

    public void NextTurn()
    {
        if (currentPlayer + 1 != allPlayers.Count)
        {
            currentPlayer++;
            print("Current player++");
        }
        else
        {
            currentPlayer = 0;
            print("Current player reset to 0");
        }

        

    }

    public bool WinCheck(Player currentPlayer)
    {
        foreach (HexCell cells in currentPlayer.playerGoalCells)
        {
           if (cells.MyCellstate != currentPlayer.Color)
            {          
                return false;
            }          
        }

        Debug.Log(string.Format("{0} won!", currentPlayer));
        
        return true;
    }
}
