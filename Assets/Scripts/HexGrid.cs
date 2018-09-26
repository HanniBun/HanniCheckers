using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
    [SerializeField] GameObject cellPrefab;
    GameObject tempCell;

    const int rows = 17, columns = 13;

    public HexCell[,] myGameBoard = new HexCell[rows, columns];

    StateController myStateController;

    void Start()
    {
        myStateController = this.GetComponent<StateController>();
        myStateController.StateSetup(PlayerPrefs.GetInt("PlayerAmount"));

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
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
        }
    }
}
