using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexGrid : MonoBehaviour
{

    // What I'm gonna be working on next:
    // Figure out how to find each cell's neighboring cells. Which I am having some problems with.
    // The reason for this is because, the gameboard is made out of a jagged array out of HexCells (the script on the cells).
    // As I have done so far, there is no set way to find neighbors, because the column 0 is along the left side on the board. I don't want that.
    // Having the 0 column index appear as a single line through the middle of the board would be smart, but I'm not sure of how to achieve that.

    // Something like this:
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

    [SerializeField] // SerializeField ain't neccessary atm
    HexCell tempCell; 

    const int width = 13; const int height = 17;

    //My old matrix for the gameboard. Might use this if the jagged one doesn't?
    //HexCell[,] gameBoard = new HexCell[height, width];

    HexCell[][] myGameBoard = new HexCell[height][];

    int [] AmountOfStuff = new int[] { 1, 2, 3, 4, 13, 12, 11, 10, 9, 10, 11, 12, 13, 4, 3, 2, 1 };
    float[] xStartPositions = { 0f, -.5f, -1f, -1.5f, -6f, -5.5f, -5f, -4.5f, -4f, -4.5f, -5f, -5.5f, -6f, -1.5f, -1f, -.5f, -0f }; // Manually set where each row's start position on x. Could probably be made better.
    int[] offsetAmount = { 0, 0, 1, 1, 6, 5, 5, 4, 4, 5, 5, 6, 1, 1, 0, 0 }; // Offset to somehow make the 0 column be in the middle

    //public Text cellLabelPrefab;
    //Canvas gridCanvas;

    void Awake()
    {
        //gridCanvas = GetComponentInChildren<Canvas>();

        for (int i = 0; i < 17; i++)
        {
            myGameBoard[i] = new HexCell[AmountOfStuff[i]];

            for (int j = 0; j < AmountOfStuff[i]; j++)
            {
                tempCell = Instantiate(cellPrefab, new Vector3(xStartPositions[i] + j, 0f, i), Quaternion.identity);
                tempCell.row = i; tempCell.col = j;
                myGameBoard[i][j] = tempCell;
            }
        }

        for(int z = 0; z < myGameBoard.Length; z++)  // Test to see if myGameBoard is being filled with HexCells or not.
        {
            for(int y = 0; y < myGameBoard[z].Length; y++)
            {
                Debug.Log(myGameBoard[z][y]);
            }
        }

        // ***********************
        // Don't mind this
        // ************************


        //for (int z = 0, i = 0; z < gameBoard.GetLength(0); z++) // Goes through 16 times (rad).
        //{
        //    for (int x = 0; x < gameBoard.GetLength(1); x++) //Hämtar vilken rad, går igenom det indexet i rowLengths (z-värdet), X är det som ökar
        //    {
        //       if (z%2 == 0)
        //        {
        //            CreateCell(x, z + 1, i++); // Offset vart annat.
        //        }

        //       else
        //        {
        //            CreateCell(x, z, i++);
        //        }

        //        gameBoard[x, z] = tempObject.GetComponent<HexCell>();
        //    }
        //}
    }


//    void CreateCell(int j, int i)  // x = vilken plats i raden (rowLengths), dvs 1, 1, 2, 1, 2, 3... , z = vilken rad, i = ett värde för vilken initiering det är, den ökar för varje.
//    {
//        Instantiate(cellPrefab, new Vector3(xStartPositions[i] + j, 0f, i), Quaternion.identity);

//        Text label = Instantiate<Text>(cellLabelPrefab);
//        label.rectTransform.SetParent(gridCanvas.transform, false);
//        label.rectTransform.anchoredPosition =
//            new Vector2 (xStartPositions[i] + j, i);
//        label.text = i.ToString() + "\n" + j.ToString();
//    }
}
