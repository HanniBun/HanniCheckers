using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
    /// <summary>
    /// HexGrid contains each gameObject's script HexCell, assign their states, and creates the gameObjects which shape the gameboard.
    /// On each cell's creation, HexGrid also goes through every Player's color (state) and checks if the cell's state is the same, 
    /// and in that case adds it to the Player's list of HexCells.
    /// </summary>

    /* I have added a very temporary win condition: In this script, I add HexCells to the Player's list of "Goal" HexCells.
    / Since this version of the game only supports two players, and it so happens that their respective "goals" are the same
    / HexCells that their opponent starts off on, the list of "Goal" HexCells contain the cells that aren't empty, i.e. has a color.
    / This was made for the sole purpose of making it possible to win in this version of the game. It certainly won't work for more
    / than 2 players. 
    I haven't begun applying the Minimax algorithm to my game, and I am aware that I need to prepare some things before I do so.*/



    #region Definitions and references

    const int rows = 17, columns = 13;
    public HexCell[,] myGameBoard = new HexCell[rows, columns];

    StateController myStateController;

    [SerializeField]
    PlayerController myPlayerController;

    [SerializeField] HexCell cellPrefab;
    HexCell tempCell;

    #endregion

    void Start()
    {
        myStateController = this.GetComponent<StateController>();
        myPlayerController = FindObjectOfType<PlayerController>();

        myPlayerController.AddPlayers();
        myStateController.StateSetup(myPlayerController.playerAmount);

        #region Instantiation of cell prefabs, setting of cellstates, and adding of cellstates to Player's list of cells
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (myStateController.States[i, j] != StateController.State.invalid)
                {
                    if (i % 2 == 0)
                    {
                        tempCell = Instantiate(cellPrefab, new Vector3(0.865f + j * 1.73f, 0, i * 1f), transform.rotation);
                    }

                    else
                    {
                        tempCell = Instantiate(cellPrefab, new Vector3(j * 1.73f, 0, i * 1f), transform.rotation);
                    }

                    tempCell.transform.parent = this.transform;

                    tempCell.MyCellstate = myStateController.States[i, j];
                    tempCell.row = j;
                    tempCell.col = i;

                    myGameBoard[i, j] = tempCell;
                    tempCell.name = string.Format("Cell({0},{1})", j, i);

                    foreach (Player player in myPlayerController.allPlayers)
                    {
                        if (player.Color == tempCell.MyCellstate)
                        {
                            player.playerCells.Add(tempCell);
                        }

                        else if (player.Color != tempCell.MyCellstate && tempCell.MyCellstate != StateController.State.empty)
                        {
                            player.playerGoalCells.Add(tempCell);
                        }
                    }
                }

                else
                    myGameBoard[i, j] = null;
            }
        }
        #endregion
    }
}
