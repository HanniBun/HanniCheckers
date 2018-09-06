using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScriptTest : MonoBehaviour
{

    GameObject[][] testGrid = new GameObject[16][];  // Makes 16 empty things vertikalt. Rows.
    IndividualNodes[][] virtualBoard = new IndividualNodes[16][];


    int[] positionsForNodes = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }; // Coordinates in x-led.
    int[] rowLengths = new int[] { 1, 2, 3, 4, 13, 12, 11, 10, 9, 10, 11, 12, 13, 4, 3, 2, 1 };  // Columns.

    [SerializeField]
    GameObject testNoderino;  // our precious node object.


    //IndividualNodes[] cells; // Array of our node objects.

    [SerializeField]
    int width;
    [SerializeField]
    int height;

    float offset;
    int zLed;

    private void Awake()
    {
        //cells = new IndividualNodes[121]; // Vi har 121 platser. Detta är en array som är lika stor, och som kommer fyllas när "cellerna" skapas.
    }

    void Start()
    {
        width = rowLengths.Length;  // Shows 17.
        height = testGrid.Length; // Shows 16.


        for (int i = 0; i < testGrid.Length; i++) // Loops through 16 empty rows.
        {
            testGrid[i] = new GameObject[rowLengths[i]]; 
            virtualBoard[i] = new IndividualNodes[rowLengths[i]];
            zLed = 0;

            //loops through the column

            for (int j = 0; j < testGrid[i].Length; j++)
            {
                // Creates a tile for each index position for the current row
                GameObject tile = Instantiate(testNoderino, new Vector3((positionsForNodes[i] - 1) /*x-led*/, 0f, zLed)/*z-led*/, Quaternion.identity);
                virtualBoard[i][j] = tile.GetComponent<IndividualNodes>();
                zLed++;

            }

        }
    }
}
