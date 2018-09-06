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
        /*
        for (int z = 0, i = 0; z < testGrid.Length; z++)  // Loops through this 16 times.
        {
            for (int x = 0; x < rowLengths.Length; x++) // Loops through this 17 times.
            {
                CreateCell(x, z, i++);
            }
        }*/

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

                //virtualBoard[i][j].AssignIndex(j, i);
                //virtualBoard[i][j] = tile.GetComponent<TileScript>();

                // virtualBoard[i][j].AssignIndex(j, i);
            }

            /* void CreateCell(int x, int z, int i)
             {
                 Vector3 position;
                // position.x = /*(x + z * 0.5f - z / 2) /*(HexMetrics.innerRadius * 2f)*/
            //x;
            // position.y = 0f;
            // position.z = z  /*(HexMetrics.outerRadius * 1.5f)*/ ;

            // IndividualNodes cell = cells[i] = Instantiate<IndividualNodes>(testNoderino);
            //testNode.transform.SetParent(transform, false);
            // testNoderino.transform.localPosition = position;

        }
    }
}
