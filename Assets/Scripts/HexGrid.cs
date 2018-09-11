using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexGrid : MonoBehaviour {
   
    public GameObject cellPrefab;

    GameObject tempObject;

    [SerializeField]
    HexCell[] cells;

    const int width = 13; const int height = 16;

    HexCell[,] gameBoard = new HexCell[height, width];  //myArray.GetLength(0)  -> Gets first dimension size,   myArray.GetLength(1)  -> Gets second dimension size

    public Text cellLabelPrefab;

    float testVarX = 0f; 
 
    Canvas gridCanvas;

    void Awake()
    {
        gridCanvas = GetComponentInChildren<Canvas>();

        //cells = new HexCell[121]; 

        for (int z = 0, i = 0; z < gameBoard.GetLength(0); z++) // Goes through 16 times (rad).
        {
            for (int x = 0; x < gameBoard.GetLength(1); x++) //Hämtar vilken rad, går igenom det indexet i rowLengths (z-värdet), X är det som ökar
            {
               if (z%2 == 0)
                {
                    CreateCell(x, z + 1, i++); // Offset vart annat.
                }

               else
                {
                    CreateCell(x, z, i++);
                }

                gameBoard[x, z] = tempObject.GetComponent<HexCell>();
            }
        }
    }

    void CreateCell(int x, int z, int i)  // x = vilken plats i raden (rowLengths), dvs 1, 1, 2, 1, 2, 3... , z = vilken rad, i = ett värde för vilken initiering det är, den ökar för varje.
    {
        Vector3 position;
        position.x = x * 1.5f;
        position.y = 0f;
        position.z = z * (HexMetrics.outerRadius * 1.5f);

        tempObject = Instantiate(cellPrefab, position, transform.rotation); 
        tempObject.transform.SetParent(transform, false);
        tempObject.transform.localPosition = position;


        Text label = Instantiate<Text>(cellLabelPrefab);
        label.rectTransform.SetParent(gridCanvas.transform, false);
        label.rectTransform.anchoredPosition =
            new Vector2(position.x, position.z);
        label.text = x.ToString() + "\n" + z.ToString();
    }
}
