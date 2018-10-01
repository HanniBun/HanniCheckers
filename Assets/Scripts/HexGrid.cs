using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Taken directly from MiniMax
interface IState
{
    int currentValue { get; set; }
    List<IState> Expand(IPlayer player);
    int Value(IPlayer player);
}

interface IPlayer
{

}



public class HexGrid : MonoBehaviour
{
    [SerializeField] GameObject cellPrefab;
    GameObject tempCell;

    const int rows = 17, columns = 13;

    public HexCell[,] myGameBoard = new HexCell[rows, columns];

    StateController myStateController;
    SaveGameController mySaveGameController;

    void Start()
    {
        myStateController = this.GetComponent<StateController>();
        mySaveGameController = this.GetComponent<SaveGameController>();

        myStateController.StateSetup(PlayerPrefs.GetInt("PlayerAmount")); // To be changed


        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (myStateController.States[i, j] != StateController.state.invalid)
                {
                    if (i % 2 == 0)
                    {
                        tempCell = Instantiate(cellPrefab, new Vector3(0.865f + j * 1.73f, 0, i * 1f), transform.rotation);
                    }

                    else
                    {
                        tempCell = Instantiate(cellPrefab, new Vector3(j * 1.73f, 0, i * 1f), transform.rotation);
                    }

                    tempCell.transform.parent = this.transform; // Makes it not so cluttered in the hierarchy. Yay, structure!

                    tempCell.GetComponent<HexCell>().myCellState = myStateController.States[i, j]; // Gets the cell's state from the array of states.
                    tempCell.GetComponent<HexCell>().row = i;
                    tempCell.GetComponent<HexCell>().col = j;

                    myGameBoard[i, j] = tempCell.GetComponent<HexCell>();
                }

                else
                    myGameBoard[i, j] = null;
            }
        }
    }
}
