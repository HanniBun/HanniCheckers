using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexGrid : MonoBehaviour
{
/*
0                  0
0                 0 *
1                * 0 *
1               * 0 * *
6      * * * * * * 0 * * * * * *
5       * * * * * 0 * * * * * *
5        * * * * * 0 * * * * *
4         * * * * 0 * * * * *
4          * * * * 0 * * * *
4         * * * * 0 * * * * *
5        * * * * * 0 * * * * *
5       * * * * * 0 * * * * * *
6      * * * * * * 0 * * * * * *
1               * 0 * *
1                * 0 *
0                 0 *
0                  0
*/
    // I could've used a matrix (which I have tried), but I found it tedious to set each "invalid" cell on the sides outside of the board (and that's, like, lots of them).
    // Finding neighbors would be easier on a matrix though, since the indexes wouldn't be irregular in the shape of the gameboard.

    // ****************************************************************************************

    public HexCell cellPrefab;
    [SerializeField]
    HexCell tempCell; 

    const int width = 13; const int height = 17; // Used in making the myGameBoard.
    public HexCell[][] myGameBoard = new HexCell[height][];

    public int [] AmountOfStuff = new int[] { 1, 2, 3, 4, 13, 12, 11, 10, 9, 10, 11, 12, 13, 4, 3, 2, 1 };
    float[] xStartPositions = { 0f, -.5f, -1f, -1.5f, -6f, -5.5f, -5f, -4.5f, -4f, -4.5f, -5f, -5.5f, -6f, -1.5f, -1f, -.5f, -0f }; // Manually set where each row's start position on x. Could probably be made better.

    //public int[] newOffsetAmount = { 0, 0, -1, -1, -6, -5, -5, -4, -4, -4, -5, -5, -6, -1, -1, 0, 0 };

    public int[] newOffsetAmount = { 0, 0, -1, -1, -6, -5, -5, -4, -4, -4, -5, -5, -6, -1, -1, 0, 0 };
    void Awake()
    {
        for (int i = 0; i < newOffsetAmount.Length; i++)
        {
            print(newOffsetAmount[i]);
        }

        for (int i = 0; i < height; i++) // i = row
        {
            myGameBoard[i] = new HexCell[AmountOfStuff[i]];

            for (int j = 0; j < AmountOfStuff[i]; j++) // j = position on row
            {
                tempCell = Instantiate(cellPrefab, new Vector3(xStartPositions[i] + j, 0f, i), Quaternion.identity);
                //print(i + " = i");
                //print(offsetAmount[i] + "= offset[i]");
                tempCell.row = i; tempCell.col = newOffsetAmount[i] + j;  // Need to translate index -> positions on gameboard, in order to find neighbors!
                myGameBoard[i][j] = tempCell;
            }
        }
    }
}
