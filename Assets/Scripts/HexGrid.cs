using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexGrid : MonoBehaviour
{
    // So, I backtracked and replaced my jagged array with a 2D array instead. I was almost done with making sure each cell could find their neighbors,
    // but it's taken me more than a week to make that. I'm a bit worried that while applying the Minimax algorithm (which I haven't yet),
    // it'll get even more complicated writing my code and thus take more time. That's why I deleted everything and began from scratch.
    // It was more than 200 lines of code, but, sometimes you gotta make sacrifices I guess. Also it's probably worth it if the rest of the work
    // gets easier and faster.
    // (I use Github for version control, so I can always look back at my code)
   // *****************************************************

    [SerializeField] GameObject cellPrefab;
    GameObject tempCell;

    const int rows = 17, columns = 13;

    public HexCell [,] myGameBoard = new HexCell[rows, columns];

    void Start()
    {
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

                tempCell.GetComponent<HexCell>().myCellState = HexCell.cellState.invalid;

                tempCell.GetComponent<HexCell>().row = i;
                tempCell.GetComponent<HexCell>().col = j;
 
                myGameBoard[i, j] = tempCell.GetComponent<HexCell>();

                //tempCell.GetComponent<HexCell>().myCellState = HexCell.cellState.blue;
            }
        }
        myGameBoard[7, 6].GetComponent<HexCell>().myCellState = HexCell.cellState.blue;
        myGameBoard[7, 7].GetComponent<HexCell>().myCellState = HexCell.cellState.empty;
        myGameBoard[7, 5].GetComponent<HexCell>().myCellState = HexCell.cellState.empty;
    }
    }
